using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using BeerDrinkin.Service.Models;
using System.Linq;
using System.Net.Http;
using BeerDrinkin.Service.Helpers;
using BeerDrinkin.Service.Utils;
using BreweryDB.Models;
using Newtonsoft.Json;

namespace BeerDrinkin.Service
{
    // A simple scheduled job which can be invoked manually by submitting an HTTP
    // POST request to the path "/jobs/BuildBeerDatabase".

    public class BuildBeerDatabaseJob : ScheduledJob
    {
        private HttpClient client;


        public async Task<Page<Beer>> AllBeers(int pageNumber = 1)
        {
            try
            {
                if (client == null)
                    client = new HttpClient();

                string apiKey;
                if (!(Services.Settings.TryGetValue("BREWERYDB_API_KEY", out apiKey)))
                {
                    Services.Log.Error("Could not retrieve BreweryDB API key.");
                }

                var url = $"https://api.brewerydb.com/v2/beers?p={pageNumber}&key={apiKey}&format=json";
                var response = await client.GetAsync(url);
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var model = JsonConvert.DeserializeObject<Page<Beer>>(jsonString.Result);
                return model as Page<Beer>;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async override Task ExecuteAsync()
        {
            //We'll be going off to BreweryDB, fetching all the beers they have and checking if we've already for that in our DB. If not, we'll go ahead and save it. 

            var context = new BeerDrinkinContext();

            var processedPageCount = 1;
            var totalPageCount = 99; //We replace this pretty quickly! 

            while (totalPageCount != processedPageCount)
            {
                var pageResult = await AllBeers(processedPageCount);
                totalPageCount = pageResult.NumberOfPages;

                foreach (var beer in pageResult.Data)
                {
                    var beerItem = beer.ToBeerItem();
                    context.Beers.Add(beerItem);
                    Services.Log.Info($"Saved {beerItem.Name} into our database");
                }
                Services.Log.Info($"Finished processing page {processedPageCount} of {totalPageCount}");
                processedPageCount++;

                await context.SaveChangesAsync();
            }

            Services.Log.Info("Hello from scheduled job!");
        }
    }
}