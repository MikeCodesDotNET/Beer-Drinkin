using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Service.DataObjects
{
    public class Rating : BaseDataObject
    {
        public int Score { get; set; }
        public string RatedBy { get; set; }
        public string Review { get; set; }
        public string CheckIn { get; set; }
    }
}