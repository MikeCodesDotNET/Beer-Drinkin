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
    public class BeerItemController : TableController<Beer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
            //Enable SoftDelete to simplify offline sync
            DomainManager = new EntityDomainManager<Beer>(context, Request, Services, enableSoftDelete: true);
        }

        // GET tables/Beer
        public IQueryable<Beer> GetAllBeerItems()
        {
            return Query();
        }

        // GET tables/Beer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Beer> GetBeerItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Beer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Beer> PatchBeerItem(string id, Delta<Beer> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Beer
        public async Task<IHttpActionResult> PostBeerItem(Beer item)
        {
            Beer current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Beer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteBeerItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}