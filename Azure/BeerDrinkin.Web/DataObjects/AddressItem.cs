using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace BeerDrinkin.Web.DataObjects
{
    public class AddressItem 
    {
        public int Id { get; set; }
        public string NumberOrName { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
    }
}