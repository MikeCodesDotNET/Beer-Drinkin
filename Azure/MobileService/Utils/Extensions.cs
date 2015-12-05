using BeerDrinkin.Service.DataObjects;
using BreweryDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.Service.Utils
{
    public static class Extensions
    {
       

        public static WeatherCondition ToWeatherCondition(this OpenWeatherMap.CurrentWeatherResponse response)
        {
            var weatherCondition = new WeatherCondition
            {
                CityName = response.City.Name,
                MinimumTemperature = response.Temperature.Min,
                MaximumTemperature = response.Temperature.Max,
                Temperature = response.Temperature.Value,
                WindSpeed = response.Wind.Speed.Value,
                Precipitation = response.Precipitation.Value,
                Humidity = response.Humidity.Value,
                SunSet = response.City.Sun.Set,
                SunRise = response.City.Sun.Rise
            };

            return weatherCondition;
        }
    }
}
