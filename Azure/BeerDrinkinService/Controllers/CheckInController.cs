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
    public class CheckInController : TableController<CheckIn>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
            DomainManager = new EntityDomainManager<CheckIn>(context, Request);
        }

        // GET tables/CheckIn
        public IQueryable<CheckIn> GetAllCheckIn()
        {
            return Query(); 
        }

        // GET tables/CheckIn/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CheckIn> GetCheckIn(string id)
        {
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
            CheckIn current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CheckIn/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCheckIn(string id)
        {
             return DeleteAsync(id);
        }
    }
}
