using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BeerDrinkin.AzureClient;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;

namespace BeerDrinkin.Services.Azure
{
    public class BarcodeService : IBarcodeService
    {
        IAzureClient azure;
        public BarcodeService()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
        }

        public async Task<List<Beer>> LookupBarcode(string upc)
        {
            if (azure == null)
                throw new NullReferenceException("Azure client is null");
            
            var parameters = new Dictionary<string, string>();
            parameters.Add("upc", upc);

            return await azure.Client.InvokeApiAsync<List<Beer>>("Search", HttpMethod.Get, parameters);
        }
    }
}

