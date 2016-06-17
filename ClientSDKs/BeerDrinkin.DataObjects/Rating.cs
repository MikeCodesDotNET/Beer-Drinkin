namespace BeerDrinkin.DataObjects
{
    public class Rating : BaseDataObject
    {
        public int Score { get; set; }
        public string UserId { get; set; }
        public string Review { get; set; }

        /// <summary>
        /// Get or sets the checkin item associated with the rating
        /// </summary>
        public virtual CheckIn CheckIn { get; set; }
    }
}