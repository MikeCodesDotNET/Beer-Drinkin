using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#if !CLIENT
using Microsoft.Azure.Mobile.Server;
#endif

namespace BeerDrinkin.Service.DataObjects
{
    public class Brewery : EntityData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Images ImageUrls { get; set; }
        public string Website { get; set; }
        public bool IsOrganic { get; set; }
    }
}