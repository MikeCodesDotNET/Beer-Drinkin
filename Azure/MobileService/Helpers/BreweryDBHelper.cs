using Microsoft.WindowsAzure.Mobile.Service;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.Service.Helpers
{
    public static class BreweryDBHelper
    {
        public static bool InsureBreweryDbIsInitialized(ApiServices services)
        {
            if (string.IsNullOrEmpty(BreweryDB.BreweryDBClient.ApplicationKey))
            {
                string apiKey;
                // Try to get the BreweryDB API key  app settings.  
                if (!(services.Settings.TryGetValue("BREWERYDB_API_KEY", out apiKey)))
                {
                    services.Log.Error("Could not retrieve BreweryDB API key.");
                    return false;
                }
                services.Log.Info($"BreweryDB API Key {apiKey}");
                BreweryDB.BreweryDBClient.Initialize(apiKey);
            }
            return true;
        }

        public static Style ToBeerStyle(this BreweryDB.Models.Style style)
        {
            var beerStyle = new Style
            {
                Id = Guid.NewGuid().ToString("N"),
                AbvMax = style.AbvMax,
                AbvMin = style.AbvMin,
                Description = style.Description,
                FgMax = style.FgMax,
                FgMin = style.FgMin,
                IbuMax = style.IbuMax,
                IbuMin = style.IbuMin,
                Name = style.Name,
                OgMin = style.OgMin,
                ShortName = style.ShortName,
                SrmMax = style.SrmMax,
                SrmMin = style.SrmMin
            };
            if (style.Category != null)
                beerStyle.Category = new Category { Name = style.Name };
                    
            return beerStyle;
        }

        public static Beer ToBeerItem(this BreweryDB.Models.Beer breweryDbBeer, Beer beer = null)
        {
            if (beer == null)
            {
                beer = new Beer
                {
                    Id = breweryDbBeer.Id,
                    BreweryDbId = breweryDbBeer.Id,

                    Name = breweryDbBeer.Name,
                    Description = breweryDbBeer.Description,
                    ABV = breweryDbBeer.Abv
                };
            }

            //Check for BreweryData
            if (breweryDbBeer.Breweries != null || breweryDbBeer.Breweries.Count > 0)
            {
                var brewery = breweryDbBeer.Breweries.FirstOrDefault();
                if (brewery != null)
                {
                    beer.Brewery.Name = breweryDbBeer.Name;
                    beer.Brewery.Description = brewery.Description;
                    beer.Brewery.ImageUrls = new Images()
                    {
                        Icon = brewery.Image?.Icon,
                        Medium = brewery.Image?.Medium,
                        Large = brewery.Image?.Large
                    };
                    beer.Brewery.IsOrganic = brewery.IsOrganic == "Y";
                    beer.Brewery.Website = brewery.Website;
                }
            }

            beer.ABV = breweryDbBeer.Abv;
            if (breweryDbBeer.Labels == null) return beer;

            var images = new Images()
            {
                Icon = breweryDbBeer.Labels.Icon,
                Medium = breweryDbBeer.Labels.Medium,
                Large = breweryDbBeer.Labels.Large
            };
            beer.Images = images;

            return beer;
        }
    }
}
