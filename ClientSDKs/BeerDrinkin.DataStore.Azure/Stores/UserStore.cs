using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.Models;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.DataStore.Azure.Stores;
using BeerDrinkin.Utils;
using BeerDrinkin.AzureClient;

namespace BeerDrinkin.DataStore.Azure
{
    public class UserStore : BaseStore<User>, IUserStore
    {
        public async Task<User> GetCurrentUser()
        {
            try
            {
                var client = ServiceLocator.Instance.Resolve<IAzureClient>();
                var userID = client.Client.CurrentUser.UserId;

                var currentUser = await GetItemAsync(userID);
                return currentUser;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
