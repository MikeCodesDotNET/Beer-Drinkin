using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.DataStore.Azure.Stores;

namespace BeerDrinkin.DataStore.Azure
{
    public class CheckInStore : BaseStore<CheckIn>, ICheckInStore
    {
        public override Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }

        public override Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public Task<IEnumerable<CheckIn>> GetCheckIns(string beerId)
        {
            return Table.Where(s => s.BeerId == beerId).ToEnumerableAsync();
        }
    }
}
