using System;
using System.Collections.Generic;

#if !CLIENT
using Microsoft.WindowsAzure.Mobile.Service;
#endif
namespace BeerDrinkin.Service.DataObjects
{
    public class UserItem : EntityData
    {
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public bool IsMale { get; set; }
		public string AvatarUrl { get; set; }
		public virtual AddressItem Address { get; set; }
		public virtual ICollection<CheckInItem> CheckIns { get; set; }
    }
}