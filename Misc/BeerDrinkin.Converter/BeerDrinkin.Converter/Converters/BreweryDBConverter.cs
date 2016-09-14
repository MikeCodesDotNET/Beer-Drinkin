using BeerDrinkin.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.Converter
{
    public class BreweryDBConverter
    {
        public Beer ConverterBeer(BreweryDB.Models.Beer beer)
        {
            var b = new Beer
            {
                Name = beer.Name,
                Description = beer.Description,
                BreweryDbId = beer.Id,
                Images = new List<Image>()
            };

            if (beer.Labels != null)
            {
                var image = new Image
                {
                    BeerId = b.Id,
                    LargeUrl = beer.Labels.Large,
                    MediumUrl = beer.Labels.Medium,
                    SmallUrl = beer.Labels.Icon
                };
                b.Images.Add(image);
            }

            b.Abv = beer.Abv;
            if (beer.Breweries != null)
            {
                var breweryId = "";
                foreach (var brewery in beer.Breweries)
                {
                    breweryId = brewery.Id;
                }
                b.BreweryId = breweryId;
            }
            b.StyleId = beer.StyleId.ToString();
            return b;
        }
    }
}
