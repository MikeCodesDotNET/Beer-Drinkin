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
    public class WeatherConditionController : TableController<WeatherCondition>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<WeatherCondition>(context, Request);
        }

        // GET tables/WeatherCondition
        public IQueryable<WeatherCondition> GetAllWeatherCondition()
        {
            return Query(); 
        }

        // GET tables/WeatherCondition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<WeatherCondition> GetWeatherCondition(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/WeatherCondition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<WeatherCondition> PatchWeatherCondition(string id, Delta<WeatherCondition> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/WeatherCondition
        public async Task<IHttpActionResult> PostWeatherCondition(WeatherCondition item)
        {
            WeatherCondition current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/WeatherCondition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteWeatherCondition(string id)
        {
             return DeleteAsync(id);
        }
    }
}
