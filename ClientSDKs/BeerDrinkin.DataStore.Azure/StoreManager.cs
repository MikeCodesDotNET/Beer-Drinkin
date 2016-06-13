using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeerDrinkin.AzureClient;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;
using BeerDrinkin.DataObjects;

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Plugin.Settings;

namespace BeerDrinkin.DataStore.Azure
{
    public class StoreManager : IStoreManager
    {
        #region IStoreManager implementation

        public async Task InitializeAsync()
        {
            if (IsInitialized)
                return;

            //Get our current client, only ever need one
            var client = ServiceLocator.Instance.Resolve<IAzureClient>()?.Client;

            /*
            if (!string.IsNullOrWhiteSpace(CrossSettings.Current.AuthToken) && !string.IsNullOrWhiteSpace(Settings.Current.UserId))
            {
                client.CurrentUser = new MobileServiceUser(CrossSettings.Current.UserId);
                client.CurrentUser.MobileServiceAuthenticationToken = CrossSettings.Current.AuthToken;
            }*/

            var path = $"beerdrinkin.db";
            //setup our local sqlite store and intialize our table
            var store = new MobileServiceSQLiteStore(path);

            store.DefineTable<Beer>();
            store.DefineTable<CheckIn>();
            store.DefineTable<Brewery>();

            await client.SyncContext.InitializeAsync((IMobileServiceLocalStore) store, new MobileServiceSyncHandler()).ConfigureAwait(false);

            IsInitialized = true;
        }

        public async Task<bool> SyncAllAsync(bool syncUserSpecific)
        {

            if (!IsInitialized)
                await InitializeAsync();

            var taskList = new List<Task<bool>>();
            taskList.Add(checkInStore.SyncAsync());
            taskList.Add(wishListStore.SyncAsync());
            taskList.Add(beerStore.SyncAsync());
            taskList.Add(breweryStore.SyncAsync());

            var successes = await Task.WhenAll(taskList).ConfigureAwait(false);
            return successes.Any(x => !x);//if any were a failure.
        }

        public Task DropEverythingAsync()
        {
            checkInStore.DropTable();
            wishListStore.DropTable();
            beerStore.DropTable();
            breweryStore.DropTable();

            IsInitialized = false;
            return Task.FromResult(true);
        }

        public bool IsInitialized
        {
            get;
            private set;
        }

        ICheckInStore checkInStore;
        public ICheckInStore CheckInStore => checkInStore ?? (checkInStore = ServiceLocator.Instance.Resolve<ICheckInStore>());

        IWishStore wishListStore;
        public IWishStore WishListStore => wishListStore ?? (wishListStore = ServiceLocator.Instance.Resolve<IWishStore>());

        IBeerStore beerStore;
        public IBeerStore BeerStore => beerStore ?? (beerStore = ServiceLocator.Instance.Resolve<IBeerStore>());

        IBreweryStore breweryStore;
        public IBreweryStore BreweryStore => breweryStore ?? (breweryStore = ServiceLocator.Instance.Resolve<IBreweryStore>());

        #endregion
    }
}
