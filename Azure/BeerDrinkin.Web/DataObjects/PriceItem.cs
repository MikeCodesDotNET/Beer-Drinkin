using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerDrinkin.Web.DataObjects
{
    public class PriceItem 
    {
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}