using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerDrinkin.Web.DataObjects
{
    public class BeerItem 
    {
        public int Id { get; set; }
        public string BreweryDbId { get; set; }
        public string RateBeerId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Brewery { get; set; }
        public string BreweryId { get; set; }
        public string StyleId { get; set; }
        public string Abv { get; set; }
        public string Upc { get; set; }

        public string ImageSmall { get; set; }
        public string ImageMedium { get; set; }
        public string ImageLarge { get; set; }
    }
}
