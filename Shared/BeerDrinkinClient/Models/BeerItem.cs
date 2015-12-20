using System;
using System.Runtime.Serialization;

namespace BeerDrinkin.Models
{
    public class BeerItem:EntityData
    {
        public int RateBeerId {get; set;}

        public string Name{get;set;}
        public string Description{get;set;}
        public string Brewery{get;set;}
        public string BreweryId { get; set;}
        public string StyleId{get;set;}
        public string ABV { get; set; }
        public string Upc { get; set;}

        public string ImageSmall {get; set;}
        public string ImageMedium {get; set;}
        public string ImageLarge {get; set;}
            
    }
}
