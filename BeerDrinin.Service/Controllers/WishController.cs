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
    public class WishController : TableController<Wish>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Wish>(context, Request);
        }

        // GET tables/Wish
        public IQueryable<Wish> GetAllWish()
        {
            return Query(); 
        }

        // GET tables/Wish/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Wish> GetWish(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Wish/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Wish> PatchWish(string id, Delta<Wish> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Wish
        public async Task<IHttpActionResult> PostWish(Wish item)
        {
            Wish current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Wish/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteWish(string id)
        {
             return DeleteAsync(id);
        }
    }
}
