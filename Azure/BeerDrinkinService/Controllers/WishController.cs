using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Models;
using BeerDrinkin.Service.Helpers;

namespace BeerDrinkin.Service.Controllers
{
    public class WishController : TableController<Wish>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
            DomainManager = new EntityDomainManager<Wish>(context, Request);
        }

        [QueryableExpand("Beer, User")]
        public IQueryable<Wish> GetAllWishes(string userId)
        {
            var items = Query();
            var results = items.Where(x => x.User.Id == userId);
            return results;
        }

        [QueryableExpand("Beer, User")]
        public SingleResult<Wish> GetWish(string id)
        {
            return Lookup(id);
        }

        [Authorize]
        public Task<Wish> PatchWish(string id, Delta<Wish> patch)
        {
             return UpdateAsync(id, patch);
        }

        [Authorize]
        public async Task<IHttpActionResult> PostWish(Wish item)
        {
            Wish current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        [Authorize]
        public Task DeleteWish(string id)
        {
             return DeleteAsync(id);
        }
    }
}
