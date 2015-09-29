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
    public class ReviewItemController : TableController<ReviewItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
            //Enable SoftDelete to simplify offline sync
            DomainManager = new EntityDomainManager<ReviewItem>(context, Request, Services, enableSoftDelete: true);
        }

        // GET tables/ReviewItem
        public IQueryable<ReviewItem> GetAllReviewItems()
        {
            return Query();
        }

        // GET tables/ReviewItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ReviewItem> GetReviewItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ReviewItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ReviewItem> PatchReviewItem(string id, Delta<ReviewItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/ReviewItem
        public async Task<IHttpActionResult> PostReviewItem(ReviewItem item)
        {
            ReviewItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ReviewItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteReviewItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}