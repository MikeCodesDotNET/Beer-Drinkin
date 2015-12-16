using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerDrinkin.Service.DataObjects
{
    public class PopularBeerItem : EntityData
    {
        public string CountryCode { get; set; }
        public string BeerId { get; set; }
    }
}