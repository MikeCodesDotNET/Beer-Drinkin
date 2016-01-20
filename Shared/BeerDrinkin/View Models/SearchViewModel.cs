using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using BeerDrinkin.API;
using BeerDrinkin.Service.DataObjects;

using Xamarin;

using Acr.UserDialogs;
using Plugin.Geolocator;
using Plugin.Connectivity;

namespace BeerDrinkin.Core.ViewModels
{
    public class SearchViewModel
    {
        public ObservableCollection<BeerItem> Beers = new ObservableCollection<BeerItem>();

        public async Task SearchForBeersCommand(string searchTerm)
        {

          
        }
    }
}

