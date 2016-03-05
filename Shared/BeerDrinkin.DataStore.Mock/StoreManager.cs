using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;

namespace BeerDrinkin.DataStore.Mock
{
    public class StoreManager : IStoreManager
    {
        #region IStoreManager implementation

        public async Task InitializeAsync()
        {
            await CheckInStore.InitializeStoreAsync();
        }

        public Task<bool> SyncAllAsync(bool syncUserSpecific)
        {
            return Task.FromResult(true);
        }

        public Task DropEverythingAsync()
        {
            return Task.FromResult(true);
        }

        public bool IsInitialized => true;

        ICheckInStore checkInStore;
        public ICheckInStore CheckInStore => checkInStore ?? (checkInStore = ServiceLocator.Instance.Resolve<ICheckInStore>());

        IWishListStore wishListStore;
        public IWishListStore WishListStore => wishListStore ?? (wishListStore = ServiceLocator.Instance.Resolve<IWishListStore>());

        IBeerStore beerStore;
        public IBeerStore BeerStore => beerStore ?? (beerStore = ServiceLocator.Instance.Resolve<IBeerStore>());

        #endregion
    }
}
