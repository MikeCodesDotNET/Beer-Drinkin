using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Threading.Tasks;
using System.Web.Http.Tracing;
using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Utils;
using BeerDrinkin.Service.Helpers;
using Microsoft.Azure.Mobile.Server;

namespace BeerDrinkin.Service.Controllers
{
    public class SearchBeerController : ApiController
    {
        private readonly MobileAppSettingsDictionary settings;
        private readonly ITraceWriter tracer;

        public SearchBeerController()
        {
            settings = Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            tracer = Configuration.Services.GetTraceWriter();
        }


        BeerDrinkinContext context = new BeerDrinkinContext();

        // GET api/SearchBeer
        public async Task<List<Beer>> Get(string keyword)
        {
            tracer.Info(string.Format("Search beer call with keyword {0}",keyword));
            var rv = new List<Beer>();
            bool needSave = false;

            if (!BreweryDBHelper.InsureBreweryDbIsInitialized(settings, tracer))
                return rv;

            try
            {
                var results = await new BreweryDB.BreweryDBClient().SearchForBeer(keyword);

                if (results != null && results.Any())
                {
                    tracer.Info(string.Format("Found {0} beers", results.Count()));

                    var context = new BeerDrinkinContext();
                    foreach (var r in results)
                    {
                        //check if we already have beer in db
                        var beer = context.Beers.FirstOrDefault(f => f.BreweryDbId == r.Id);
                        if (beer == null)
                        {
                            tracer.Info(string.Format("Beer {0} wasn't logged yet", r.Name));
                            needSave = true;
                            try
                            {
                                beer = r.ToBeerItem();
                                
                                context.Beers.Add(beer);
                            }
                            catch (Exception ex)
                            {
                                tracer.Error(string.Format("Exception creating beer: {0}", ex.Message));
                            }
                        }                        
                        rv.Add(beer);
                    }                    
                }
            }
            catch (Exception ex)
            {
                tracer.Error(ex.Message);
            }
            finally
            {
                if (needSave)
                    await context.SaveChangesAsync();
            }

            return rv;
        }

    }
}
