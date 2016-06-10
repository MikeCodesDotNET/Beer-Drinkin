using Microsoft.Azure.Search.Models;

namespace BeerDrinkin.DataObjects
{
    [SerializePropertyNamesAsCamelCase]
    public class AzureSearchBeerResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BreweryName { get; set; }
        public string BreweryId { get; set; }
        public string AvailableId { get; set; }
        public string[] Images { get; set; }
        public double? Abv { get; set; }
        public string Upc { get; set; }
        public double? Rating { get; set; }
        public int? Views { get; set; }
    }
}