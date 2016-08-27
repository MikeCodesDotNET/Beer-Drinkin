using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BeerDrinkin.AzureClient;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;

namespace BeerDrinkin.Core.ViewModels
{
    public class BeersViewModel : ViewModelBase
    {
        ICheckInStore checkInStore;
        IAzureClient azure;

        public BeersViewModel()
        {
            checkInStore = ServiceLocator.Instance.Resolve<ICheckInStore>();
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
        }
        
        public async Task<List<Beer>> GetBeers()
        {
            return null;
        }
    }
}
