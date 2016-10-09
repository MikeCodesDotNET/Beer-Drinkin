using BeerDrinkin.Models;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerDrinkin.Core.Abstractions.ViewModels;

namespace BeerDrinkin.Core.ViewModels
{
    public class UserProfileViewModel : ViewModelBase, IUserProfileViewModel
    {
        IUserStore userStore;
        IRatingStore ratingStore;
        IWishStore wishStore;

        User user;

        public UserProfileViewModel()
        {
            userStore = ServiceLocator.Instance.Resolve<IUserStore>();
            ratingStore = ServiceLocator.Instance.Resolve<IRatingStore>();
            wishStore = ServiceLocator.Instance.Resolve<IWishStore>();
        }

        public async Task Init(string userId = "")
        {
            if (!string.IsNullOrEmpty(userId))
            {
                user = await userStore.GetItemAsync(userId);                
            }
            else
            {

            }

            if (user == null)
                return;

            FirstName = user.FirstName;
            LastName = user.LastName;
            AvatarUrl = user.Avatar.LargeUrl;

            var ratings = await ratingStore.GetRatingsForUser(userId);
            Ratings = ratings.ToList();
            RatingsCount = ratings.Count();

            var wishes = await wishStore.GetWishesForUser(userId);
            Wishes = wishes.ToList();
            WishCount = wishes.Count();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set;  }
        public string AvatarUrl { get; private set; }
        public int BeerCount { get; private set; }
        public int RatingsCount { get; set; }
        public int WishCount { get; set; }

        public List<Wish> Wishes { get; private set; }
        public List<Rating> Ratings { get; private set; }
    }
}
