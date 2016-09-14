using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.DataObjects
{
    public class Style : BaseDataObject
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public double IbuMin { get; set; }
        public double IbuMax { get; set; }
        public double AbvMin { get; set; }
        public double AbvMax { get; set; }
        public double SrmMin { get; set; }
        public double SrmMax { get; set; }
        public double OgMin { get; set; }
        public double FgMin { get; set; }
        public double FgMax { get; set; } 
    }
}
