using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Models;
using Microsoft.Azure.Mobile.Server;

namespace BeerDrinkin.Service.Controllers
{
    [Authorize]
    public class AccountItemController : TableController<AccountItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
        }

        // GET tables/AccountItem
        public IQueryable<AccountItem> GetAllAccountItem()
        {
            return Query();
        }

        // GET tables/AccountItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<AccountItem> GetAccountItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/AccountItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<AccountItem> PatchAccountItem(string id, Delta<AccountItem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/AccountItem
        public async Task<IHttpActionResult> PostAccountItem(AccountItem item)
        {
            AccountItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/AccountItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAccountItem(string id)
        {
             return DeleteAsync(id);
        }
        
    }
}