using BeerDrinkin.DataObjects;
using BeerDrinkin.Models;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BeerDrinkin.Service.Controllers
{
    [MobileAppController]
    public class BarcodeController : ApiController
    {
        TelemetryClient telemetryClient;
        BeerDrinkinContext context;

        public BarcodeController()
        {
            telemetryClient = new TelemetryClient();
            context = new BeerDrinkinContext();
        }

        // GET api/barcode
        public async Task<List<Beer>> Get(string upc)
        {
            try
            {
                var beers = new List<Beer>();
                foreach(var b in context.Beers)
                {
                    foreach(var barcode in b.Upcs)
                    {
                        if (barcode == upc)
                            beers.Add(b);
                    }
                }
                if(beers.Count > 0)
                    return beers;

                var properties = new Dictionary<string, string>();
                properties.Add("UPC", upc);
                telemetryClient.TrackEvent("LookupBarcode", properties);

                var rateBeerClient = new RateBeer.Client();
                var results = await rateBeerClient.SearchForBeer(upc);
                if (results == null)
                    return null;

                var breweryDbService = new Services.BreweryDBService();
                return await breweryDbService.SearchBeers(results.BeerName);
            }
            catch(Exception ex)
            {
                telemetryClient.TrackException(ex);
                return null;
            }
        }

        public async Task<bool> Post(string beerId, string upc)
        {
            var properties = new Dictionary<string, string>();
            properties.Add("BeerId", beerId);
            properties.Add("UPC", upc);
            telemetryClient.TrackEvent("SaveBarcode", properties);

            var beer = context.Beers.FirstOrDefault(x => x.Id == beerId);
            if (beer == null)
                return false;

            try
            {
                beer.Upc = upc;
                context.Beers.Add(beer);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                telemetryClient.TrackException(ex);
                return false;
            }
        }

    }
}