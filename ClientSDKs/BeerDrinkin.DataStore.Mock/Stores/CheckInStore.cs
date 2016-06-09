using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;

namespace BeerDrinkin.DataStore.Mock.Stores
{
    public class CheckInStore : BaseStore<CheckIn>, ICheckInStore
    {
        readonly List<CheckIn> checkIns;
        public CheckInStore()
        {
            checkIns = new List<CheckIn>();
        }
        public override Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }

        public override Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public Task<IEnumerable<CheckIn>> GetCheckInsForBeer(string beerId)
        {
            return Task.FromResult(checkIns.Where(a => a.BeerId == beerId));
        }

        public override Task<bool> InsertAsync(CheckIn item)
        {
            checkIns.Add(item);
            return Task.FromResult(true);
        }

    }
}
