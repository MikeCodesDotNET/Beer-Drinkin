using System;
using System.Threading.Tasks;
using BeerDrinkin.Models;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;

namespace BeerDrinkin.Resources
{
    public class UserResource
    {
        Client client;

        public UserResource(Client client)
        {
            this.client = client;
        }

        public string AccessToken
        {
            get
            {
                return client.AzureClient.CurrentUser.MobileServiceAuthenticationToken;
            }
        }

        public string UserId
        {
            get
            {
                return client.AzureClient.CurrentUser.UserId;
            }
        }

        public MobileServiceUser CurrentUser
        {
            get
            {
                return client.AzureClient.CurrentUser;
            }
            set
            {
                client.AzureClient.CurrentUser = value;
            }
        }


    }
}

