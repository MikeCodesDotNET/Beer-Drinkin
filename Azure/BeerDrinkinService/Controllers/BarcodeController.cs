using BeerDrinkin.DataObjects;
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
        // GET api/barcode
        public async Task<List<Beer>> Get(string upc)
        {
            var rateBeerClient = new RateBeer.Client();
            var results = await rateBeerClient.SearchForBeer(upc);
            if (results == null)
                return null;

            var breweryDbService = new Services.BreweryDBService();
            return await breweryDbService.SearchBeers(results.BeerName);  
        }
    }
}