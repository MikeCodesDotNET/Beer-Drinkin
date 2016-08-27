using System;
using System.Collections.Generic;

namespace BeerDrinkin.DataObjects
{
    public class User : BaseDataObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string EmailAddress { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateOfBirth { get; set; }

        public DateTime LastSeen {get; set;}
        public string ProfilePictureUri { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string CoverPhoto { get; set;}

        public List<User> Followers { get; set;}
        public List<User> Following { get; set;}
        public List<CheckIn> CheckIns { get; set;}
        public List<Image> Photos { get; set;}
    }
}