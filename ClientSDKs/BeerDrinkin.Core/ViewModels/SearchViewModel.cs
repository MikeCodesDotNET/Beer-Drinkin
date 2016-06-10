﻿using BeerDrinkin.AzureClient;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.Core.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        IAzureClient azure;

        public SearchViewModel()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
        }

        public async Task<List<Beer>> Search(string searchTerm)
        {
            if(azure != null)
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("searchTerm", searchTerm);

                return await azure.Client.InvokeApiAsync<List<Beer>>("Search", HttpMethod.Get, parameters);
            }
            else
            {
                throw new NullReferenceException("Azure Client is null");
            }
        }

        public async Task<List<Beer>> TrendingBeers(int takeCount = 10)
        {
            if (azure != null)
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("trendingSearch", takeCount.ToString());

                return await azure.Client.InvokeApiAsync<List<Beer>>("TrendingBeers", HttpMethod.Get, parameters);
            }
            else
            {
                throw new NullReferenceException("Azure Client is null");
            }
        }
    }
}
