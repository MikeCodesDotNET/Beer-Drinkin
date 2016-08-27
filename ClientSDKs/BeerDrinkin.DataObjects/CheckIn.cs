using System.Collections.Generic;

namespace BeerDrinkin.DataObjects
{
    public class CheckIn : BaseDataObject
    {
        public virtual Beer Beer { get; set; }
        public virtual User User { get; set; }
        public virtual List<Image> Images { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public bool IsBottled { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual WeatherCondition Weather { get; set; }
        
    }
}
