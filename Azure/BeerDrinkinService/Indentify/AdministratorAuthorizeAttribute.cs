using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BeerDrinkin.Service.Indentify
{
    public class AdministratorAuthorizeAttribute : AuthorizeAttribute
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

            // If user email does not contain xamarin.com, return.
            if (!address.Host.ToLower().Equals("xamarin.com"))
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