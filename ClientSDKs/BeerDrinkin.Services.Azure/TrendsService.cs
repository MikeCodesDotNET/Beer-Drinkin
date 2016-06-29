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
    public class TrendsService : ITrendsService
    {
        IAzureClient azure;
        IAppInsights insights; 

        public TrendsService()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
            insights = ServiceLocator.Instance.Resolve<IAppInsights>();
        }

        public async Task<List<Beer>> TrendingBeers(int takeCount, double longittude, double latitude)
        {
            if (azure != null)
            {
                try
                {
                    var parameters = new Dictionary<string, string>();
                    parameters.Add("takeCount", takeCount.ToString());

                    return await azure.Client.InvokeApiAsync<List<Beer>>("TrendingBeers", HttpMethod.Get, parameters);
                }
                catch (Exception ex)
                {
                    insights.Report(ex);
                    return new List<Beer>();
                }
            }
            throw new NullReferenceException("Azure Client is null");
        }
            
    }
}

