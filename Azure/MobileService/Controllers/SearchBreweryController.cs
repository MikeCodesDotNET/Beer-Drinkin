using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Web.Http.Tracing;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Helpers;

using BeerDrinkin.Service.Models;
using Microsoft.Azure.Mobile.Server;

namespace BeerDrinkin.Service.Controllers
{
    
    public class SearchBreweryController : ApiController
    {
        private readonly MobileAppSettingsDictionary settings;
        private readonly ITraceWriter tracer;

        public SearchBreweryController()
        {
            settings = Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            tracer = Configuration.Services.GetTraceWriter();
        }

        // GET api/SearchBeer
        public async Task<List<Brewery>> Get(string keyword)
        {
            tracer.Info(string.Format("Search brewery call with keyword {0}",keyword));
            var rv = new List<Brewery>();

            if (!BreweryDBHelper.InsureBreweryDbIsInitialized(settings, tracer))
                return rv;

            try
            {
                var results = await new BreweryDB.BreweryDBClient().SearchForBeer(keyword);
                if (results != null && results.Any())
                {
                    foreach (var r in results)
                    {
                        var brewery = new Brewery 
                        { 
                             Id=r.Id,
                             Name=r.Name,
                             Description=r.Description
                        };
                        rv.Add(brewery);
                    }
                }
            }
            catch (Exception ex)
            {
                tracer.Error(ex.Message);
            }

            return rv;
        }

    }
}
