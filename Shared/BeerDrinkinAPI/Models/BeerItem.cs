using System;
using System.Runtime.Serialization;

#if !CLIENT
using Microsoft.WindowsAzure.Mobile.Service;
#endif
namespace BeerDrinkin.Service.DataObjects
{
    public class BeerItem:EntityData
    {
        public int RateBeerId { get; set; }

        public string Name{ get; set; }

        public string Description{ get; set; }

        public string Brewery{ get; set; }

        public string BreweryId { get; set; }

        public string StyleId{ get; set; }

        public double? ABV { get; set; }

        public string Upc { get; set; }

        public string Price { get; set; }

        public string ImageSmall { get; set; }

        public string ImageMedium { get; set; }

        public string ImageLarge { get; set; }
    }
}
