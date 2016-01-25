using System;

namespace BeerDrinkin.Service.DataObjects
{
    public class PriceItem : EntityData
    {
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}

