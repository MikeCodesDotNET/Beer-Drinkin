using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.DataObjects
{
    public class CheckInEnvironmentalCondition
    {
        /// <summary>
        /// In Degrees *c
        /// </summary>
        public double Tempature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public bool SunHasSet { get; set; }
        public string CountryCode { get; set; }
        public string CheckInId { get; set; }
        
    }
}
