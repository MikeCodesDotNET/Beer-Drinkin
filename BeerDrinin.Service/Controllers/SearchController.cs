using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Helpers;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace BeerDrinkin.Service.Controllers
{
    [MobileAppController]
    public class SearchController : ApiController
    {
        readonly TelemetryClient telemtryClient = new TelemetryClient();
        private static readonly string apiKey = ConfigurationManager.AppSettings["SearchApiKey"];

        readonly ISearchServiceClient serviceClient = new SearchServiceClient("beerdrinkin", new SearchCredentials(apiKey));
        private SearchIndexClient indexClient;

        // GET api/Search
        [QueryableExpand("Brewery, Image")]
        [Route("api/search/beers")][HttpGet]
        public async Task<List<Beer>> Beers(string searchTerm)
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
                var suggestParameters = new SuggestParameters
                {
                    UseFuzzyMatching = true,
                    Top = 25,
                    HighlightPreTag = "[",
                    HighlightPostTag = "]",
                    MinimumCoverage = 100
                };
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

                    //beer.Image = new Image();
                    //Fetch Brewery information 

                    /*
                    if(indexedBeer.Images.Count() > 0)
                    {
                        beer.HasImages = true;
                        beer.Image.SmallUrl = indexedBeer?.Images[0];
                        beer.Image.MediumUrl = indexedBeer?.Images[1];
                        beer.Image.LargeUrl = indexedBeer?.Images[2];
                    }
                    */
                    results.Add(beer);
                }

                stopwatch.Stop();
                telemtryClient.TrackRequest("BeerSearch", DateTime.Now, stopwatch.Elapsed, "200", true);

                return results;
            }
            catch (Exception ex)
            {
                telemtryClient.TrackException(ex);
                return new List<Beer>();
            }
        }

        [Route("api/search/breweries")][HttpGet]
        public async Task<List<Brewery>> Breweries(string searchTerm)
        {
            return null;
        }

        [Route("api/search/users")][HttpGet]
        public async Task<List<User>> Users(string searchTerm)
        {
            return null;
        }
    }
}
