using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.AzureClient;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;

namespace BeerDrinkin.Core.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {
        IAzureClient azure;
        IUserStore userStore;

        public UsersViewModel()
        {
            Initialize();
        }

        void Initialize()
        {
            if (azure == null || azure == null || userStore == null)
            {
                azure = ServiceLocator.Instance.Resolve<IAzureClient>();
                userStore = ServiceLocator.Instance.Resolve<IUserStore>();
            }
        }

        public async Task<List<User>> GetUsers()
        {
            Initialize();
            return (List<User>)await userStore.GetItemsAsync();
        }
    }
}

