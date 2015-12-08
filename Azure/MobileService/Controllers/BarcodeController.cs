using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Tracing;
using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.DataObjects;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using NLog.Fluent;

namespace BeerDrinkin.Service.Controllers
{
    [MobileAppController]
    public class BarcodeController : ApiController
    {
        private MobileAppSettingsDictionary settings;
        private readonly ITraceWriter tracer;

        public BarcodeController()
        {   
            settings = Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            tracer = Configuration.Services.GetTraceWriter();
        }

        // GET api/UPC
        public List<Beer> Get(string upc)
        {
            tracer.Info($"Searching for Barcode number: {upc}");
            ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();

            BeerDrinkinContext context = new BeerDrinkinContext();
            var beers = context.Beers.Where(x => x.UPC == upc).ToList();
            return beers;
        }

    }
}
