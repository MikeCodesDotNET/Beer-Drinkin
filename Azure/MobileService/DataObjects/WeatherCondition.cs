
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#if !CLIENT
using Microsoft.Azure.Mobile.Server;
#endif

namespace BeerDrinkin.Service.DataObjects
{
    public class WeatherCondition : EntityData
    {
        public string CityName { get; set; }
        public double MinimumTemperature { get; set; }
        public double MaximumTemperature { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public double Precipitation { get; set; }
        public int Humidity { get; set; }
        public DateTime SunSet { get; set; }
        public DateTime SunRise { get; set; }
    }
}