using System;
using System.Collections.Generic;
using System.Text;
using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.DataObjects
{
    public class CheckIn : BaseDataObject
    {
        public string BeerId { get; set; }
        public string CheckedInBy { get; set; }
        public string[] Images { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public bool IsBottled { get; set; }
        public string RatingId { get; set; }
        

#if !BACKEND
        public Rating Rating { get; set; }
#endif  
    }
}
