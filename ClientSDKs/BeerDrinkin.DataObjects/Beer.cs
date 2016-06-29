    namespace BeerDrinkin.DataObjects
{
    public class Beer : BaseDataObject
    {
        public string BreweryDbId { get; set; }
        public string RateBeerId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Brewery Brewery { get; set; }
        public string BreweryId { get; set; }
        public string StyleId { get; set; }
        public double? Abv { get; set; }
        public string Upc { get; set; }

        public string ImageSmall { get; set; }
        public string ImageMedium { get; set; }
        public string ImageLarge { get; set; }
    }
}
