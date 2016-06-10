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
    public class TrendsService : ITrendsService
    {
        IAzureClient azure;
        public TrendsService()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
        }
              

        public async Task<List<Beer>> TrendingBeers(int takeCount)
        {
            if (azure != null)
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("takeCount", takeCount.ToString());

                return await azure.Client.InvokeApiAsync<List<Beer>>("TrendingBeers", HttpMethod.Get, parameters);
            }
            throw new NullReferenceException("Azure Client is null");
        }
            
    }
}

