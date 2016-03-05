using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;

namespace BeerDrinkin.DataStore.Mock.Stores
{
    public class BeerStore : BaseStore<Beer>, IBeerStore
    {
		readonly List<Beer> beers;
		public BeerStore()
        {
			beers = new List<Beer>();
        }
        public override Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }

        public override Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

		public Task<IEnumerable<Beer>> GetCheckInsForBeer(string beerId)
        {
			return Task.FromResult(beers.Where(a => a.Id == beerId));
        }

		public override Task<bool> InsertAsync(Beer item)
        {
			beers.Add(item);
            return Task.FromResult(true);
        }

    }
}
