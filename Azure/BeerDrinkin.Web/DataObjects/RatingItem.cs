using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerDrinkin.Web.DataObjects
{
    public class RatingItem 
    {
        public int BeerId { get; set; }
        public int UserId { get; set; }
        public double Rating { get; set; }
    }
}