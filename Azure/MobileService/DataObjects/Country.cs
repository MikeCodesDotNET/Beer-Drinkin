using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#if !CLIENT
using Microsoft.Azure.Mobile.Server;
#endif

namespace BeerDrinkin.Service.DataObjects
{
    public class Country : EntityData
    {
        public string IsoCode { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string IsoThree { get; set; }
        public int NumberCode { get; set; }
    }
}