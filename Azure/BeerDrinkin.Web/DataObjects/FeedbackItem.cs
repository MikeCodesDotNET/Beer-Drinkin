using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerDrinkin.Web.DataObjects
{
    public class FeedbackItem 
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}