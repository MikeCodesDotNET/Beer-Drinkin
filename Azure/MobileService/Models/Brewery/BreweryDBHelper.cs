using Microsoft.WindowsAzure.Mobile.Service;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.Service.Models
{
    public static class BreweryDBHelper
    {
        public static bool InsureBreweryDBIsInitialized(ApiServices services)
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
                services.Log.Info(string.Format("BreweryDB API Key {0}", apiKey));
                BreweryDB.BreweryDBClient.Initialize(apiKey);
            }
            return true;
        }
    }
}
