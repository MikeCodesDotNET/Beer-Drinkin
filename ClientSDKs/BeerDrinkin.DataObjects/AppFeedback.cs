using System;
namespace BeerDrinkin.DataObjects
{
    public class AppFeedback : BaseDataObject
    {
        public string UserId {get; set;}
        public string Email { get; set;}
        public string Message { get; set;}
    }
}

