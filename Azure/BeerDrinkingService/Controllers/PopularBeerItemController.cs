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
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class PopularBeerItemController : TableController<PopularBeerItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
            DomainManager = new EntityDomainManager<PopularBeerItem>(context, Request, Services);
        }

        // GET tables/PopularBeerItem
        public IQueryable<PopularBeerItem> GetAllPopularBeerItem()
        {
            return Query(); 
        }

        // GET tables/PopularBeerItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PopularBeerItem> GetPopularBeerItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PopularBeerItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PopularBeerItem> PatchPopularBeerItem(string id, Delta<PopularBeerItem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/PopularBeerItem
        public async Task<IHttpActionResult> PostPopularBeerItem(PopularBeerItem item)
        {
            PopularBeerItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PopularBeerItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePopularBeerItem(string id)
        {
             return DeleteAsync(id);
        }

    }
}