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
    public class PopularBeersController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/PopularBeers
        public async Task<List<BeerItem>> Get(double longitude, double latitude)
        {
            //Find the current country of the user
            string bingKey;
            if (!(Services.Settings.TryGetValue("BING_API_KEY", out bingKey)))
            {
                Services.Log.Error("Could not retrieve Bing API key.");
                bingKey = "AlPB42X199-b_n7tnHPSNM15E4cvLv18hfj4upv3irWgSFHx5GplSaOS3wpggCox";
            }
            Services.Log.Info($"Bing API Key{bingKey}");

            string countryRegion;
            var client = new Bing.MapsClient(bingKey);
            var result = await client.LocationQuery(new Bing.Maps.Point(latitude, longitude));
            var locations = result.GetLocations();

            if(locations.Count != 0)
            {
                countryRegion = result.GetLocations().First().Address.CountryRegion;

                Services.Log.Info($"A user is has just been seen in {countryRegion}");
            }
            else
            {
                Services.Log.Error("Failed to lookup country. Results returned as null");
            }
                        


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

          
           
            return beerList;
        }
    }
}