using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.Utils;
using Microsoft.WindowsAzure.MobileServices;

namespace BeerDrinkin.Core.Helpers
{
    public class UserProfileHelper
    {
        public static async Task<UserProfile> GetUserProfileAsync(IMobileServiceClient client)
        {
            var userprofile = await client.InvokeApiAsync<UserProfile>("UserInfo", System.Net.Http.HttpMethod.Get, null);

            Settings.Current.UserFirstName = userprofile?.FirstName ?? string.Empty;
            Settings.Current.UserLastName = userprofile?.FirstName ?? string.Empty;
            Settings.Current.UserProfileUrl = userprofile?.FirstName ?? string.Empty;

            return userprofile;
        }
    }
}

namespace BeerDrinkin
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Ratings { get; set; }
        public int Photos { get; set; }
        public int Beers { get; set; }
        public string Location { get; set; }
        public string ProfilePictureUri { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
    
}