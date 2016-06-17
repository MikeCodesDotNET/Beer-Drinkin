using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;
using Microsoft.ApplicationInsights;

namespace BeerDrinkin.Services
{
    public class BreweryDBService
    {
        BreweryDB.BreweryDbClient client;
        TelemetryClient telemetryClient;

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

        public async Task<Brewery> GetBrewery(string id)
        {
            var response = await client.Breweries.Get(id);
            var brewery = ToBeerDrinkin(response.Data);
            return brewery;
        }

        //Beer Converter 
        Beer ToBeerDrinkin(BreweryDB.Interfaces.IBeer dbBeer)
        {
            try
            {
                var beer = new Beer()
                {
                    Id = dbBeer.Id,
                    Name = dbBeer.Name,
                    BreweryDbId = dbBeer.Id,
                    Description = dbBeer.Description,
                    Abv = dbBeer.Abv
                };

                if (dbBeer.Labels != null)
                {
                    var image = new Image
                    {
                        SmallUrl = dbBeer?.Labels?.Icon,
                        MediumUrl = dbBeer?.Labels?.Medium,
                        LargeUrl = dbBeer?.Labels?.Large
                    };
                    beer.Image = image;
                }

                if (dbBeer.Breweries.Count != 0)
                {
                    var dbBrewery = dbBeer.Breweries.FirstOrDefault();
                    beer.Brewery = ToBeerDrinkin(dbBrewery);
                }

                return beer;
            }
            catch (Exception ex)
            {
                telemetryClient.TrackException(ex);
                return null;
            }
        }

        //Brewery Converter
        Brewery ToBeerDrinkin(BreweryDB.Interfaces.IBrewery dbBrewery)
        {
            try
            {
                var brewery = new Brewery();
                brewery.Name = dbBrewery.Name;
                brewery.Description = dbBrewery.Description;
                brewery.Id = dbBrewery.Id;
                brewery.Website = dbBrewery.Website;
                if (dbBrewery.Image != null)
                {
                    var image = new Image
                    {
                        LargeUrl = dbBrewery.Image.Large,
                        MediumUrl = dbBrewery.Image.Medium,
                        SmallUrl = dbBrewery.Image.Icon
                    };
                    brewery.Image = image;
                }

                return brewery;
            }
            catch (Exception ex)
            {
                telemetryClient.TrackException(ex);
                return null;
            }
        }
    }
}