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

        /// <summary>
        /// Gets or sets the barcode (UPC) of the beer
        /// </summary>
        public string Upc { get; set; }

        /// <summary>
        /// Gets or set the Image URLs
        /// </summary>
        public Image Image { get; set; }

        public bool HasImages { get; set; }

    }
}
