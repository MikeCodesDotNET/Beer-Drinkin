using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerDrinkin.Web.DataObjects
{
    public class PhotoItem 
    {
        public string LargeUrl { get; set; }
        public string MediumUrl { get; set; }
        public string SmallUrl { get; set; }
        public int BeerId { get; set; }
        public int UserId{ get; set; }
    }
}
