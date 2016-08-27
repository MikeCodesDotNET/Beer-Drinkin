namespace BeerDrinkin.DataObjects
{
    public class WeatherCondition : BaseDataObject
    {       
        public string City { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
    }
}
