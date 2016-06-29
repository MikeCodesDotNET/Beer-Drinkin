using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Models;

namespace BeerDrinkin.Service.Controllers
{
    public class CheckInEnvironmentalConditionController : TableController<CheckInEnvironmentalCondition>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
            DomainManager = new EntityDomainManager<CheckInEnvironmentalCondition>(context, Request);
        }

        // GET tables/CheckInEnvironmentalCondition
        public IQueryable<CheckInEnvironmentalCondition> GetAllCheckInEnvironmentalCondition()
        {
            return Query(); 
        }

        // GET tables/CheckInEnvironmentalCondition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CheckInEnvironmentalCondition> GetCheckInEnvironmentalCondition(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CheckInEnvironmentalCondition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CheckInEnvironmentalCondition> PatchCheckInEnvironmentalCondition(string id, Delta<CheckInEnvironmentalCondition> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/CheckInEnvironmentalCondition
        public async Task<IHttpActionResult> PostCheckInEnvironmentalCondition(CheckInEnvironmentalCondition item)
        {
            CheckInEnvironmentalCondition current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CheckInEnvironmentalCondition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCheckInEnvironmentalCondition(string id)
        {
             return DeleteAsync(id);
        }
    }
}
