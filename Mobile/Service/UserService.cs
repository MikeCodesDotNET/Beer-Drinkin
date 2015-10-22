using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Akavache;
using System.Reactive.Linq;

namespace BeerDrinkin.Service
{
    public class UserService
    {
        public UserService()
        {
            #if DEBUG
            RemoveAuthToken();
            #endif
        }

        public async Task<bool> SaveUser(MobileServiceUser user)
        {
            //We'll save this using Akavache
            try
            {
                // Store token
                await BlobCache.LocalMachine.InsertObject <string>("authenticationToken", CurrentMobileServiceUser().MobileServiceAuthenticationToken,
                    DateTimeOffset.Now.AddDays(30));

                // Store userId 
                await BlobCache.LocalMachine.InsertObject <string>("userId", CurrentMobileServiceUser().UserId,
                    DateTimeOffset.Now.AddDays(30));

                return true;
            }
            catch (Exception ex)
            {
                Xamarin.Insights.Report(ex);
                return false;
            }
        }

        public async Task<MobileServiceUser> GetUser()
        {
            try
            {
                var token = await BlobCache.LocalMachine.GetObject<string>("authenticationToken");
                var userId = await BlobCache.LocalMachine.GetObject<string>("userId");

                MobileServiceUser user;

                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty((userId)))
                {
                    user = new MobileServiceUser(userId);
                    user.MobileServiceAuthenticationToken = token;

                    Client.Instance.BeerDrinkinClient.CurrenMobileServicetUser = user;

                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                Xamarin.Insights.Report(ex);
            }
            return null;
        }

        public async Task<bool> RemoveAuthToken()
        {
            try
            {
            var token = await BlobCache.LocalMachine.GetObject<string>("authenticationToken");
            if (string.IsNullOrEmpty(token))
                return false;
            }
            catch(Exception)
            {
                return false;
            }

            try
            {
                // Store token
                await BlobCache.LocalMachine.InsertObject <string>("authenticationToken", string.Empty,
                    DateTimeOffset.Now.AddYears(5));

                // Store userId 
                await BlobCache.LocalMachine.InsertObject <string>("userId", string.Empty,
                    DateTimeOffset.Now.AddYears(5));

                return true;
            }
            catch (Exception ex)
            {
                Xamarin.Insights.Report(ex);

                return false;
            }
        }

        MobileServiceUser CurrentMobileServiceUser()
        {
            return Client.Instance.BeerDrinkinClient.CurrenMobileServicetUser;
        }
    }
}

