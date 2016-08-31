using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.DataObjects
{
    public class Barcode : BaseDataObject
    {
        public bool Validated { get; set; }
        public string UPC { get; set; }
        public string BeerId { get; set; }
    }
}
