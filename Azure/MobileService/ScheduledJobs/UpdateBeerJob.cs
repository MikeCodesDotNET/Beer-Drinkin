using System.Threading.Tasks;
using System.Web.Http;

using BeerDrinkin.Service.Models;
using System.Linq;
using BeerDrinkin.Service.Helpers;
using BeerDrinkin.Service.Utils;

namespace BeerDrinkin.Service
{
    // A simple scheduled job which can be invoked manually by submitting an HTTP
    // POST request to the path "/jobs/UpdateBeer".

        //TODO This can be replaced as we'll use the BreweryDB webhooks to find any beers that require updating. 
    public class UpdateBeerJob : ScheduledJob
    {
        public async override Task ExecuteAsync()
        {
            Services.Log.Info("Hello from scheduled job!");

            if (!BreweryDBHelper.InsureBreweryDbIsInitialized(Services))
            {
                Services.Log.Error("Could not init BreweryDB API");
                return;
            }

            Services.Log.Info("BreweryDB is initialized");

            var context = new BeerDrinkinContext();

            foreach (var beerItem in context.Beers)
            {
                Services.Log.Info("updating beer " + beerItem.Name);
                var beer = await new BreweryDB.BreweryDBClient().QueryBeerById(beerItem.Id);
                if (beer == null)
                {
                    Services.Log.Error(string.Format("Could not get beer {0} with id {1}", beerItem.Name, beerItem.BreweryDbId) );
                    continue;
                }
                //this call updates beerItem form BreweryDB beer object
                var newBeerItem = beer.ToBeerItem(beerItem);
            }
            await context.SaveChangesAsync();
            
            Services.Log.Info("UpdateBeerJob is completed!");
        }
    }
}