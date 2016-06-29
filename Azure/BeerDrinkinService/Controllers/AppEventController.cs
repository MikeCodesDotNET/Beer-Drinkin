using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Models;

namespace BeerDrinkin.Service.Controllers
{
    public class AppEventController : TableController<AppEvent>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
            DomainManager = new EntityDomainManager<AppEvent>(context, Request);
        }

        [Authorize]
        public IQueryable<AppEvent> GetAllAppEvent()
        {
            return Query(); 
        }

        [Authorize]
        public SingleResult<AppEvent> GetAppEvent(string id)
        {
            return Lookup(id);
        }

        [Authorize]
        public Task<AppEvent> PatchAppEvent(string id, Delta<AppEvent> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/AppEvent
        public async Task<IHttpActionResult> PostAppEvent(AppEvent item)
        {
            AppEvent current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        [Authorize]
        public Task DeleteAppEvent(string id)
        {
             return DeleteAsync(id);
        }
    }
}
