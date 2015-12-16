using System;
using BeerDrinkin.API;
using BeerDrinkin.Core.Helpers;
using BeerDrinkin.Service.DataObjects;
using Plugin.Connectivity;
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
            BeerDrinkinClient = new APIClient(Keys.ServiceUrl);
        }

        public APIClient BeerDrinkinClient;
    }
}

