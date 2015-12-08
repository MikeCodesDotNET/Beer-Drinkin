using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Web.Http.Tracing;
using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.DataObjects;
using Microsoft.Azure.Mobile.Server;

namespace BeerDrinkin.Service.Controllers
{
    [Authorize]
    public class BeerInfoController : ApiController
    {
        private readonly MobileAppSettingsDictionary settings;
        private readonly ITraceWriter tracer;

        public BeerInfoController()
        {
            settings = Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            tracer = Configuration.Services.GetTraceWriter();
        }

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
                if (!(settings.TryGetValue("BREWERYDB_API_KEY", out apiKey)))
                {
                    tracer.Error("Could not retrieve BreweryDB API key.");
                    return null;
                }
                tracer.Info(string.Format("BreweryDB API Key {0}", apiKey));
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
                tracer.Error(ex.Message);
            }

            return null;
        }

        
    }
}
