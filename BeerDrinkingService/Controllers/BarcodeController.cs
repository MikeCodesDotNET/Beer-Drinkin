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

namespace BeerDrinkin.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class BarcodeController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/beer
        public async Task<List<BeerItem>> Get(string upc)
        {
            BeerDrinkinContext context = new BeerDrinkinContext();
            var beers = context.BeerItems.Where(x => x.UPC == upc).ToList();

            return beers;
        }

    }
}
