using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Service.Models;

namespace BeerDrinin.Service.Controllers
{
    public class FlaggedContentController : TableController<FlaggedContent>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<FlaggedContent>(context, Request);
        }

        // GET tables/FlaggedContent
        public IQueryable<FlaggedContent> GetAllFlaggedContent()
        {
            return Query(); 
        }

        // GET tables/FlaggedContent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<FlaggedContent> GetFlaggedContent(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/FlaggedContent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<FlaggedContent> PatchFlaggedContent(string id, Delta<FlaggedContent> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/FlaggedContent
        public async Task<IHttpActionResult> PostFlaggedContent(FlaggedContent item)
        {
            FlaggedContent current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/FlaggedContent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFlaggedContent(string id)
        {
             return DeleteAsync(id);
        }
    }
}
