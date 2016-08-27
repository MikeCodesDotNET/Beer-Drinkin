using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.DataObjects
{
    public class Brewery : BaseDataObject
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string MailListUrl { get; set; }
        public virtual List<Image> Images { get; set; }
        public string Website { get; set; }
        public virtual List<Beer> Beers { get; set; }
    }
}
