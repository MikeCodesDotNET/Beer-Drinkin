using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BeerDrinkin.AzureClient;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;

namespace BeerDrinkin.Core.ViewModels
{
    public class AppFeedbackViewModel
    {
        IAzureClient azure;
        public AppFeedbackViewModel()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
        }

        public async Task SubmitFeedback(AppFeedback feedback)
        {
            //TODO implement posting objects to Azure through InvokeAPI
            var parameters = new Dictionary<string, string>();
            parameters.Add("searchTerm", searchTerm);

            await azure.Client.InvokeApiAsync("Search", HttpMethod.Get, parameters);
        }
    }
}

