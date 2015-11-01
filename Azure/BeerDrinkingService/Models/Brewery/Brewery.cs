using System;
using System.Collections.Generic;

namespace BeerDrinkin.Service.Models
{
    public class Brewery
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IsOrganic { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Established { get; set; }
    }
}

