using System;

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
        public string ProfilePictureUri { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}