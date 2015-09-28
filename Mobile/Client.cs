using System;
using Akavache;
using BeerDrinkin.API;
using BeerDrinkin.Core.Helpers;
using BeerDrinkin.Service.DataObjects;
using Connectivity.Plugin;
using Polly;
using System.Threading.Tasks;

namespace BeerDrinkin
{
    public sealed class Client
    {
        static readonly Lazy<Client> lazy =
            new Lazy<Client>(() => new Client());

        public static Client Instance { get { return lazy.Value; } }

        Client()
        {
            BeerDrinkinClient = new APIClient(Keys.ServiceUrl, Keys.ServiceKey);

            BlobCache.ApplicationName = "BeerDrinkin";

            //Make sure we keep everything in sync!
            CrossConnectivity.Current.ConnectivityChanged += async (sender, e) =>
            {
                //If we lost connectivity to the server and we've now got connected, lets try and sync! 
                
                if (e.IsConnected)
                {
                    await Policy  
                        .Handle<Exception>()
                        .WaitAndRetryAsync
                        (5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                    )
                        .ExecuteAsync(async () => await BeerDrinkinClient.RefreshAll());
                }
            };
        }

        public APIClient BeerDrinkinClient;
    }
}

