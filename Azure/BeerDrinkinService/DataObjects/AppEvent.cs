using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.DataObjects
{
    public class AppEvent : BaseDataObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Time { get; set; }
        public virtual User User { get; set; }
    }
}
