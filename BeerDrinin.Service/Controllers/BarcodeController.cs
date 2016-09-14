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
    public class BarcodeController : TableController<Barcode>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Barcode>(context, Request);
        }

        // GET tables/Barcode
        public IQueryable<Barcode> GetAllBarcode()
        {
            return Query(); 
        }

        // GET tables/Barcode/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Barcode> GetBarcode(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Barcode/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Barcode> PatchBarcode(string id, Delta<Barcode> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Barcode
        public async Task<IHttpActionResult> PostBarcode(Barcode item)
        {
            Barcode current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Barcode/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteBarcode(string id)
        {
             return DeleteAsync(id);
        }
    }
}
