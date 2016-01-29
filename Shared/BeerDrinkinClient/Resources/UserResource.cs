using System;
using System.Threading.Tasks;
using BeerDrinkin.Models;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;

namespace BeerDrinkin.Resources
{
    public class UserResource
    {
        AzureClient azureClient;

        public UserResource(AzureClient client)
        {
            this.azureClient = client;
        }

        public string AccessToken
        {
            get
            {
                return azureClient.Client.CurrentUser.MobileServiceAuthenticationToken;
            }
        }

        public string UserId
        {
            get
            {
                return azureClient.Client.CurrentUser.UserId;
            }
        }

        public MobileServiceUser CurrentUser
        {
            get
            {
                return azureClient.Client.CurrentUser;
            }
            set
            {
                azureClient.Client.CurrentUser = value;
            }
        }


    }
}

