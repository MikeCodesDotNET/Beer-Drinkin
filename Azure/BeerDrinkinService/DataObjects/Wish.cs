using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.DataObjects
{
    public class Wish : BaseDataObject
    {
        public virtual User User { get; set; }
        public virtual Beer Beer { get; set; }
    }
}
