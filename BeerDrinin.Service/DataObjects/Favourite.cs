namespace BeerDrinkin.DataObjects
{
    public class Favourite : BaseDataObject
    {
        public virtual User User { get; set; }
        public virtual Beer Beer{ get; set; }
    }
}