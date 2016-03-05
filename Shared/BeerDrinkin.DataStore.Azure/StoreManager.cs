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

            if (!string.IsNullOrWhiteSpace(Settings.Current.AuthToken) && !string.IsNullOrWhiteSpace(Settings.Current.UserId))
            {
                client.CurrentUser = new MobileServiceUser(Settings.Current.UserId);
                client.CurrentUser.MobileServiceAuthenticationToken = Settings.Current.AuthToken;
            }

            var path = $"syncstore{Settings.Current.DatabaseId}.db";
            //setup our local sqlite store and intialize our table
            var store = new MobileServiceSQLiteStore(path);

            store.DefineTable<Beer>();
            store.DefineTable<CheckIn>();

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

            var successes = await Task.WhenAll(taskList).ConfigureAwait(false);
            return successes.Any(x => !x);//if any were a failure.
        }

        public Task DropEverythingAsync()
        {
            Settings.Current.UpdateDatabaseId();
            checkInStore.DropTable();
            wishListStore.DropTable();
            beerStore.DropTable();
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

        IWishListStore wishListStore;
        public IWishListStore WishListStore => wishListStore ?? (wishListStore = ServiceLocator.Instance.Resolve<IWishListStore>());

        IBeerStore beerStore;
        public IBeerStore BeerStore => beerStore ?? (beerStore = ServiceLocator.Instance.Resolve<IBeerStore>());
        
        #endregion
    }
}
