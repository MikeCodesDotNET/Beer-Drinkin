using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.Models
{
    public class AppEvent : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string UserId { get; set; }
    }
}
