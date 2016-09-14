using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Service.Indentity;
using BeerDrinkin.Service.Models;

namespace BeerDrinkin.Service.Controllers
{
    public class BeerController : TableController<Beer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Beer>(context, Request);
        }

        // GET tables/Beer
        public IQueryable<Beer> GetAllBeer()
        {
            return Query(); 
        }

        // GET tables/Beer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Beer> GetBeer(string id)
        {
            return Lookup(id);
        }

        [AdminAuthorize]
        public Task<Beer> PatchBeer(string id, Delta<Beer> patch)
        {
             return UpdateAsync(id, patch);
        }

        [AdminAuthorize]
        public async Task<IHttpActionResult> PostBeer(Beer item)
        {
            Beer current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        [AdminAuthorize]
        public Task DeleteBeer(string id)
        {
             return DeleteAsync(id);
        }
    }
}
