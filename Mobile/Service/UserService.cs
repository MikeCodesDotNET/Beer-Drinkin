using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Akavache;
using System.Reactive.Linq;
using System.Collections.Generic;

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

        //Smells bad to me...come fix it
        public async Task<bool> RemoveAuthToken()
        {
            try
            {
                //Attempt to get the token.
                var token = await BlobCache.LocalMachine.GetObject<string>("authenticationToken");
                if (string.IsNullOrEmpty(token))
                    return false;
                

                //Clear the token
                await BlobCache.LocalMachine.InsertObject <string>("authenticationToken", string.Empty,
                    DateTimeOffset.Now.AddYears(5));

                //Clear the userID
                await BlobCache.LocalMachine.InsertObject <string>("userId", string.Empty,
                    DateTimeOffset.Now.AddYears(5));

                return true;
            }
            catch (Exception ex)
            {
                if(ex.GetType() != typeof(KeyNotFoundException))
                    Xamarin.Insights.Report(ex);
                else
                    await BlobCache.LocalMachine.InsertObject <string>("authenticationToken", string.Empty, DateTimeOffset.Now.AddYears(5));
                
                return false;
            }
        }

        MobileServiceUser CurrentMobileServiceUser()
        {
            return Client.Instance.BeerDrinkinClient.CurrenMobileServicetUser;
        }
    }
}

