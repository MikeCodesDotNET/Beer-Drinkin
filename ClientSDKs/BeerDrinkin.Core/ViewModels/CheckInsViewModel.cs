using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.Core.Abstractions.ViewModels;

namespace BeerDrinkin.Core.ViewModels
{
    public class CheckInsViewModel : ViewModelBase, ICheckInsViewModel
    {
        ICheckInStore checkInStore;

        public CheckInsViewModel()
        {
            ServiceLocator.Instance.Resolve<ICheckInStore>();
        }

        public async Task<List<CheckIn>> FetchCheckIns(string userId = "")
        {
            var checkins = await checkInStore.GetItemsAsync();

            if(string.IsNullOrEmpty(userId))
            {
                return checkins.ToList();
            }

            //TODO return for the currently signed in user.

            return null;
        }
    }
}
