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
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class KeywordSpellingCorrectionController : TableController<KeywordSpellingCorrection>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BeerDrinkinContext context = new BeerDrinkinContext();
        }

        // GET tables/KeywordSpellingCorrection
        public IQueryable<KeywordSpellingCorrection> GetAllKeywordSpellingCorrections()
        {
            return Query();
        }

        // GET tables/KeywordSpellingCorrection/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<KeywordSpellingCorrection> GetKeywordSpellingCorrection(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/KeywordSpellingCorrection/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<KeywordSpellingCorrection> PatchKeywordSpellingCorrection(string id, Delta<KeywordSpellingCorrection> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/KeywordSpellingCorrection
        public async Task<IHttpActionResult> PostKeywordSpellingCorrection(KeywordSpellingCorrection item)
        {
            KeywordSpellingCorrection current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/KeywordSpellingCorrection/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteKeywordSpellingCorrectionm(string id)
        {
             return DeleteAsync(id);
        }
        
    }
}