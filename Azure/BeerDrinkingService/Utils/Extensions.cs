using BeerDrinkin.Service.DataObjects;
using BreweryDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.Service.Utils
{
    public static class Extensions
    {
        public static BeerStyle ToBeerStyle(this Style style)
        {
            var beerStyle = new BeerStyle 
            {
                Id=Guid.NewGuid().ToString("N"),
                AbvMax=style.AbvMax,
                AbvMin=style.AbvMin,
                Description=style.Description,
                FgMax=style.FgMax,
                FgMin=style.FgMin,
                IbuMax=style.IbuMax,
                IbuMin=style.IbuMin,
                Name=style.Name,
                OgMin=style.OgMin,
                ShortName=style.ShortName,
                SrmMax=style.SrmMax,
                SrmMin=style.SrmMin
            };
            if (style.Category != null)
                beerStyle.Category = style.Category.Name;
            return beerStyle;
        }
        
        public static BeerItem ToBeerItem(this Beer beer, BeerItem beerItem = null)
        {
            if (beerItem == null)
            {
                beerItem = new BeerItem
                {
                    Id = beer.Id,
                    BreweryDBId = beer.Id,
                };
            }

            beerItem.Name = beer.Name;
            beerItem.Description = beer.Description;
            if (beer.Breweries!=null && beer.Breweries.Any())
                beerItem.Brewery = beer.Brewery;
            
            beerItem.ABV = beer.Abv;
            if (beer.Labels != null)
            {
                beerItem.Icon = beer.Labels.Icon;
                beerItem.Medium = beer.Labels.Medium;
                beerItem.Large = beer.Labels.Large;
            }
            return beerItem;
        }
    }
}
