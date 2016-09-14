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
    public class DeviceInfoController : TableController<DeviceInfo>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<DeviceInfo>(context, Request);
        }

        // GET tables/DeviceInfo
        public IQueryable<DeviceInfo> GetAllDeviceInfo()
        {
            return Query(); 
        }

        // GET tables/DeviceInfo/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DeviceInfo> GetDeviceInfo(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/DeviceInfo/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DeviceInfo> PatchDeviceInfo(string id, Delta<DeviceInfo> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/DeviceInfo
        public async Task<IHttpActionResult> PostDeviceInfo(DeviceInfo item)
        {
            DeviceInfo current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/DeviceInfo/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDeviceInfo(string id)
        {
             return DeleteAsync(id);
        }
    }
}
