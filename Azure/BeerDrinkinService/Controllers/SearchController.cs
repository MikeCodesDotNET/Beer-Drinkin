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
using BeerDrinkin.Service.Helpers;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Controllers
{
    [MobileAppController]
    public class SearchController : ApiController
    {
        TelemetryClient telemtryClient = new TelemetryClient();
        BeerDrinkinContext context = new BeerDrinkinContext();
            
        ISearchServiceClient serviceClient = new SearchServiceClient("beerdrinkin", new SearchCredentials("08D2D12B51E07BFDDE17F6092F4C1575"));
        SearchIndexClient indexClient;

        [QueryableExpand("Brewery, Image")]
        public async Task<List<Beer>> Get(string searchTerm)
        {
            try
            {
                //Setup tracking how long the HTTP request takes.
                telemtryClient.Context.Operation.Id = Guid.NewGuid().ToString();
                telemtryClient.Context.Operation.Name = "Search";
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

                var suggestions = await indexClient.Documents.SuggestAsync<AzureSearchBeerResponse>(searchTerm, "nameSuggester", suggestParameters);

                //Convert to Beer Drinkin Beer Type & save to our DB.
                var results = new List<Beer>();
                foreach (var result in suggestions.Results)
                {
                    var indexedBeer = result.Document;
                    var beer = new Beer
                    {
                        Id = indexedBeer.Id,
                        Abv = indexedBeer.Abv,
                        Description = indexedBeer.Description,
                        BreweryDbId = indexedBeer.Id,
                        Name = indexedBeer.Name
                    };

                    beer.Image = new Image();
                    //Fetch Brewery information 

                    if(indexedBeer.Images.Count() > 0)
                    {
                        beer.HasImages = true;
                        beer.Image.SmallUrl = indexedBeer?.Images[0];
                        beer.Image.MediumUrl = indexedBeer?.Images[1];
                        beer.Image.LargeUrl = indexedBeer?.Images[2];
                    }
                    results.Add(beer);
                }

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