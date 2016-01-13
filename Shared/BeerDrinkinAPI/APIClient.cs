using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using BeerDrinkin.Models;
using BeerDrinkin.Service.DataObjects;

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;

namespace BeerDrinkin.API
{
    public class APIClient
    {
        #region Fields

        private readonly MobileServiceClient serviceClient;


        #endregion

        #region Constructor
        public APIClient(string serviceUrl)
        {
            serviceClient = new MobileServiceClient(serviceUrl);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the curren mobile servicet user. Used to keep hold of the auth token to persist
        /// </summary>
        /// <value>The curren mobile servicet user.</value>
        public MobileServiceUser CurrenMobileServicetUser
        {
            get { return serviceClient.CurrentUser; }
            set { serviceClient.CurrentUser = value; }
        }

        public MobileServiceClient ServiceClient
        {
            get
            {
                return serviceClient;
            }
        }

        AccountItem currentAccount;

        public AccountItem CurrentAccount
        {
            get
            {
                if (currentAccount == null)
                    currentAccount = GetCurrentAccount().Result;
                
                return currentAccount;
            }
        }
        #endregion


        #region User
        public async Task<APIResponse<HeaderInfo>> GetUsersHeaderInfoAsync(string userId)
        {
            //Is the user authenticated? 
            if (!string.IsNullOrEmpty(CurrenMobileServicetUser.UserId))
            {                
                var parameters = new Dictionary<string, string>();

                parameters.Add("userId", userId);

                try
                {
                    return
                        new APIResponse<HeaderInfo>(
                        await serviceClient.InvokeApiAsync<HeaderInfo>("HeaderInfo", HttpMethod.Get, parameters),
                        null);
                }
                catch (Exception ex)
                {
                    return new APIResponse<HeaderInfo>(null, ex);
                }
            }
            return new APIResponse<HeaderInfo>(null, new UnauthorizedAccessException("User is unauthenticated"));
        }

       

        private async Task<AccountItem> GetCurrentAccount()
        {
            var table = serviceClient.GetSyncTable<AccountItem>();
            return await table.LookupAsync(GetUserId);
        }

        public string GetUserId
        {
            get
            {
                if (serviceClient.CurrentUser != null)
                {
                    var ta = serviceClient.CurrentUser.UserId.Split(':');
                    if (ta.Length == 2)
                        return ta[1];
                }
                return string.Empty; 
            }
        }

        #endregion

        #region Search

        public async Task<APIResponse<List<BeerItem>>> SearchBeerAsync(string keyword)
        {
            var table = serviceClient.GetSyncTable<BeerStyle>();
            var checkInTable = serviceClient.GetSyncTable<CheckInItem>();

            keyword = keyword.ToLowerInvariant();

            //are we in?
            var results = new List<BeerItem>();
            var parameters = new Dictionary<string, string>();
            parameters.Add("keyword", keyword);

            try
            {
                results = await serviceClient.InvokeApiAsync<List<BeerItem>>("Search", HttpMethod.Get, parameters);
                if (results != null && results.Any())
                {                      
                    //sync db to update new beers && styles
                    await SyncAsync<BeerItem>("allUsers");
                    await SyncAsync(table, "allUsers");

                    return new APIResponse<List<BeerItem>>(results, null);
                }
                return new APIResponse<List<BeerItem>>(results, new Exception("No results found"));
            }
            catch (Exception ex)
            {
                return new APIResponse<List<BeerItem>>(results, ex);
            }
        }

        public async Task<APIResponse<List<BeerItem>>> SuggestBeerAsync(string keyword)
        {
            var table = serviceClient.GetSyncTable<BeerStyle>();
            var checkInTable = serviceClient.GetSyncTable<CheckInItem>();

            keyword = keyword.ToLowerInvariant();

            //are we in?
            var results = new List<BeerItem>();
            var parameters = new Dictionary<string, string>();
            parameters.Add("keyword", keyword);

            try
            {
                results = await serviceClient.InvokeApiAsync<List<BeerItem>>("Suggest", HttpMethod.Get, parameters);
                if (results != null && results.Any())
                {                      
                    //sync db to update new beers && styles
                    await SyncAsync<BeerItem>("allUsers");
                    await SyncAsync(table, "allUsers");

                    return new APIResponse<List<BeerItem>>(results, null);
                }
                return new APIResponse<List<BeerItem>>(results, new Exception("No results found"));
            }
            catch (Exception ex)
            {
                return new APIResponse<List<BeerItem>>(results, ex);
            }
        }

        public async Task<APIResponse<List<BeerItem>>> LookupUpcAsync(string upc)
        {                       
            var parameters = new Dictionary<string, string>();

            parameters.Add("upc", upc);
            try
            {
                return new APIResponse<List<BeerItem>>(await serviceClient.InvokeApiAsync<List<BeerItem>>("UPC", HttpMethod.Get, parameters), null);
            }
            catch (Exception ex)
            {
                return new APIResponse<List<BeerItem>>(null, ex);
            }
        }

        /*
        public async Task<APIResponse<List<Brewery>>> SearchBreweryAsync(string keyword)
        {
            //are we in?
            var username = GetUsername(AuthTypes.any);
            if (!string.IsNullOrEmpty(username))
            {
                var parameters = new Dictionary<string, string>();

                parameters.Add("keyword", keyword);

                try
                {
                    return
                        new APIResponse<List<Brewery>>(
                        await serviceClient.InvokeApiAsync<List<Brewery>>("SearchBrewery", HttpMethod.Get, parameters),
                        null);
                }
                catch (Exception ex)
                {
                    return new APIResponse<List<Brewery>>(new List<Brewery>(), ex);
                }
            }
            return new APIResponse<List<Brewery>>(new List<Brewery>(),
                new UnauthorizedAccessException("User is unauthenticated"));
        }
*/

        #endregion

        #region CheckIn
        public async Task<APIResponse<bool>> CheckInBeerAsync(CheckInItem checkInItem)
        {
            var id = GetUserId;
            if (!string.IsNullOrEmpty(id)) //user is logged in
            {
                if (checkInItem.Beer != null)
                {
                    checkInItem.BeerId = checkInItem.Beer.Id;
                }
                var table = serviceClient.GetSyncTable<CheckInItem>();
                checkInItem.CheckedInBy = id;
                await table.InsertAsync(checkInItem);
                await SyncAsync<CheckInItem>(id);

                return new APIResponse<bool>(true, null);
            }
            return new APIResponse<bool>(false, new UnauthorizedAccessException("User is unauthenticated"));
        }

        /// <summary>
        /// This method returns all checkins of ALL beers by some user
        /// </summary>
        /// <returns></returns>
        public async Task<APIResponse<List<CheckInItem>>> GetBeerCheckInsBy(string checkedInByUsername)
        {
            var results = new List<CheckInItem>();
            var id = GetUserId;
            if (!string.IsNullOrEmpty(id)) //user is logged in
            {                
                var table = serviceClient.GetSyncTable<CheckInItem>();
                await SyncAsync(table, checkedInByUsername);
                results = await table.Where(f => f.CheckedInBy == checkedInByUsername).ToListAsync();
                if (results != null && results.Any())
                {
                    var beerTable = serviceClient.GetSyncTable<BeerItem>();
                    foreach (var checkIn in results)
                        checkIn.Beer = await beerTable.LookupAsync(checkIn.BeerId);
                }
                return new APIResponse<List<CheckInItem>>(results, null);
            }
            return new APIResponse<List<CheckInItem>>(results,
                new UnauthorizedAccessException("User is unauthenticated"));
        }

        /// <summary>
        /// Returns checkins of some exact beer checkedIn by current user 
        /// </summary>
        /// <param name="beerId"></param>
        /// <returns></returns>
        public async Task<APIResponse<List<CheckInItem>>> GetBeerCheckIns(string beerId)
        {
            var results = new List<CheckInItem>();
            var id = GetUserId;
            if (!string.IsNullOrEmpty(id)) //user is logged in
            {
                var table = serviceClient.GetSyncTable<CheckInItem>();
                await SyncAsync(table, id);
                results = await table.Where(f => f.BeerId == beerId && f.CheckedInBy == id).ToListAsync();
                if (results != null && results.Any())
                {
                    var beerTable = serviceClient.GetSyncTable<BeerItem>();
                    foreach (var checkIn in results)
                        checkIn.Beer = await beerTable.LookupAsync(checkIn.BeerId);
                }
                return new APIResponse<List<CheckInItem>>(results, null);
            }
            return new APIResponse<List<CheckInItem>>(results,
                new UnauthorizedAccessException("User is unauthenticated"));
        }

        public async Task<APIResponse<bool>> DeleteBeerCheckinsAsync(string beerId)
        {
            var id = GetUserId;
            if (!string.IsNullOrEmpty(id)) //user is logged in
            {
                var table = serviceClient.GetSyncTable<CheckInItem>();
                await SyncAsync(table, id);
                var checkInsToDelete =
                    await table.Where(f => f.BeerId == beerId && f.CheckedInBy == id).ToListAsync();

                if (checkInsToDelete == null || !checkInsToDelete.Any())
                    return new APIResponse<bool>(false, new Exception("No items found to delete"));

                foreach (var checkIn in checkInsToDelete)
                    await table.DeleteAsync(checkIn);

                await SyncAsync(table, id);

                return new APIResponse<bool>(true, null);
            }
            return new APIResponse<bool>(false, new UnauthorizedAccessException("User is unauthenticated"));
        }

        #endregion

        #region BeerInfo
        public async Task<APIResponse<BeerInfo>> GetBeerInfoAsync(string beerId)
        {
            //are we in?
            var id = GetUserId;
            ;
            if (!string.IsNullOrEmpty(id))
            {
                var parameters = new Dictionary<string, string>();

                parameters.Add("userId", id);
                parameters.Add("beerId", beerId);

                try
                {
                    return
                        new APIResponse<BeerInfo>(
                        await serviceClient.InvokeApiAsync<BeerInfo>("BeerInfo", HttpMethod.Get, parameters), null);
                }
                catch (Exception ex)
                {
                    return new APIResponse<BeerInfo>(null, ex);
                }
            }
            return new APIResponse<BeerInfo>(null, new UnauthorizedAccessException("User is unauthenticated"));
        }

        public async Task<APIResponse<List<BeerInfo>>> GetBeerInfosByUserAsync()
        {
            //are we in?
            var results = new List<BeerInfo>();
            var id = GetUserId;
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    //Sync checkins
                    var table = serviceClient.GetSyncTable<CheckInItem>();
                    await SyncAsync(table, id);
                    var beerTable = serviceClient.GetSyncTable<BeerItem>();
                    await SyncAsync(beerTable, id);

                    //unique list of beer ids consumed by current user
                    var beerIds =
                        (await table.Where(f => f.CheckedInBy == id).ToListAsync()).Select(b => b.BeerId)
                            .GroupBy(x => x)
                            .Select(y => y.First());
                    foreach (var beerId in beerIds)
                    {
                        var beerInfo = new BeerInfo();
                        var beerItem = (await beerTable.Where(f => f.Id == beerId).ToListAsync()).FirstOrDefault();
                        if (beerItem != null)
                        {
                            beerInfo.Name = beerItem.Name;
                            beerInfo.BreweryDbId = beerId;
                            var checkinsResponse = await GetBeerCheckIns(beerId);
                            if (checkinsResponse.Result != null && checkinsResponse.Result.Any())
                            {
                                beerInfo.CheckIns = checkinsResponse.Result;
                                beerInfo.AverageRating = beerInfo.CheckIns.Select(f => f.Rating).Average();
                            }
                            results.Add(beerInfo);
                        }
                    }
                    return new APIResponse<List<BeerInfo>>(results, null);
                }
                catch (Exception ex)
                {
                    return new APIResponse<List<BeerInfo>>(results, ex);
                }
            }
            return new APIResponse<List<BeerInfo>>(results, new UnauthorizedAccessException("User is unauthenticated"));
        }

        #endregion

        #region Basic Caching


        public async Task<bool> ClearCache()
        {
            return true;
        }

        #endregion

        #region Binary
        //Methods in this region is to post/get binary data related to any object like beer or review,
        //where we may have several images

        /// <summary>
        /// Uploads binary data to database
        /// </summary>
        /// <param name="objectId">I believe it should be BreweryDBId for beer and review id for reviews</param>
        /// <param name="objectType"></param>
        /// <param name="binaryData"></param>
        /// <returns></returns>
        public async Task<APIResponse<bool>> UploadBinaryAsync(string objectId, BinaryTypes objectType, string binaryData)
        {
            return null;
        }

        public async Task<APIResponse<bool>> UploadBinaryAsync(string objectId, BinaryTypes objectType, byte[] data)
        {
            return await UploadBinaryAsync(objectId, objectType, DataConverter.GetStringFromData(data));
        }

        /// <summary>
        /// returns URLs of the binaries related to the object
        /// </summary>
        public async Task<APIResponse<List<string>>> GetBinariesForObject(string objectId, BinaryTypes type)
        {
            //are we in?
            if (!string.IsNullOrEmpty(CurrenMobileServicetUser.UserId))
                return new APIResponse<List<string>>(new List<string>(),
                    new UnauthorizedAccessException("User is unauthenticated"));

            var parameters = new Dictionary<string, string> { { "objectId", objectId }, { "type", type.ToString() } };

            try
            {
                return
                    new APIResponse<List<string>>(
                    await serviceClient.InvokeApiAsync<List<string>>("BinaryItem", HttpMethod.Get, parameters),
                    null);
            }
            catch (Exception ex)
            {
                return new APIResponse<List<string>>(new List<string>(), ex);
            }
        }

        public async Task<APIResponse<List<string>>> GetPhotosForUser(string userId)
        {  
            //Is the user authenticated? 
            if (!string.IsNullOrEmpty(CurrenMobileServicetUser.UserId))
            {                
                var parameters = new Dictionary<string, string>();

                parameters.Add("userId", userId);

                try
                {
                    return new APIResponse<List<string>>(await serviceClient.InvokeApiAsync<List<string>>("BinaryItem", HttpMethod.Get, parameters), null);
                }
                catch (Exception ex)
                {
                    return new APIResponse<List<string>>(null, ex);
                }
            }
            return new APIResponse<List<string>>(null, new UnauthorizedAccessException("User is unauthenticated"));
        }
           
        public async Task<APIResponse<List<string>>> GetPhotosForUser()
        {
            return await GetPhotosForUser(GetUserId);
        }
           

        #endregion

        #region PopularBeers
        public async Task<APIResponse<List<BeerItem>>> GetPopularBeersAsync(double longitude, double latitude)
        {
            //are we in? 
           
            var parameters = new Dictionary<string, string>();
            parameters.Add("longitude", longitude.ToString());
            parameters.Add("latitude", latitude.ToString());

            try
            {
                return
                        new APIResponse<List<BeerItem>>(
                    await serviceClient.InvokeApiAsync<List<BeerItem>>("PopularBeers", HttpMethod.Get, parameters),
                    null);
            }
            catch (Exception ex)
            {
                return new APIResponse<List<BeerItem>>(null, ex);
            }
        }
    

        #endregion

        #region OfflineSync


        public async Task InitializeStoreAsync(string localDbPath)
        {
            var store = new MobileServiceSQLiteStore("beerdrinkin.db");
            store.DefineTable<AccountItem>();
            store.DefineTable<CheckInItem>();
            store.DefineTable<BeerItem>();
            store.DefineTable<BeerStyle>();
           
            //Use simple conflicts handler
            await serviceClient.SyncContext.InitializeAsync(store, new AzureSyncHandler());
            await RefreshAll();
        }

        private async Task SyncAsync<T>(IMobileServiceSyncTable<T> table, string queryId)
        {
            try
            {
                await serviceClient.SyncContext.PushAsync();
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

        private async Task SyncAsync<T>(string queryId)
        {
            IMobileServiceSyncTable<T> table = null;
            try
            {
                table = serviceClient.GetSyncTable<T>();
                await table.PullAsync(queryId, table.CreateQuery());
                await serviceClient.SyncContext.PushAsync();
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


            currentAccount = await GetCurrentAccount();
        }

        #endregion
    
    
    }
}