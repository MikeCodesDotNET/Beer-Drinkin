using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Models;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace BeerDrinkin.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class BeerItemController : TableController<BeerItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
            //Enable SoftDelete to simplify offline sync
            DomainManager = new EntityDomainManager<BeerItem>(context, Request, Services, enableSoftDelete: true);
        }

        // GET tables/BeerItem
        public IQueryable<BeerItem> GetAllBeerItems()
        {
            return Query();
        }

        // GET tables/BeerItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<BeerItem> GetBeerItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/BeerItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<BeerItem> PatchBeerItem(string id, Delta<BeerItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/BeerItem
        public async Task<IHttpActionResult> PostBeerItem(BeerItem item)
        {
            BeerItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/BeerItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteBeerItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}