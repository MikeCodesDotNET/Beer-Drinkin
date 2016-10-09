using System;
namespace BeerDrinkin.Models
{
    public class AppFeedback : BaseModel
    {
        public string UserId {get; set;}
        public string Email { get; set;}
        public string Message { get; set;}
    }
}

