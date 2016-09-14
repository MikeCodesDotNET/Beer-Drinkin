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
    public class FavouriteController : TableController<Favourite>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Favourite>(context, Request);
        }

        // GET tables/Favourite
        public IQueryable<Favourite> GetAllFavourite()
        {
            return Query(); 
        }

        // GET tables/Favourite/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Favourite> GetFavourite(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Favourite/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Favourite> PatchFavourite(string id, Delta<Favourite> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Favourite
        public async Task<IHttpActionResult> PostFavourite(Favourite item)
        {
            Favourite current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Favourite/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFavourite(string id)
        {
             return DeleteAsync(id);
        }
    }
}
