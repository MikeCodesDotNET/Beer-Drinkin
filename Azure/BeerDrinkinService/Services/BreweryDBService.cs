using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Services
{
    public class BreweryDBService
    {
        BreweryDB.BreweryDbClient client;
        public BreweryDBService()
        {
            client = new BreweryDB.BreweryDbClient("a956af587b434c4c89ef18c7bbd2fac9");
        }

        public async Task<Beer> GetBeer(string id)
        {
            var response = await client.Beers.Get(id);
            var dbBeer = response.Data;            
            return ToBeerDrinkin(dbBeer);
        }

        public async Task<List<Beer>> SearchBeers(string searchTerm)
        {
            var response = await client.Beers.Search(searchTerm);
            var breweryDbBeers = response.Data;
            var beers = new List<Beer>();

            foreach(var beer in breweryDbBeers)
            {
                var b = ToBeerDrinkin(beer);
                beers.Add(b);
            }

            return beers;
        }

        public async Task<List<Beer>> GetFeatured(int takeCount = 10)
        {
            var response = await client.Features.GetAll();
            var beers = new List<Beer>();

            foreach(var feature in response.Data)
            {
                beers.Add(ToBeerDrinkin(feature.Beer));
            }
            var featured = beers.Take(takeCount);
            return featured.ToList();
        }

        Beer ToBeerDrinkin(BreweryDB.Interfaces.IBeer dbBeer)
        {
            var beer = new Beer()
            {
                Id = dbBeer.Id,
                Name = dbBeer.Name,
                BreweryDbId = dbBeer.Id,
                Description = dbBeer.Description,
                Brewery = dbBeer.Brewery,
                BreweryId = dbBeer?.Breweries?.FirstOrDefault().Id,
                StyleId = dbBeer.StyleId.ToString(),
                Abv = dbBeer.Abv,
                ImageSmall = dbBeer?.Labels?.Icon,
                ImageMedium = dbBeer?.Labels?.Medium,
                ImageLarge = dbBeer?.Labels?.Large
            };
            return beer;
        }
    }
}