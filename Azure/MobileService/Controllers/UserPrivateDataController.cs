using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Web.Http.Tracing;
using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.DataObjects;
using Microsoft.Azure.Mobile.Server;

namespace BeerDrinkin.Service.Controllers
{
     [Authorize]
    public class UserPrivateDataController : ApiController
    {
        private readonly MobileAppSettingsDictionary settings;
        private readonly ITraceWriter tracer;

        public UserPrivateDataController()
        {
            settings = Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            tracer = Configuration.Services.GetTraceWriter();
        }
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
                tracer.Error(ex.Message);
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
