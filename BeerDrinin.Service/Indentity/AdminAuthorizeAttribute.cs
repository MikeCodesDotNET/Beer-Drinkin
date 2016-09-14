using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BeerDrinkin.Service.Indentity
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // If not already authenticated, return.
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return;
            }

            // If they don't have an identity name at all, return.
            if (string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                return;
            }

            var address = IsValidEmail(actionContext.RequestContext.Principal.Identity.Name);

            // If their name is not a valid email, return.
            if (address == null)
            {
                return;
            }

            var adminEmail = ConfigurationManager.AppSettings["AdminEmail"];
            // If user email does not contain xamarin.com, return.
            if (!address.Address.ToLower().Equals(adminEmail))
            {
                return;
            }

            base.OnAuthorization(actionContext);
        }

        MailAddress IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr;
            }
            catch
            {
                return null;
            }
        }
    }
}