using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.DataObjects
{
    public class Wish : BaseDataObject
    {
        public string BeerId { get; set; }
        public string UserId { get; set; }
    }
}
