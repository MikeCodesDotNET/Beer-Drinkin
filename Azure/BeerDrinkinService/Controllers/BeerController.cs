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
using BeerDrinkin.Service.Helpers;

namespace BeerDrinkin.Controllers
{
    public class BeerController : TableController<Beer>
    {
        BeerDrinkinContext context;
        TelemetryClient telemetryClient;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new BeerDrinkinContext();
            DomainManager = new EntityDomainManager<Beer>(context, Request);
            telemetryClient = new TelemetryClient();
        }

        [QueryableExpand("Brewery, Style, Image")]
        public IQueryable<Beer> GetAllBeerItem()
        {
            telemetryClient.TrackEvent("GetAllBeers");
            return Query();
        }

        [QueryableExpand("Brewery, Style, Image")]
        public SingleResult<Beer> GetBeerItem(string id)
        {            
            var properties = new Dictionary<string, string>();
            properties.Add("BeerId", id);
            telemetryClient.TrackEvent("GetBeer", properties);

            return Lookup(id); 
        }

        [Authorize]
        public Task<Beer> PatchBeerItem(string id, Delta<Beer> patch)
        {
            return UpdateAsync(id, patch);
        }

        [Authorize]
        public async Task<IHttpActionResult> PostBeerItem(Beer item)
        {
            var properties = new Dictionary<string, string>();
            properties.Add("BeerId", item.Id);
            properties.Add("BeerName", item.Name);
            telemetryClient.TrackEvent("SaveBeer", properties);

            Beer current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        [Authorize]
        public Task DeleteBeerItem(string id)
        {
            var properties = new Dictionary<string, string>();
            properties.Add("BeerId", id);
            telemetryClient.TrackEvent("DeleteBeer", properties);

            return DeleteAsync(id);
        }
    }
}
