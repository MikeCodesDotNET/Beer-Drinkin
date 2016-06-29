using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.DataObjects
{
    public class Wish : BaseDataObject
    {
        public User User { get; set; }
        public Beer Beer { get; set; }
    }
}
