using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Models;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using OpenWeatherMap;
using BeerDrinkin.Service.Utils;

namespace BeerDrinkin.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class CheckInItemController : TableController<CheckInItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
            //Enable SoftDelete to simplify offline sync
            DomainManager = new EntityDomainManager<CheckInItem>(context, Request, Services, true);
        }

        // GET tables/CheckInItem
        public IQueryable<CheckInItem> GetAllCheckInItems()
        {
            return Query();
        }

        // GET tables/CheckInItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CheckInItem> GetCheckInItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CheckInItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CheckInItem> PatchCheckInItem(string id, Delta<CheckInItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/CheckInItem
        public async Task<IHttpActionResult> PostCheckInItem(CheckInItem item)
        {
            if (item.Longitude != 0)
            {
                var client = new OpenWeatherMapClient();
                var currentWeather = await client.CurrentWeather.GetByCoordinates(new Coordinates { Longitude = item.Longitude, Latitude = item.Latitude });
                item.Weather = currentWeather.ToWeatherCondition();
            }            

            CheckInItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CheckInItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCheckInItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}