using System;
using System.Collections.Generic;
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
           // await azure.Client.InvokeApiAsync<bool>("Search", feedback);
        }
    }
}

