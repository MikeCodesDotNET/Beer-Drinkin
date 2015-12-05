using System;
using System.Runtime.Serialization;
using OpenWeatherMap;

#if !CLIENT
using Microsoft.WindowsAzure.Mobile.Service;
#endif
namespace BeerDrinkin.Service.DataObjects
{
    public class CheckInItem:EntityData
    {
        public string BeerId { get; set; }
        public string CheckedInBy { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public string FourSquareId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public WeatherCondition Weather { get; set; }

#if CLIENT
        [IgnoreDataMember]
        public string[] Image {get;set;}
        [IgnoreDataMember]
        public Beer Beer{get;set;}
#endif
    }
}
