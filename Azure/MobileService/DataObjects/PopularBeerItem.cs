using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#if !CLIENT
using Microsoft.Azure.Mobile.Server;
#endif

namespace BeerDrinkin.Service.DataObjects
{
    public class PopularBeerItem : EntityData
    {
        public string CountryCode { get; set; }
        public string BeerId { get; set; }
    }
}