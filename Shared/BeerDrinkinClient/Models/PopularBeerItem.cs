using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerDrinkin.Models
{
    public class PopularBeerItem : EntityData
    {
        public string CountryCode { get; set; }
        public string BeerId { get; set; }
    }
}