using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Models;
using Microsoft.ApplicationInsights;
using System.Collections.Generic;

namespace BeerDrinkin.Controllers
{
    public class RatingController : TableController<Rating>
    {
        BeerDrinkinContext context;
        TelemetryClient telemetryClient;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new BeerDrinkinContext();
            DomainManager = new EntityDomainManager<Rating>(context, Request);
            telemetryClient = new TelemetryClient();
        }

        // GET tables/Rating
        public IQueryable<Rating> GetAllRating()
        {
            telemetryClient.TrackEvent("GetAllRatings");
            return Query(); 
        }

        // GET tables/Rating/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Rating> GetRating(string id)
        {
            var properties = new Dictionary<string, string>();
            properties.Add("RatingId", id);
            telemetryClient.TrackEvent("GetRating", properties);

            return Lookup(id);
        }

        // PATCH tables/Rating/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Rating> PatchRating(string id, Delta<Rating> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Rating
        public async Task<IHttpActionResult> PostRating(Rating item)
        {
            Rating current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Rating/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRating(string id)
        {
            var properties = new Dictionary<string, string>();
            properties.Add("RatingId", id);
            telemetryClient.TrackEvent("DeleteRating", properties);

            return DeleteAsync(id);
        }
    }
}
