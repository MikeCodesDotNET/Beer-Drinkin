using System;


namespace BeerDrinkin.Models
{
    public class AccountItem : EntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        public string AvatarUrl { get; set; }
    }
}