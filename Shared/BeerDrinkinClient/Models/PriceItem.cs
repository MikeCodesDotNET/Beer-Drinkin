using System;

namespace BeerDrinkin.Models
{
    public class PriceItem : EntityData
    {
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}

