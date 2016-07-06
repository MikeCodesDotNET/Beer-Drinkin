using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Threading.Tasks;
using System.Linq;

namespace BeerDrinkin.Service.Controllers
{
    [MobileAppController]
    public class BeerCoverPhotoController : ApiController
    {
        // GET api/BeerCoverPhoto
        public async Task<string> Get(string beerId)
        {
            var context = new Models.BeerDrinkinContext();

            var beer = context.Beers.FirstOrDefault(x => x.Id == beerId);
            return beer.CoverPhoto;
        }
    }
}
