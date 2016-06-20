using System;
namespace BeerDrinkin.DataObjects
{
    public class PerformanceEvent : BaseDataObject
    {
        public string UserId { get; set; }
        public string EventName { get; set;}
        public double Elapsed { get; set;}
    }
}

