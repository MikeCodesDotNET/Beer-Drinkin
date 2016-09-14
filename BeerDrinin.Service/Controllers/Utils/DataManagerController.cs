using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using BeerDrinkin.Service.Indentity;
using BeerDrinkin.Service.Models;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;

namespace BeerDrinin.Service.Controllers
{
    [MobileAppController]
    public class DataManagerController : ApiController
    {
        readonly TelemetryClient telemtryClient = new TelemetryClient();
        private static readonly string apiKey = ConfigurationManager.AppSettings["BreweryDbApiKey"];

        [AdminAuthorize][HttpGet]
        [Route("api/database/manager/beers/populate")]
        public async Task<bool> PopulateBeers()
        {
            try
            {
                var breweryDbClient = new BreweryDB.BreweryDbClient(apiKey);
                var response = await breweryDbClient.Beers.GetAll();
                var pageCount = response.NumberOfPages;
                var i = 0;
                while (i != pageCount)
                {
                    response = await breweryDbClient.Beers.GetAll(i);
                    foreach (var beer in response.Data)
                    {
                        var context = new MobileServiceContext();
                        var beerConverter = new BeerDrinkin.Converters.BeerConverter();
                        var convertedBeer = await beerConverter.ConvertBeerById(beer, true);
                        context.Beer.Add(convertedBeer);
                        context.SaveChanges();
                    }
                    i++;
                }
                return true;
            }
            catch (Exception ex)
            {
                telemtryClient.TrackException(ex);
                return false;
            }
        }
    }
}
