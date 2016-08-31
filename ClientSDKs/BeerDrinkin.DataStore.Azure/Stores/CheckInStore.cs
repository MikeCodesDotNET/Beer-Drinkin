using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.DataStore.Azure.Stores;
using BeerDrinkin.Utils;
using BeerDrinkin.AzureClient;

namespace BeerDrinkin.DataStore.Azure
{
    public class CheckInStore : BaseStore<CheckIn>, ICheckInStore
    {        
        public Task<IEnumerable<CheckIn>> GetCheckInsForBeer(string beerId)
        {
            return Table.Where(s => s.Beer.Id == beerId).ToEnumerableAsync();
        }

        public Task<IEnumerable<CheckIn>> GetCheckInsForUser(string userId)
        {
            return Table.Where(s => s.User.Id == userId).ToEnumerableAsync();
        }
    }
}
