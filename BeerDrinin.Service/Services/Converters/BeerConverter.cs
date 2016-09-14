using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Converters
{
    public class BeerConverter
    {
        public async Task<Beer> ConvertBeerById(BreweryDB.Models.Beer dbBeer, bool saveImages)
        {
            if (dbBeer == null)
                return null;

            var beer = new Beer
            {
                Name = dbBeer.Name,
                Description = dbBeer.Description
            };

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
            var styleConverter = new StyleConverter();
            beer.Style = await styleConverter.Convert(dbBeer.Style);
            beer.StyleId = dbBeer.StyleId.ToString();

            //Images
            if (dbBeer.Labels != null)
            {
                Image image;
                //We'll be saving these images to our db
                if (saveImages)
                {
                    var imageConverter = new ImageConverter();
                    image = await imageConverter.ConvertLabel(dbBeer.Labels, dbBeer.Id);
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
