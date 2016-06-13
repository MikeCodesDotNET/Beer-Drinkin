using BeerDrinkin.AzureClient;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.Core.ViewModels.Discover
{
    public class DiscoverBreweriesViewModel : ViewModelBase
    {
        IAzureClient azure;
        IBreweryStore breweryStore;

        public DiscoverBreweriesViewModel()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
            breweryStore = ServiceLocator.Instance.Resolve<IBreweryStore>();
        }

        public async Task<List<Brewery>> GetBreweries()
        {
            var breweries = await breweryStore.GetItemsAsync();
            return breweries.ToList();
        }
    }
}
