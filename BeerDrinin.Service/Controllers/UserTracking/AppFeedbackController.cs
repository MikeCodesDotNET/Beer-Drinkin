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
    public class AppFeedbackController : TableController<AppFeedback>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<AppFeedback>(context, Request);
        }

        // GET tables/AppFeedback
        public IQueryable<AppFeedback> GetAllAppFeedback()
        {
            return Query(); 
        }

        // GET tables/AppFeedback/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<AppFeedback> GetAppFeedback(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/AppFeedback/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<AppFeedback> PatchAppFeedback(string id, Delta<AppFeedback> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/AppFeedback
        public async Task<IHttpActionResult> PostAppFeedback(AppFeedback item)
        {
            AppFeedback current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/AppFeedback/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAppFeedback(string id)
        {
             return DeleteAsync(id);
        }
    }
}
