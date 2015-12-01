using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class BeerInfoController : ApiController
    {
        public ApiServices Services { get; set; }

        BeerDrinkinContext _context;

        BeerDrinkinContext Context
        {
            get
            {
                if (_context == null)
                    _context = new BeerDrinkinContext();
                return _context;
            }
        }

        // GET api/BeerInfo
        public async Task<BeerInfo> Get(string userId, string beerId)
        {
            if (string.IsNullOrEmpty(BreweryDB.BreweryDBClient.ApplicationKey))
            {
                string apiKey;
                // Try to get the BreweryDB API key  app settings.  
                if (!(Services.Settings.TryGetValue("BREWERYDB_API_KEY", out apiKey)))
                {
                    Services.Log.Error("Could not retrieve BreweryDB API key.");
                    return null;
                }
                Services.Log.Info(string.Format("BreweryDB API Key {0}", apiKey));
                BreweryDB.BreweryDBClient.Initialize(apiKey);
            }

            try
            {
                var beer = await new BreweryDB.BreweryDBClient().QueryBeerById(beerId);
                if (beer != null)
                {
                    var beerInfo = new BeerInfo();
                    beerInfo.Name = beer.Name;
                    beerInfo.BreweryDBId = beer.Id;
                    var beerCheckins = Context.CheckInItems.Where(f => f.BeerId == beer.Id);
                    beerInfo.CheckIns = beerCheckins.Where(f => f.CheckedInBy == userId);
                    beerInfo.AverageRating = Math.Round(beerCheckins.Select(f => f.Rating).Average(), 1);
                    beerInfo.Reviews = Context.ReviewItems.Where(f => f.BeerId == beer.Id);
                    beerInfo.ImagesURLs = Context.BinaryItems.Where(f => f.ObjectId == beer.Id).Select(f=>f.BinaryUrl);

                     return beerInfo; 
                }
            }
            catch (Exception ex)
            {
                Services.Log.Error(ex.Message);
            }

            return null;
        }

        
    }
}
