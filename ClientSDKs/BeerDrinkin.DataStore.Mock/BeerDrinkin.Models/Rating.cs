namespace BeerDrinkin.Models
{
    public class Rating : BaseModel
    {
        public int Score { get; set; }
        public virtual User User { get; set; }
        public string Review { get; set; }

        /// <summary>
        /// Get or sets the checkin item associated with the rating
        /// </summary>
        public virtual CheckIn CheckIn { get; set; }
    }
}