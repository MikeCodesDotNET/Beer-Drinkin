using BeerDrinkin.DataObjects;
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
        public BarcodeController()
        {
            telemetryClient = new TelemetryClient();
        }

        // GET api/barcode
        public async Task<List<Beer>> Get(string upc)
        {
            var properties = new Dictionary<string, string>();
            properties.Add("UPC", upc);
            telemetryClient.TrackEvent("LookupBarcode", properties);

            try
            {
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
    }
}