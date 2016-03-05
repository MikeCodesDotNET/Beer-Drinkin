using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerDrinkin.Service.DataObjects
{
    public class HeaderInfoItem
    {
        public string Username { get; set; }
        public int CheckIns { get; set; }
        public int Photos { get; set; }
        public int Ratings { get; set; }
    }
}