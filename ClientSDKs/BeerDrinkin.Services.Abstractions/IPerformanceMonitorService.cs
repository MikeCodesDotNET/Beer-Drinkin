using System;
using System.Collections;

namespace BeerDrinkin.Services.Abstractions
{
    public interface IPerformanceMonitorService
    {
        void Track(string eventName);

        void Track(string eventName, IDictionary details);

        void Track(string eventName, TimeSpan time);
    }
}

