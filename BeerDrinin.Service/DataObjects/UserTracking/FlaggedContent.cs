using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerDrinkin.DataObjects
{
    public class FlaggedContent : BaseDataObject
    {
        public bool IsImage { get; set; }
        public bool IsAdult { get; set; }
        public string UserId { get; set; }
        public string ImageId { get; set; }
        public string BeerId { get; set; }
        public string Description { get; set; }
        public bool Reviewed { get; set; }
    }
}