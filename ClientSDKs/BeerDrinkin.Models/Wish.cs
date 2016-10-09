using System;
using System.Collections.Generic;
using System.Text;

namespace BeerDrinkin.Models
{
    public class Wish : BaseModel
    {
        public string UserId { get; set; }
        public string BeerId { get; set; }
    }
}
