using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.Models;
using System.Net.Http;
using System.Linq;

namespace BeerDrinkin.Resources
{
    public class BeerResource
    {
        AzureClient azureClient;

        public BeerResource(AzureClient client)
        {
            this.azureClient = client;
        }

        async public Task<List<BeerItem>> Search(string keyword)
        {
            var table = azureClient.Client.GetSyncTable<BeerStyle>();
            var checkInTable = azureClient.Client.GetSyncTable<CheckInItem>();

            var results = new List<BeerItem>();
            var parameters = new Dictionary<string, string>();
            parameters.Add("keyword", keyword);
          
            results = await azureClient.Client.InvokeApiAsync<List<BeerItem>>("SearchBeer", HttpMethod.Get, parameters);
            if (results != null && results.Any())
            {                      
                //sync db to update new beers && styles
                await azureClient.SyncAsync<BeerItem>("allUsers");
                await azureClient.SyncAsync(table, "allUsers");
                return results;
            }
            return null;
        }

        async public Task<BeerItem> GetById(string keyword)
        {
            return null;
        }

        async public Task<bool> Create(BeerItem beerItem)
        {
            return false;
        }

        async public Task<bool> Update(BeerItem beerItem)
        {
            return false;
        }

        async public Task<bool> Delete(BeerItem beerItem)
        {
            return false;
        }

        async public Task<bool> Flag(BeerItem beerItem)
        {
            return false;
        }
    }
}

