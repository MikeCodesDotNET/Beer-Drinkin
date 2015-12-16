using System;
using System.Collections.ObjectModel;
using BeerDrinkin.Service.DataObjects;
using System.Threading.Tasks;
using System.Linq;

namespace BeerDrinkin.Core.ViewModels
{
    public class MyBeersViewModel
    {

        public ObservableCollection<BeerInfo> Beers = new ObservableCollection<BeerInfo>();

        public bool IsBusy { get; set; }

        public MyBeersViewModel()
        {
        }

        public async Task FetchBeersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            var usersBeersResponse = await Client.Instance.BeerDrinkinClient.GetBeerInfosByUserAsync();

            if (usersBeersResponse.Result.Count > 0)
            {
                Beers.Clear();
                var sortedResults = usersBeersResponse.Result.OrderByDescending(x => x.CheckIns.Count()).ToList();
                foreach (var beerItem in sortedResults)
                {    
                    Beers.Add(beerItem);
                }
                IsBusy = false;
                return;
            }

            if (usersBeersResponse.HasError)
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError(usersBeersResponse.ErrorMessage);
                IsBusy = false;
                return;
            }
        }
    }
}

