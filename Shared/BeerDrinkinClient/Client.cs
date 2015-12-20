using System;
using BeerDrinkin.Resources;
using Microsoft.WindowsAzure.MobileServices;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.Sync;
using BeerDrinkin.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using BeerDrinkin.Azure;

namespace BeerDrinkin
{
    public class Client
    {
        public readonly string ServiceUrl;
        public readonly MobileServiceClient AzureClient;

        public Client(string serviceUrl)
        {
            ServiceUrl = serviceUrl;
            AzureClient = new MobileServiceClient(serviceUrl);

            //Resources
            User = new UserResource(this);
            Beers = new BeerResource(this);
        }

        #region OfflineSync

        public async Task InitializeStoreAsync(string localDbPath)
        {
            var store = new MobileServiceSQLiteStore("beerdrinkin.db");
            store.DefineTable<AccountItem>();
            store.DefineTable<CheckInItem>();
            store.DefineTable<BeerItem>();
            store.DefineTable<BeerStyle>();

            //Use simple conflicts handler
            await AzureClient.SyncContext.InitializeAsync(store, new AzureSyncHandler());
            await RefreshAll();
        }

        public async Task SyncAsync<T>(IMobileServiceSyncTable<T> table, string queryId)
        {
            try
            {
                await AzureClient.SyncContext.PushAsync();
                await table.PullAsync(queryId, table.CreateQuery());
            }
            catch (MobileServiceInvalidOperationException e)
            {
                //TODO Implement some logger
                Debug.WriteLine(@"Sync Failed on {0} table with message of: {1}", table, e.Message);
            }
            catch(Exception ex)
            {
                //TODO Implement some logger
                Debug.WriteLine(@"Sync Failed on {0} table with message of: {1}", table, ex.Message);
            }
        }

        public async Task SyncAsync<T>(string queryId)
        {
            IMobileServiceSyncTable<T> table = null;
            try
            {
                table = AzureClient.GetSyncTable<T>();
                await table.PullAsync(queryId, table.CreateQuery());
                await AzureClient.SyncContext.PushAsync();
                Debug.WriteLine(string.Format("QueryId: {0}", queryId));

            }
            catch (MobileServiceInvalidOperationException e)
            {
                //TODO Implement some logger
                Debug.WriteLine(@"Sync Failed on {0} table with message of: {1}", table?.ToString() ?? string.Empty, e.Message);
            }
            catch(Exception ex)
            {
                //TODO Implement some logger
                Debug.WriteLine(@"Sync Failed on {0} table with message of: {1}", table?.ToString() ?? string.Empty, ex.Message);
            }
        }

        public async Task RefreshAll()
        {
            await SyncAsync<AccountItem>("allUsers");
            await SyncAsync<CheckInItem>("CheckInItems");
            await SyncAsync<BeerItem>("beers");
            await SyncAsync<BeerStyle>("styles");
        }

        #endregion

        public UserResource User {get; set;}
        public BeerResource Beers {get; set;}
    }
}

