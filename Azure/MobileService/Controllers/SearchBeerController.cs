using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Utils;
using BeerDrinkin.Service.Helpers;

namespace BeerDrinkin.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class SearchBeerController : ApiController
    {
        public ApiServices Services { get; set; }
        BeerDrinkinContext context = new BeerDrinkinContext();

        // GET api/SearchBeer
        public async Task<List<Beer>> Get(string keyword)
        {
            Services.Log.Info(string.Format("Search beer call with keyword {0}",keyword));
            var rv = new List<Beer>();
            bool needSave = false;

            if (!BreweryDBHelper.InsureBreweryDbIsInitialized(Services))
                return rv;

            try
            {
                var results = await new BreweryDB.BreweryDBClient().SearchForBeer(keyword);

                if (results != null && results.Any())
                {
                    Services.Log.Info(string.Format("Found {0} beers", results.Count()));

                    var context = new BeerDrinkinContext();
                    foreach (var r in results)
                    {
                        //check if we already have beer in db
                        var beer = context.Beers.FirstOrDefault(f => f.BreweryDbId == r.Id);
                        if (beer == null)
                        {
                            Services.Log.Info(string.Format("Beer {0} wasn't logged yet", r.Name));
                            needSave = true;
                            try
                            {
                                beer = r.ToBeerItem();
                                
                                context.Beers.Add(beer);
                            }
                            catch (Exception ex)
                            {
                                Services.Log.Error(string.Format("Exception creating beer: {0}", ex.Message));
                            }
                        }                        
                        rv.Add(beer);
                    }                    
                }
            }
            catch (Exception ex)
            {
                Services.Log.Error(ex.Message);
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
