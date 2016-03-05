using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerDrinkin.Web.DataObjects
{
    public class CheckInItem 
    {
        public int Id { get; set; }
        public int BeerId { get; set; }
        public int UserId { get; set; }
        public string[] Images { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool IsBottled { get; set; }

    }
}