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
    public class SearchService : ISearchService
    {
        IAzureClient azure;
        public SearchService()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
        }

        public async Task<List<Beer>> Search(string searchTerm)
        {
            if (azure != null)
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("searchTerm", searchTerm);

                return await azure.Client.InvokeApiAsync<List<Beer>>("Search", HttpMethod.Get, parameters);
            }
            throw new NullReferenceException("Azure Client is null");
        }
    }
}

