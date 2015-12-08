using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;

using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.DataObjects;
using Microsoft.Azure.Mobile.Server.Config;

namespace BeerDrinkin.Service.Controllers
{
     [Authorize, MobileAppController]
    public class HeaderInfoController : ApiController
    {
        // GET api/HeaderInfo
        public HeaderInfo Get(string userId)
        {
            BeerDrinkinContext context = new BeerDrinkinContext();
                         
            var headerInfo = new HeaderInfo { Username = userId };
            var checkIns = context.CheckInItems.Where(f => f.CheckedInBy == userId);
            var photos = context.BinaryItems.Where(f => f.UserId == userId);

            headerInfo.CheckIns = checkIns.Count(f => f.Deleted == false);
            headerInfo.Photos = photos.Count(f => f.Deleted == false);
            headerInfo.Ratings = checkIns.Count(f => f.Rating > 0);
            return headerInfo;
        }

    }
}
