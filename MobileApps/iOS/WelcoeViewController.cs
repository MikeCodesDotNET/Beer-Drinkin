using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Xamarin.Auth;
using Newtonsoft.Json.Linq;
using BeerDrinkin.Service;
using BeerDrinkin.Service.DataObjects;
using Newtonsoft.Json;

namespace BeerDrinkin.iOS
{
    partial class WelcoeViewController : UIViewController
    {
        public WelcoeViewController(IntPtr handle)
            : base(handle)
        {
        }

        async partial void BtnConnectWithFacebook_TouchUpInside(UIButton sender)
        {
            try
            {
                string facebookToken;
                var auth = new OAuth2Authenticator(
                               clientId: BeerDrinkin.Core.Helpers.Keys.FacebookClientId,
                               scope: "",
                               authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                               redirectUrl: new Uri("https://beerdrinkin.azure-mobile.net/signin-facebook"));
    
                auth.AllowCancel = true;
                auth.Completed += (s, e) =>
                {
                    if (!e.IsAuthenticated)
                    {
                        Acr.UserDialogs.UserDialogs.Instance.ShowError("Not authorized");
                        return;
                    }
    
                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, e.Account);
                    var response = request.GetResponseAsync().ContinueWith(t =>
                        {
                            if (!t.IsFaulted && !t.IsCanceled)
                            {
                                var stri = t.Result.GetResponseText();
                                var profile = JsonConvert.DeserializeObject<FacebookUser>(stri);

                                var userItem = new UserItem();
                                userItem.FirstName = profile.FirstName;
                                userItem.LastName = profile.LastName;
                                userItem.Email = profile.Email;
                            }
                        });
    
                };
    
                await PresentViewControllerAsync(auth.GetUI(), true);
    
                // Client.Instance.BeerDrinkinClient.CurrenMobileServicetUser = await Client.Instance.BeerDrinkinClient.ServiceClient.LoginAsync()
                var userService = new UserService();
                await userService.SaveUser(Client.Instance.BeerDrinkinClient.CurrenMobileServicetUser);
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError($"ERROR - AUTHENTICATION FAILED {ex.Message}");
            }
        }
    }

    [JsonObject]
    public class FacebookUser
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("birthday")]
        public string Birthday
        {
            get;
            set;
        }

        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("first_name")]
        public string FirstName
        {
            get;
            set;
        }

        [JsonProperty("last_name")]
        public string LastName
        {
            get;
            set;
        }

        [JsonProperty("gender")]
        public string Gender
        {
            get;
            set;
        }

        [JsonProperty("locale")]
        public string Locale
        {
            get;
            set;
        }

        [JsonProperty("timezone")]
        public float Timezone
        {
            get;
            set;
        }

        [JsonProperty("link")]
        public string Link
        {
            get;
            set;
        }
    }
}
