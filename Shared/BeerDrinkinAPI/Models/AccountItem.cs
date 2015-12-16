using System;

#if !CLIENT
using Microsoft.WindowsAzure.Mobile.Service;
#endif

namespace BeerDrinkin.Service.DataObjects
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