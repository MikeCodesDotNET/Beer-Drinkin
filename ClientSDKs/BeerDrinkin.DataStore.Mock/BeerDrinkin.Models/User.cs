using System;
using System.Collections.Generic;

namespace BeerDrinkin.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public bool IsMale { get; set; }
        public DateTime DateOfBirth { get; set; }

        public DateTime LastSeen {get; set;}
        public virtual Image Avatar { get; set; }
        public virtual Image CoverPhoto { get; set;}

        public virtual List<User> Followers { get; set;}
        public virtual List<User> Following { get; set;}
        public virtual List<CheckIn> CheckIns { get; set;}
        public virtual List<Image> Photos { get; set;}
        public virtual List<Favourite> Favourites { get; set; }
    }
}