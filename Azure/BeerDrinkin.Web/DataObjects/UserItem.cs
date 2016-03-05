using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerDrinkin.Web.DataObjects
{
    public class UserItem 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        public string AvatarUrl { get; set; }
    }
}