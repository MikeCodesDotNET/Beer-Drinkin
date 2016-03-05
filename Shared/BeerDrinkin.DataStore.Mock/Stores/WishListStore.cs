using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;

namespace BeerDrinkin.DataStore.Mock.Stores
{
	public class WishListStore : BaseStore<Wish>, IWishListStore
    {
        readonly List<Wish> wishes;
		public WishListStore()
        {
			wishes = new List<Wish>();
        }
        public override Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }

        public override Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

		public Task<IEnumerable<Wish>> GetBeersForUser(string userId)
        {
			return Task.FromResult(wishes.Where(a => a.UserId == userId));
        }

		public override Task<bool> InsertAsync(Wish item)
        {
			wishes.Add(item);
            return Task.FromResult(true);
        }

    }
}
