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
    public class BreweryController : TableController<Brewery>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Brewery>(context, Request);
        }

        // GET tables/Brewery
        public IQueryable<Brewery> GetAllBrewery()
        {
            return Query(); 
        }

        // GET tables/Brewery/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Brewery> GetBrewery(string id)
        {
            return Lookup(id);
        }

        [AdminAuthorize]
        public Task<Brewery> PatchBrewery(string id, Delta<Brewery> patch)
        {
             return UpdateAsync(id, patch);
        }

        [AdminAuthorize]
        public async Task<IHttpActionResult> PostBrewery(Brewery item)
        {
            Brewery current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        [AdminAuthorize]
        public Task DeleteBrewery(string id)
        {
             return DeleteAsync(id);
        }
    }
}
