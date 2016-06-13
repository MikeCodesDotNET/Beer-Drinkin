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

        public string ImageSmall { get; set; }
        public string ImageMedium { get; set; }
        public string ImageLarge { get; set; }

        public string Established { get; set; }
        public bool IsOrganic { get; set; }
        public string Website { get; set; }
    }
}
