
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;
using BeerDrinkin.Service.DataObjects;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.Mobile.Server;
using Xamarin;

namespace BeerDrinkin.Service.Helpers
{
    public static class BreweryDBHelper
    {
        private static MobileAppSettingsDictionary settings;
        private static ITraceWriter tracer;

        public static bool InsureBreweryDbIsInitialized(MobileAppSettingsDictionary appSettings, ITraceWriter logger)
        {
            settings = appSettings;
            tracer = logger;

            if (string.IsNullOrEmpty(BreweryDB.BreweryDBClient.ApplicationKey))
            {
                string apiKey;
                // Try to get the BreweryDB API key  app settings.  
                if (!(settings.TryGetValue("BREWERYDB_API_KEY", out apiKey)))
                {
                    tracer.Error("Could not retrieve BreweryDB API key.");
                    return false;
                }
                tracer.Info($"BreweryDB API Key {apiKey}");
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
            try
            {
                if (beer == null)
                {
                    beer = new Beer
                    {
                        Id = breweryDbBeer.Id,
                        BreweryDbId = breweryDbBeer.Id,

                        Name = breweryDbBeer?.Name,
                        Description = breweryDbBeer?.Description,
                        ABV = breweryDbBeer?.Abv
                    };
                }

                //Check for BreweryData
                if (breweryDbBeer.Breweries != null || breweryDbBeer.Breweries.Count > 0)
                {
                    var breweryDbBrewery = breweryDbBeer?.Breweries?.FirstOrDefault();
                    if (breweryDbBrewery != null)
                    {
                        var brewery = new Brewery();
                        brewery.Name = breweryDbBrewery?.Name;
                        brewery.Description = breweryDbBrewery?.Description;
                        if(breweryDbBrewery.Image != null)
                            brewery.ImageUrls = new Images()
                            {
                                Icon = breweryDbBrewery.Image?.Icon,
                                Medium = breweryDbBrewery.Image?.Medium,
                                Large = breweryDbBrewery.Image?.Large
                            };

                        brewery.IsOrganic = breweryDbBrewery?.IsOrganic == "Y";
                        brewery.Website = breweryDbBrewery?.Website;
                        beer.Brewery = brewery;
                    }
                }

                beer.ABV = breweryDbBeer?.Abv;
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
            catch (Exception ex)
            {
                telemetry.TrackException(ex);
            }
            return null;
        }

        private static readonly Microsoft.ApplicationInsights.TelemetryClient telemetry =
            new Microsoft.ApplicationInsights.TelemetryClient(TelemetryConfiguration.Active);
    }
}
