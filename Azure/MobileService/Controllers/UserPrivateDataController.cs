using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class UserPrivateDataController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/UserPrivateData
        public UserPrivateData Get(string username)
        {
            try
            {
                BeerDrinkinContext context = new BeerDrinkinContext();
                return context.UserPrivateItems.SingleOrDefault(f => f.Id == username);
            }
            catch (Exception ex)
            {
                Services.Log.Error(ex.Message);
            }

            return null;
        }

        public HttpResponseMessage Post(UserPrivateData privateData)
        {
            try
            {
                BeerDrinkinContext context = new BeerDrinkinContext();
                var old= context.UserPrivateItems.SingleOrDefault(f => f.Id == privateData.Id);
                if (old != null)
                {
                    old.DateOfBirth = privateData.DateOfBirth;
                }
                else
                    context.UserPrivateItems.Add(privateData);
                context.SaveChanges();
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { }
            return this.Request.CreateResponse(HttpStatusCode.Conflict,
                "Something wrong");
        }
    }
}
