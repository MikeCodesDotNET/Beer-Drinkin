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
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class BarcodeController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/UPC
        public List<Beer> Get(string upc)
        {
            Services.Log.Info(string.Format("Searching for Barcode number: {0}", upc));

            BeerDrinkinContext context = new BeerDrinkinContext();
            var beers = context.Beers.Where(x => x.UPC == upc).ToList();
            return beers;
        }

    }
}
