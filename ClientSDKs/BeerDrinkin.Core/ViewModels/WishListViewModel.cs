using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerDrinkin.Core.Abstractions.ViewModels;

namespace BeerDrinkin.Core.ViewModels
{
    public class WishListViewModel : ViewModelBase, IWishListViewModel
    {
        IWishStore wishStore; 
        public WishListViewModel()
        {
            wishStore = ServiceLocator.Instance.Resolve<IWishStore>();
        }

        public async Task DeleteWish(string id)
        {
            var item = await wishStore.GetItemAsync(id);
            await wishStore.RemoveAsync(item);
        }

        public async Task<List<Wish>> GetWishes()
        {
            var wishes = await wishStore.GetItemsAsync();
            return wishes.ToList();
        }
    }
}
