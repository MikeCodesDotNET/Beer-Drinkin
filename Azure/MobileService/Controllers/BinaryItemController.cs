using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Models;

using System.Net.Http;
using System.Net;
using System;
using System.Collections.Generic;
using System.Web.Http.Tracing;
using Microsoft.Azure.Mobile.Server;

namespace BeerDrinkin.Service.Controllers
{
     [Authorize]
    public class BinaryItemController : ApiController
    {
        private readonly MobileAppSettingsDictionary settings;
        private readonly ITraceWriter tracer;

        public BinaryItemController()
        {
            settings = Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            tracer = Configuration.Services.GetTraceWriter();
        }

        /*
        // GET api/BinaryItem
        public List<string> Get(string objectId, string type)
        {
            var context = new BeerDrinkinContext();
            return
                context.BinaryItems.Where(f => f.ObjectId == objectId && f.BinaryType == type)
                    .Select(f => f.BinaryUrl)
                    .ToList();
        }*/

        // GET api/BinaryItem
        public List<string> Get(string userId)
        {
            var context = new BeerDrinkinContext();
            var photos =
                context.BinaryItems.Where(f => f.UserId == userId)
                    .Select(f => f.BinaryUrl)
                    .ToList();
            return photos;
        }

        // POST api/BinaryItem
        public async Task<HttpResponseMessage> Post(BinaryUploadRequest binaryUploadRequest)
        {
            var binaryItem = new BinaryItem
            {
                Id = Guid.NewGuid().ToString("N"),
                ObjectId = binaryUploadRequest.BinaryId,
                BinaryType = binaryUploadRequest.BinaryType,
                UserId = binaryUploadRequest.UserId
            };

            binaryItem.BinaryUrl =
                await BlobUtils.SaveBinaryToAzureStorage(settings, binaryItem.Id, binaryUploadRequest.BinaryData);

            if (!string.IsNullOrEmpty(binaryItem.BinaryUrl))
            {
                BeerDrinkinContext context = new BeerDrinkinContext();
                context.BinaryItems.Add(binaryItem);
                await context.SaveChangesAsync();
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }

            return this.Request.CreateResponse(HttpStatusCode.Conflict,
                "Something wrong");
        }
    }
}