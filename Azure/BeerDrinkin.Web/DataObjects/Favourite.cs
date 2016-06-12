using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerDrinkin.DataObjects
{
    public class Favourite : BaseDataObject
    {
        public string UserId { get; set; }
        public string BeerId { get; set; }
    }
}