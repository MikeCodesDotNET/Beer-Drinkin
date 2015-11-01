using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using BeerDrinkin.Service.Models;
using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class HeaderInfoController : ApiController
    {
        public ApiServices Services { get; set; }

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
