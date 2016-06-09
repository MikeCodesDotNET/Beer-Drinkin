namespace BeerDrinkin.DataObjects
{
    public class Rating : BaseDataObject
    {
        public int Score { get; set; }
        public string UserId { get; set; }
        public string Review { get; set; }
        public string CheckIn { get; set; }
    }
}