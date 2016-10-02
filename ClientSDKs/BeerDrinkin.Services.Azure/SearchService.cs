using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BeerDrinkin.AzureClient;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Services.Abstractions;
using BeerDrinkin.Utils;

namespace BeerDrinkin.DataStore.Azure
{
    public class SearchService : ISearchService
    {
        readonly IAzureClient azure;
        public SearchService()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
        }

        public async Task<List<Beer>> Search(string searchTerm)
        {

			try
			{
				if (azure == null) throw new NullReferenceException("Azure Client is null");

				var parameters = new Dictionary<string, string> { { "searchTerm", searchTerm } };
				return await azure.Client.InvokeApiAsync<List<Beer>>("search/beers", HttpMethod.Get, parameters);
			}
			catch (Exception ex)
			{
				Xamarin.Insights.Report(ex, Xamarin.Insights.Severity.Critical);
				return new List<Beer>();
			}
        }
    }
}

