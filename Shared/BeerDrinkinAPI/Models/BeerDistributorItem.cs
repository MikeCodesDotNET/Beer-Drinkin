using System;
using System.Collections.Generic;

namespace BeerDrinkin.Service.DataObjects
{
    public class BeerDistributorItem 
    {
        public string Name { get; set; }
        public AddressItem Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<BeerItem> Beers { get; set; }
        public DeliveryInfoItem DeliveryInfo { get; set; } 
    }
}


