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
    public class FollowerItemController : TableController<FollowerItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
            //Enable SoftDelete to simplify offline sync
            DomainManager = new EntityDomainManager<FollowerItem>(context, Request, Services, enableSoftDelete: true);
        }

        // GET tables/FollowerItem
        public IQueryable<FollowerItem> GetAllFollowerItems()
        {
            return Query();
        }

        // GET tables/FollowerItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<FollowerItem> GetFollowerItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/FollowerItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<FollowerItem> PatchFollowerItem(string id, Delta<FollowerItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/FollowerItem
        public async Task<IHttpActionResult> PostFollowerItem(FollowerItem item)
        {
            FollowerItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/FollowerItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFollowerItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}