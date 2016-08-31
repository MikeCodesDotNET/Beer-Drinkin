using System.Collections.Generic;

namespace BeerDrinkin.DataObjects
{
    public class Beer : BaseDataObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BreweryId { get; set; }
        public string StyleId { get; set; }
        public virtual Style Style { get; set; }
        public string OriginCountry { get; set;}
        public double? Abv { get; set; }

        public virtual List<Image> Images { get; set; }
        public virtual Image CoverPhoto { get; set; }
        public virtual List<Rating> Ratings { get; set; }

        public string BreweryDbId { get; set; }
        public string RateBeerId { get; set; }
    }
}
