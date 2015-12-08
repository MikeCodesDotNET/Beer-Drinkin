using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Tracing;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.Utils;
using BreweryDB;
using Microsoft.Azure.Mobile.Server;


namespace BeerDrinkin.Service.Controllers
{
    public class PopularBeersController : ApiController
    {
        private readonly MobileAppSettingsDictionary settings;
        private readonly ITraceWriter tracer;

        public PopularBeersController()
        {
            settings = Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            tracer = Configuration.Services.GetTraceWriter();
        }

        // GET api/PopularBeers
        public async Task<List<Beer>> Get(double longitude, double latitude)
        {
            //Find the current country of the user
            string bingKey;
            if (!(settings.TryGetValue("BING_API_KEY", out bingKey)))
            {
                tracer.Error("Could not retrieve Bing API key.");
                bingKey = "AlPB42X199-b_n7tnHPSNM15E4cvLv18hfj4upv3irWgSFHx5GplSaOS3wpggCox";
            }
            tracer.Info($"Bing API Key{bingKey}"); 
           
            return null;
        }
    }
}