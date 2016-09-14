using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;

namespace BreweryDB.Converter
{
    public class BeerConverter
    {
        private string apiKey;
        private string storageConnectionString;

        public BeerConverter(string apiKey, string storageConnectionString ="")
        {
            this.apiKey = apiKey;
            this.storageConnectionString = storageConnectionString;
        }

        public async Task<Beer> ConvertBeerById(string id, bool saveImages)
        {
            var client = new BreweryDbClient(apiKey);

            //Beer
            var beerResponse = await client.Beers.Get(id);
            var dbBeer = beerResponse.Data;

            if (dbBeer == null)
                return null;

            var beer = new Beer();
            beer.Name = dbBeer.Name;
            beer.Description = dbBeer.Description;

            //Brewery
            if (dbBeer.Breweries != null || dbBeer.Breweries.Count > 0)
            {
                var dbBrewery = dbBeer.Breweries.FirstOrDefault();
                beer.BreweryId = dbBrewery?.Id;

                if (dbBrewery?.Locations != null || dbBrewery.Locations.Count > 0)
                {
                    foreach (var location in dbBrewery.Locations)
                    {
                        beer.OriginCountry = location.Country.DisplayName;
                        break;
                    }
                }
            }

            beer.Abv = dbBeer.Abv;
            beer.BreweryDbId = dbBeer.Id;

            //Style
            var styleConverter = new StyleConverter(apiKey);
            beer.Style = await styleConverter.ConvertStyleById(dbBeer.StyleId.ToString());
            beer.StyleId = dbBeer.StyleId.ToString();

            //Images
            if (dbBeer.Labels != null)
            {
                Image image;
                //We'll be saving these images to our db
                if (saveImages)
                {
                    var imageConverter = new ImageConverter();
                    image = await imageConverter.ConvertLabel(dbBeer.Labels, storageConnectionString);

                }
                else //Lets keep it hosted by BreweryDB
                {
                    image = new Image
                    {
                        SmallUrl = dbBeer.Labels.Icon,
                        MediumUrl = dbBeer.Labels.Medium,
                        LargeUrl = dbBeer.Labels.Large
                    };
                }
                beer.Images = new List<Image> {image};
            }

            return beer;
        
        }

    }
}
