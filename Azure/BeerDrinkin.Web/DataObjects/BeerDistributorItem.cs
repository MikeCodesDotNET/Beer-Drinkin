using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeerDrinkin.Web.DataObjects
{
    public class BeerDistributorItem 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Custom)]
        public AddressItem Address { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Custom)]
        public DeliveryInfoItem DeliveryInfo { get; set; } 
    }
}