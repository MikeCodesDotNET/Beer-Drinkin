using System;

namespace BeerDrinkin.Models
{
    public class AddressItem : EntityData
    {
        public string NumberOrName { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
    }
}

