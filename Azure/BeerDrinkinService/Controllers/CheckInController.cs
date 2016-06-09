using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BeerDrinkin.DataObjects;
using Microsoft.ApplicationInsights;
using System.Collections.Generic;
using BeerDrinkin.Models;

namespace BeerDrinkin.Controllers
{
    public class CheckInController : TableController<CheckIn>
    {
        TelemetryClient telemetryClient;
        BeerDrinkinContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new BeerDrinkinContext();
            DomainManager = new EntityDomainManager<CheckIn>(context, Request);
            telemetryClient = new TelemetryClient();
        }

        // GET tables/CheckIn
        public async Task <IEnumerable<CheckIn>> GetAllCheckIn(string userId)
        {
            telemetryClient.TrackEvent("GetCheckIns");

            var checkIns = context.CheckIns.Where(x => x.UserId == userId);            
            return checkIns; 
        }

        // GET tables/CheckIn/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CheckIn> GetCheckIn(string id)
        {
            var properties = new Dictionary<string, string>();
            properties.Add("CheckInId", id);
            telemetryClient.TrackEvent("GetCheckIn", properties);

            return Lookup(id);
        }

        // PATCH tables/CheckIn/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CheckIn> PatchCheckIn(string id, Delta<CheckIn> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/CheckIn
        public async Task<IHttpActionResult> PostCheckIn(CheckIn item)
        {
            var properties = new Dictionary<string, string>();
            properties.Add("CheckInId", item.Id);
            properties.Add("Owner", item.UserId);
            properties.Add("BeerId", item.BeerId);
            telemetryClient.TrackEvent("SaveCheckIn", properties);

            CheckIn current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CheckIn/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCheckIn(string id)
        {
            var properties = new Dictionary<string, string>();
            properties.Add("CheckInId", id);
            telemetryClient.TrackEvent("DeleteCheckIn", properties);

            return DeleteAsync(id);
        }
    }
}
