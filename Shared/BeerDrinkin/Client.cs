using System;
using BeerDrinkin.API;
using BeerDrinkin.Core.Helpers;
using BeerDrinkin.Service.DataObjects;
using Plugin.Connectivity;
using Polly;
using System.Threading.Tasks;

namespace BeerDrinkin
{
    public sealed class ClientManager
    {
        static readonly Lazy<ClientManager> lazy =
            new Lazy<ClientManager> (() => new ClientManager ());

        public static ClientManager Instance { get { return lazy.Value; } }

        ClientManager ()
        {
            BeerDrinkinClient = new APIClient (Keys.ServiceUrl);
        }

        public APIClient BeerDrinkinClient;
    }
}

