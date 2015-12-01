using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Models;
using Facebook;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using Microsoft.WindowsAzure.Mobile.Service.Security.Providers;

namespace BeerDrinkin.Service
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            options.LoginProviders.Remove(typeof(FacebookLoginProvider));
            options.LoginProviders.Add(typeof(CustomFacebookLoginProvider));

            options.LoginProviders.Remove(typeof (GoogleLoginProvider));
            options.LoginProviders.Add(typeof(CustomGoogleLoginProvider));

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            // Set default and null value handling to "Include" for Json Serializer
            config.Formatters.JsonFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
            
            Database.SetInitializer(new BeerdrinkingtestInitializer());
        }
    }

    public class CustomFacebookLoginProvider : FacebookLoginProvider
    {
        public CustomFacebookLoginProvider(HttpConfiguration config, IServiceTokenHandler tokenHandler)
            : base(config, tokenHandler)
        {
        }

        public override ProviderCredentials CreateCredentials(ClaimsIdentity claimsIdentity)
        {
            var accessToken = string.Empty;
            var emailAddress = string.Empty;
            foreach (var claim in claimsIdentity.Claims)
            {
                if (claim.Type == "Zumo:ProviderAccessToken")
                {
                    accessToken = claim.Value;
                }

                if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")
                {
                    emailAddress = claim.Value;
                }
            }

            if (string.IsNullOrEmpty(accessToken))
                return null;

            var client = new FacebookClient(accessToken);
            dynamic user = client.Get("me");

            DateTime dateOfBirth;
            DateTime.TryParse(user.birthday, out dateOfBirth);

            //Keeping userItem for the moment but may well kill it. I was going to seperate userItem into public info and accountItem into public
            var userItem = new UserItem
            {
                Id = user.id,
            };

            var accountItem = new AccountItem
            {
                Id = userItem.Id,
                Email = emailAddress,
                FirstName = user.first_name,
                LastName = user.last_name,
                IsMale = user.gender == "male",
                DateOfBirth = dateOfBirth,
                AvatarUrl = $"https://graph.facebook.com/{userItem.Id}/picture?type=large"
            };

            var context = new BeerDrinkinContext();
            if (context.UserItems.FirstOrDefault(x => x.Id == userItem.Id) != null)
                return base.CreateCredentials(claimsIdentity);

            context.AccountItems.Add(accountItem);
            context.UserItems.Add(userItem);
            context.SaveChanges();

            return base.CreateCredentials(claimsIdentity);
        }
    }

    public class CustomGoogleLoginProvider : GoogleLoginProvider
    {
        public ApiServices Services { get; set; }

        public CustomGoogleLoginProvider(HttpConfiguration config, IServiceTokenHandler tokenHandler)
            : base(config, tokenHandler)
        {
        }

        public override ProviderCredentials CreateCredentials(ClaimsIdentity claimsIdentity)
        {
            try
            {
                //Lets find some infomation about the user
                var accountItem = new AccountItem();

                foreach (var claim in claimsIdentity.Claims)
                {
                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")
                    {
                        accountItem.Email = claim.Value;
                    }

                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                    {
                        accountItem.Id = claim.Value;
                    }

                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")
                    {
                        accountItem.FirstName = claim.Value;
                    }

                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")
                    {
                        accountItem.LastName = claim.Value;
                    }
                }

                accountItem.AvatarUrl = Gravimage.Gravimage.Get(accountItem.Email, 200);

                var context = new BeerDrinkinContext();
                if (context.AccountItems.FirstOrDefault(x => x.Id == accountItem.Id) != null)
                    return base.CreateCredentials(claimsIdentity);

                context.AccountItems.Add(accountItem);
                context.SaveChanges();

                return base.CreateCredentials(claimsIdentity);
            }
            catch (Exception ex)
            {
                Services.Log.Info(ex.Message);
                return null;
            }
            
        }
    }

    public class BeerdrinkingtestInitializer : ClearDatabaseSchemaIfModelChanges<BeerDrinkinContext>
    {
        protected override void Seed(BeerDrinkinContext context)
        {
            /*List<UserItem> todoItems = new List<UserItem>
            {
                new UserItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new UserItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (UserItem todoItem in todoItems)
            {
                context.Set<UserItem>().Add(todoItem);
            }*/

            base.Seed(context);
        }
    }
}

