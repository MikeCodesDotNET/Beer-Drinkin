using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using System.Globalization;
using System.Diagnostics;
using Microsoft.Azure.Mobile.Server.Config;

namespace BeerDrinkin.Controllers
{
    [MobileAppController]
    public class BreweryDbManagerController : ApiController
    {
        // GET api/BreweryDbManager
        public string Get()
        {
            var client = new BreweryDB.BreweryDbClient("a956af587b434c4c89ef18c7bbd2fac9");
            var pageCount = client.Beers.GetAll().Result.NumberOfPages;
            var i = 0;

            var context = new Models.BeerDrinkinContext();

            while (i != pageCount)
            {
                var beers = client.Beers.GetAll(i).Result.Data;
                foreach (var beer in beers)
                {
                    var myBeer = new DataObjects.Beer();

                    myBeer.Name = beer.Name;
                    myBeer.Description = beer.Description;
                    myBeer.Abv = Convert.ToDouble(beer.Abv.ToString(CultureInfo.InvariantCulture));
                    myBeer.Brewery = beer.Brewery;
                    myBeer.BreweryDbId = beer.Id;

                    var firstOrDefault = beer.Breweries.FirstOrDefault();
                    if (firstOrDefault != null)
                        myBeer.BreweryId = firstOrDefault.Id;

                    myBeer.ImageLarge = beer.Labels.Large;
                    myBeer.ImageMedium = beer.Labels.Medium;
                    myBeer.ImageSmall = beer.Labels.Icon;

                    context.Beers.Add(myBeer);
                    context.SaveChanges();
                }
                i++;
            }
            return "Complete";
        }
    }
}
