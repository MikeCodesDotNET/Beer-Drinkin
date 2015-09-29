using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.Utils;
using BreweryDB;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace BeerDrinkin.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class PopularBeersController
    {
        public ApiServices Services { get; set; }

        // GET api/PopularBeers
        public async Task<List<BeerItem>> Get(string countryCode)
        {
            var context = new BeerDrinkinContext();
            var beerList = new List<BeerItem>();
            
            //Setup BreweryDB Client 
            if (string.IsNullOrEmpty(BreweryDBClient.ApplicationKey))
            {
                string apiKey;
                // Try to get the BreweryDB API key  app settings.  
                if (!(Services.Settings.TryGetValue("BREWERYDB_API_KEY", out apiKey)))
                {
                    Services.Log.Error("Could not retrieve BreweryDB API key.");
                    return null;
                }
                Services.Log.Info($"BreweryDB API Key {apiKey}");
                BreweryDBClient.Initialize(apiKey);
            }

            //Fetch poplular beers
            var popularBeers = context.PopularBeerItems.Where(f => f.CountryCode == countryCode);
            
            foreach (var popularBeer in popularBeers)
            {
                var beerResponse = await new BreweryDBClient().QueryBeerById(popularBeer.BeerId);
                var beer = beerResponse.ToBeerItem();
                beerList.Add(beer);
            }
           
            return beerList;
        }
    }
}