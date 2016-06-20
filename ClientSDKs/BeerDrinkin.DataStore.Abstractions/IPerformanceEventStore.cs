using System;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.DataStore.Abstractions
{
    public interface IPerformanceEventStore : IBaseStore<PerformanceEvent>
    {
    }
}

