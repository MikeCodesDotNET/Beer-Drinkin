using System.ComponentModel.DataAnnotations;

namespace BeerDrinkin.DataObjects
{
    public class Rating : BaseDataObject
    {
        public int Score { get; set; }

        [Required]
        public virtual User User { get; set; }
        public string Review { get; set; }
    }
}