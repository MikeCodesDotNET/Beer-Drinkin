namespace BeerDrinkin.DataObjects
{
    public class CheckIn : BaseDataObject
    {
        public string BeerId { get; set; }
        public string UserId { get; set; }
        public string[] Images { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool IsBottled { get; set; }
        public string RatingId { get; set; }
        

#if !BACKEND
        public Rating Rating { get; set; }
#endif  
    }
}
