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

namespace BeerDrinkin.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class SearchBreweryController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/SearchBeer
        public async Task<List<Brewery>> Get(string keyword)
        {
            Services.Log.Info(string.Format("Search brewery call with keyword {0}",keyword));
            var rv = new List<Brewery>();

            if (!BreweryDBHelper.InsureBreweryDBIsInitialized(Services))
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
                Services.Log.Error(ex.Message);
            }

            return rv;
        }

    }
}
