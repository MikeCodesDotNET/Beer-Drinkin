using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.Models;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.DataStore.Azure.Stores;

namespace BeerDrinkin.DataStore.Azure
{
    public class RatingStore : BaseStore<Rating>, IRatingStore
    {
        public override Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }

        public override Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Rating>> GetRatings()
        {
            return Table.ReadAsync();
        }

        public Task<IEnumerable<Rating>> GetRating(string id)
        {
            return Table.Where(s => s.Id == id).ToEnumerableAsync();
        }

        public async Task<IEnumerable<Rating>> GetRatingsForUser(string userId)
        {
            var ratings = await GetItemsAsync();
            return ratings.Where(x => x.User.Id == userId);
        }
    }
}
