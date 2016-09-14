using System;
using System.Collections;

namespace BeerDrinkin.DataObjects
{
    public class AppInsightsEvent : BaseDataObject
    {
        public string UserId { get; set; }
        public string EventName { get; set;}
        public double Elapsed { get; set;}
        public IDictionary Data { get; set;}
    }
}

