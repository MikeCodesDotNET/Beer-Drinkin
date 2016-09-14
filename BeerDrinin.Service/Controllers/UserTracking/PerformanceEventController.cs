using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Service.Models;

namespace BeerDrinkin.Service.Controllers
{
    public class PerformanceEventController : TableController<PerformanceEvent>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<PerformanceEvent>(context, Request);
        }

        // GET tables/PerformanceEvent
        public IQueryable<PerformanceEvent> GetAllPerformanceEvent()
        {
            return Query(); 
        }

        // GET tables/PerformanceEvent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PerformanceEvent> GetPerformanceEvent(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PerformanceEvent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PerformanceEvent> PatchPerformanceEvent(string id, Delta<PerformanceEvent> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/PerformanceEvent
        public async Task<IHttpActionResult> PostPerformanceEvent(PerformanceEvent item)
        {
            PerformanceEvent current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PerformanceEvent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePerformanceEvent(string id)
        {
             return DeleteAsync(id);
        }
    }
}
