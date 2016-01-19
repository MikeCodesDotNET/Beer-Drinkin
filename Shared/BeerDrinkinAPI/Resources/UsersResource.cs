using System;
using BeerDrinkin.Service.DataObjects;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;

namespace BeerDrinkin.API.Resources
{
    public class UsersResource
    {
        readonly APIClient client;
        public UsersResource(APIClient client)
        {
            this.client = client;
        }

        public bool IsLoggedIn = false;

        public async Task<UserItem> CurrentUser()
        {
            try
            {
                var result =  await client.ServiceClient.InvokeApiAsync<UserItem>("UserItem");
                if(result != null)
                {
                    IsLoggedIn = true;
                    return result;
                }
                return new UserItem();
            }
            catch (Exception ex)
            {
                Xamarin.Insights.Report(ex);
                return new UserItem();
            }
        }


    }
}


