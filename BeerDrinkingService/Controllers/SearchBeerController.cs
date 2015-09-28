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
using BeerDrinkin.Service.Utils;

namespace BeerDrinkin.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class SearchBeerController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/SearchBeer
        public async Task<List<BeerItem>> Get(string keyword)
        {
            Services.Log.Info(string.Format("Search beer call with keyword {0}",keyword));
            var rv = new List<BeerItem>();

            if (!BreweryDBHelper.InsureBreweryDBIsInitialized(Services))
                return rv;

            try
            {
                var results = await new BreweryDB.BreweryDBClient().SearchForBeer(keyword);
                if (results != null && results.Any())
                {
                    Services.Log.Info(string.Format("Found {0} beers", results.Count()));

                    var context = new BeerDrinkinContext();
                    bool needSave = false;
                    foreach (var r in results)
                    {
                        Services.Log.Info(string.Format("proceeding {0} beer", r.Name));
                        //check if we already have beer in db
                        var beer = context.BeerItems.FirstOrDefault(f => f.BreweryDBId == r.Id);
                        if (beer == null)
                        {
                            Services.Log.Info(string.Format("Beer {0} wasn't logged yet", r.Name));
                            needSave = true;
                            try
                            {
                                beer = r.ToBeerItem();

                                if (r.Style != null)
                                {
                                    var style = context.BeerStyles.FirstOrDefault(f => f.Name == r.Style.Name);
                                    if (style == null)
                                    {
                                        style = r.Style.ToBeerStyle();
                                        context.BeerStyles.Add(style);
                                    }
                                    beer.StyleId = style.Id;
                                }
                                context.BeerItems.Add(beer);
                            }
                            catch (Exception ex)
                            {
                                Services.Log.Error(string.Format("Exception creating beer: {0}", ex.Message));
                            }
                        }
                        rv.Add(beer);
                    }
                    if (needSave)
                        await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Services.Log.Error(ex.Message);
            }

            return rv;
        }

    }
}
