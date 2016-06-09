using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;
using Microsoft.ApplicationInsights;

namespace BeerDrinkin.Controllers
{
    [MobileAppController]
    public class TrendingBeersController : ApiController
    {
        TelemetryClient telemetryClient = new TelemetryClient();

        // GET api/UserInfo
        public async Task<List<Beer>> Get(int takeCount)
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