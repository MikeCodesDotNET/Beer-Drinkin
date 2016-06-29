using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;
using Microsoft.ApplicationInsights;
using BeerDrinkin.Service.Helpers;

namespace BeerDrinkin.Controllers
{
    [MobileAppController]
    public class TrendingBeersController : ApiController
    {
        TelemetryClient telemetryClient = new TelemetryClient();

        [QueryableExpand("Brewery, Style, Image")]
        public async Task<List<Beer>> Get(int takeCount, double longitude = 0, double latitude = 0)
        {
            telemetryClient.TrackEvent("GetTrendingBeers");
            try
            {
                var breweryDb = new Services.BreweryDBService();
                var featuredBeers = await breweryDb.GetFeatured();
                return featuredBeers.Take(takeCount).ToList();
            }
            catch(Exception ex)
            {
                telemetryClient.TrackException(ex);
                return new List<Beer>();
            }
        }

    }
}