using System;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.DataStore.Azure.Stores;

namespace BeerDrinkin.DataStore.Azure
{
    public class PerformanceEventStore : BaseStore<PerformanceEvent>, IPerformanceEventStore
    {
        public PerformanceEventStore()
        {
        }
    }
}

