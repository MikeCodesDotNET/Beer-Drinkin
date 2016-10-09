using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.Models
{
    public class Barcode : BaseModel
    {
        public bool Validated { get; set; }
        public string UPC { get; set; }
        public string BeerId { get; set; }
    }
}
