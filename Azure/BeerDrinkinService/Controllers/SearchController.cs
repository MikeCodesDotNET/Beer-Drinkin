using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Azure.Search;
using System.Threading.Tasks;
using Microsoft.Azure.Search.Models;
using BeerDrinkin.Models;
using Microsoft.ApplicationInsights;

namespace BeerDrinkin.Controllers
{
    [MobileAppController]
    public class SearchController : ApiController
    {
        TelemetryClient telemtryClient = new TelemetryClient();
        BeerDrinkinContext context = new BeerDrinkinContext();
            
        ISearchServiceClient serviceClient = new SearchServiceClient("beerdrinkin", new SearchCredentials("08D2D12B51E07BFDDE17F6092F4C1575"));
        SearchIndexClient indexClient;

        // GET api/search
        public async Task<List<DataObjects.Beer>> Get(string searchTerm)
        {
            try
            {
                //Setup tracking how long the HTTP request takes.
                telemtryClient.Context.Operation.Id = Guid.NewGuid().ToString();
                telemtryClient.Context.Operation.Name = "BeerSearch";
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                //Log the fact we've search some beers
                telemtryClient.TrackEvent("SearchedBeers");
                indexClient = serviceClient.Indexes.GetClient("beers");

                //Setup suggestionParmeters for AzureSearch
                var suggestParameters = new SuggestParameters();
                suggestParameters.UseFuzzyMatching = true;
                suggestParameters.Top = 25;
                suggestParameters.HighlightPreTag = "[";
                suggestParameters.HighlightPostTag = "]";
                suggestParameters.MinimumCoverage = 100;

                var suggestions = await indexClient.Documents.SuggestAsync<DataObjects.AzureSearchBeerResponse>(searchTerm, "nameSuggester", suggestParameters);

                //Convert to Beer Drinkin Beer Type & save to our DB.
                var results = new List<DataObjects.Beer>();
                foreach (var result in suggestions.Results)
                {
                    var indexedBeer = result.Document;
                    var beer = new DataObjects.Beer
                    {
                        Id = indexedBeer.Id,
                        Brewery = indexedBeer.BreweryName,
                        Abv = indexedBeer.Abv,
                        Description = indexedBeer.Description,
                        BreweryDbId = indexedBeer.Id,
                        BreweryId = indexedBeer.BreweryId,
                        Name = indexedBeer.Name
                    };

                    if(indexedBeer.Images.Count() > 0)
                    {
                        beer.ImageSmall = indexedBeer?.Images[0];
                        beer.ImageMedium = indexedBeer?.Images[1];
                        beer.ImageLarge = indexedBeer?.Images[2];
                    }

                    results.Add(beer);

                    //Lets save the beer if its not already in our DB.
                    if (context.Beers.FirstOrDefault(x => x.Id == indexedBeer.Id) == null)
                    {
                        context.Beers.Add(beer);
                    }
                }
                await context.SaveChangesAsync();

                stopwatch.Stop();
                telemtryClient.TrackRequest("BeerSearch", DateTime.Now, stopwatch.Elapsed, "200", true);

                return results;
            }
            catch(Exception ex)
            {
                telemtryClient.TrackException(ex);
                return new List<DataObjects.Beer>();
            }
        }
    }
}