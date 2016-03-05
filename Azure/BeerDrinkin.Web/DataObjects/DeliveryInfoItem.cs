using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerDrinkin.Web.DataObjects
{
    public class DeliveryInfoItem
    {
        public int Id { get; set; }

        public Dictionary<string, decimal> Prices { get; set; }
    }
}