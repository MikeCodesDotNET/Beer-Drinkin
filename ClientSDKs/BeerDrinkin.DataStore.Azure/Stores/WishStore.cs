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
    public class WishStore : BaseStore<Wish>, IWishStore
    {
        public async Task<IEnumerable<Wish>> GetWishesForUser(string userId)
        {
            var wishes = await GetItemsAsync();
            return wishes.Where(x => x.UserId == userId);
        }
    }
}
