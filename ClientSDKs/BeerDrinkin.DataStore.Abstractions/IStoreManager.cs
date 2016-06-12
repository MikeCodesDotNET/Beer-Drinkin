using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.DataStore.Abstractions
{
    public interface IStoreManager
    {
        bool IsInitialized { get; }
        Task InitializeAsync();
        IWishStore WishListStore { get; }
        ICheckInStore CheckInStore { get; }
        IBeerStore BeerStore { get; }

        Task<bool> SyncAllAsync(bool syncUserSpecific);
        Task DropEverythingAsync();
    }
}
