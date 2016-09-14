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
    public class StyleController : TableController<Style>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Style>(context, Request);
        }

        // GET tables/Style
        public IQueryable<Style> GetAllStyle()
        {
            return Query(); 
        }

        // GET tables/Style/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Style> GetStyle(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Style/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Style> PatchStyle(string id, Delta<Style> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Style
        public async Task<IHttpActionResult> PostStyle(Style item)
        {
            Style current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Style/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteStyle(string id)
        {
             return DeleteAsync(id);
        }
    }
}
