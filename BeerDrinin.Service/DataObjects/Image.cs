using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.DataObjects
{
    public class Image : BaseDataObject
    {
        public string BeerId { get; set; }
        public string OwnerId { get; set; }

        public string LargeUrl { get; set; }
        public string MediumUrl { get; set; }
        public string SmallUrl { get; set; }
    }
}
