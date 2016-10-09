namespace BeerDrinkin.Models
{
    public class Favourite : BaseModel 
    {
        public virtual User User { get; set; }
        public virtual Beer Beer{ get; set; }
    }
}