using BeerDrinkin.AzureClient;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataStore.Abstractions;

namespace BeerDrinkin.Core.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        IAzureClient azure;
        ISearchService searchService;

        public SearchViewModel()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
            searchService = ServiceLocator.Instance.Resolve<ISearchService>();
        }

        public async Task<List<Beer>> Search(string searchTerm)
        {
            return await searchService.Search(searchTerm);
        }

        public async Task<List<Beer>> TrendingBeers(int takeCount = 10)
        {
            if (azure != null)
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("trendingSearch", takeCount.ToString());

                return await azure.Client.InvokeApiAsync<List<Beer>>("TrendingBeers", HttpMethod.Get, parameters);
            }
            throw new NullReferenceException("Azure Client is null");
        }
    }
}
