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
        Client client;

        public BeerResource(Client client)
        {
            this.client = client;
        }

        async public Task<List<BeerItem>> Search(string keyword)
        {
            var table = client.AzureClient.GetSyncTable<BeerStyle>();
            var checkInTable = client.AzureClient.GetSyncTable<CheckInItem>();

            var results = new List<BeerItem>();
            var parameters = new Dictionary<string, string>();
            parameters.Add("keyword", keyword);
          
            results = await client.AzureClient.InvokeApiAsync<List<BeerItem>>("SearchBeer", HttpMethod.Get, parameters);
            if (results != null && results.Any())
            {                      
                //sync db to update new beers && styles
                await client.SyncAsync<BeerItem>("allUsers");
                await client.SyncAsync(table, "allUsers");
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

