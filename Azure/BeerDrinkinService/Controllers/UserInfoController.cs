using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;
using BeerDrinkin.Service.Models;

namespace BeerDrinkin.Service.Controllers
{
    [MobileAppController]
    public class UserInfoController : ApiController
    {
        const string FacebookGraphUrl = "https://graph.facebook.com/v2.5/me?fields=first_name%2Clast_name%2Cpicture%7Burl%7D&access_token=";
        const string MicrosoftUrl = "https://apis.live.net/v5.0/me?access_token=";

        // GET api/UserInfo
        public async Task<UserProfile> Get(string userId)
        {
            //return the current authenticated user profile
            ClaimsPrincipal user = User as ClaimsPrincipal;
            var userProfile = new UserProfile();
            bool? isAuthenticated = user?.Identity?.IsAuthenticated;
            if (isAuthenticated == true)
            {
                // Get the credentials for the logged-in user.
                var fbCredentials = await user.GetAppServiceIdentityAsync<FacebookCredentials>(Request);
                var mscredentials = await user.GetAppServiceIdentityAsync<MicrosoftAccountCredentials>(Request);

                if (fbCredentials != null && (fbCredentials?.Claims).Any())
                {
                    userProfile = await FillDataFromFacebook(userId, fbCredentials.AccessToken);
                }
                else if (mscredentials != null && (mscredentials?.Claims).Any())
                {
                    userProfile =  await FillDataFromMS(userId, mscredentials.AccessToken);
                }
            }
            return userProfile;
        }

        private static async Task<UserProfile> FillDataFromFacebook(string userId, string token)
        {
            // Create a query string with the Facebook access token.
            var fbRequestUrl = FacebookGraphUrl + token;

            using (var client = new System.Net.Http.HttpClient())
            {
                // Request the current user info from Facebook.
                var resp = await client.GetAsync(fbRequestUrl);
                resp.EnsureSuccessStatusCode();

                string fbInfo = await resp.Content.ReadAsStringAsync();

                var userProfile = new UserProfile();
                JObject fbObject = JObject.Parse(fbInfo);
                userProfile.FirstName = fbObject.GetValue("first_name")?.ToString();
                userProfile.LastName = fbObject.GetValue("last_name")?.ToString();
                var picture = fbObject.GetValue("picture")?.ToString();
                var data = JObject.Parse(picture)?.GetValue("data")?.ToString();
                var url = JObject.Parse(data)?.GetValue("url")?.ToString();
                userProfile.ProfilePictureUri = url;

                var context = new BeerDrinkinContext();
                userProfile.Beers = context.CheckIns.Count(f => f.CheckedInBy == userId);
                userProfile.Ratings = context.Ratings.Count(f => f.RatedBy == userId);

                return userProfile;
            }
        }


        private static async Task<UserProfile> FillDataFromMS(string userId, string token)
        {
            // Create a query string with the Facebook access token.
            var msRequestUrl = MicrosoftUrl + token;
            string pictureUrl;
            var userProfile = new UserProfile();
            using (var client = new System.Net.Http.HttpClient())
            {
                var resp = await client.GetAsync(msRequestUrl);
                resp.EnsureSuccessStatusCode();
                string info = await resp.Content.ReadAsStringAsync();
                JObject fbObject = JObject.Parse(info);
                userProfile.FirstName = fbObject.GetValue("first_name")?.ToString();
                userProfile.LastName = fbObject.GetValue("last_name")?.ToString();
                string id = fbObject.GetValue("id")?.ToString();

                pictureUrl = $"https://apis.live.net/v5.0/{id}/picture";
                return userProfile;
            }

            //request for the profile picture
            using (var client = new System.Net.Http.HttpClient())
            {
                var resp = await client.GetAsync(pictureUrl);
                resp.EnsureSuccessStatusCode();
                var picture = await resp.Content.ReadAsByteArrayAsync();
                userProfile.ProfilePicture = picture;
            }
        }

    }
}
