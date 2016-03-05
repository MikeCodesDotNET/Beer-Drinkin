using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Service.Helpers
{
    public class BreweryDbTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context,
      Type sourceType)
        {

            if (sourceType == typeof(BreweryDB.Models.Beer))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
           CultureInfo culture, object value)
        {
            if (value is BreweryDB.Models.Beer)
            {
                var breweryDBBeer = value as BreweryDB.Models.Beer;
                var beer = new Beer();
                beer.Name = breweryDBBeer.Name;
                beer.Description = breweryDBBeer.Description;
                beer.Abv = Convert.ToDouble(breweryDBBeer.Abv.ToString(CultureInfo.InvariantCulture));
                beer.Brewery = breweryDBBeer.Brewery;
                beer.BreweryDbId = breweryDBBeer.Id;
                var firstOrDefault = breweryDBBeer.Breweries.FirstOrDefault();
                if (firstOrDefault != null)
                    beer.BreweryId = firstOrDefault.Id;
                beer.ImageLarge = breweryDBBeer.Labels.Large;
                beer.ImageMedium = breweryDBBeer.Labels.Medium;
                beer.ImageSmall = breweryDBBeer.Labels.Icon;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
           CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Beer))
            {
                if (value is BreweryDB.Models.Beer)
                {
                    var breweryDBBeer = value as BreweryDB.Models.Beer;
                    var beer = new Beer();
                    beer.Name = breweryDBBeer.Name;
                    beer.Description = breweryDBBeer.Description;
                    beer.Abv = Convert.ToDouble(breweryDBBeer.Abv.ToString(CultureInfo.InvariantCulture));
                    beer.Brewery = breweryDBBeer.Brewery;
                    beer.BreweryDbId = breweryDBBeer.Id;
                    var firstOrDefault = breweryDBBeer.Breweries.FirstOrDefault();
                    if (firstOrDefault != null)
                        beer.BreweryId = firstOrDefault.Id;
                    beer.ImageLarge = breweryDBBeer.Labels.Large;
                    beer.ImageMedium = breweryDBBeer.Labels.Medium;
                    beer.ImageSmall = breweryDBBeer.Labels.Icon;
                }
                return base.ConvertFrom(context, culture, value);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}