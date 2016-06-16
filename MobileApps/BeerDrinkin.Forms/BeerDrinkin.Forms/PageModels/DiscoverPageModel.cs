using Acr.UserDialogs;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Forms.Interfaces;
using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin;
using Xamarin.Forms;

namespace BeerDrinkin.Forms.PageModels
{
    [ImplementPropertyChanged]
    internal class DiscoverPageModel : FreshBasePageModel
    {
        private readonly IUserDialogs _userDialogs;
        private readonly IBeerDrinkinClient _beerDrinkinClient;
        private Command _searchBeersCommand;
        private Beer _selectedBeer;
        private string _searchTerm;

        public bool IsBusy { get; set; }

        public string SearchTerm
        {
            get
            {
                return _searchTerm;
            }

            set
            {
                _searchTerm = value;

                if (string.IsNullOrWhiteSpace(_searchTerm))
                {
                    SearchTerm = string.Empty;
                    IsSearched = false;
                }
            }
        }

        public bool IsSearched { get; set; }

        public ObservableCollection<Beer> Beers { get; set; } = new ObservableCollection<Beer>();

        public ObservableCollection<Beer> DiscoverBeers { get; set; } = new ObservableCollection<Beer>();

        public Beer SelectedBeer
        {
            get { return _selectedBeer; }
            set
            {
                _selectedBeer = value;

                if (_selectedBeer != null)
                {
                    CoreMethods.PushPageModel<BeerDetailsPageModel>(_selectedBeer, true);
                }

                _selectedBeer = null;
            }
        }

        public Command SearchBeersCommand
        {
            get { return _searchBeersCommand ?? (_searchBeersCommand = new Command(async () => await ExecuteSearchBeersCommand())); }
        }

        public DiscoverPageModel(IUserDialogs userDialogs, IBeerDrinkinClient beerDrinkinClient)
        {
            _userDialogs = userDialogs;
            _beerDrinkinClient = beerDrinkinClient;
        }

        public async override void Init(object initData)
        {
            NavigationPage.SetHasNavigationBar(CurrentPage, false);

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var results = await _beerDrinkinClient.GetDiscoverBeersAsync();

                DiscoverBeers.Clear();

                if (results?.Count > 0)
                {
                    foreach (var beer in results)
                        DiscoverBeers.Add(beer);
                }
            }
            catch (Exception ex)
            {
                _userDialogs.ShowError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteSearchBeersCommand()
        {
            if (IsBusy)
                return;

            using (Insights.TrackTime("BeerSearch", "searchTerm", SearchTerm))
            {
                _userDialogs.ShowLoading("Searching...");

                IsBusy = true;
                IsSearched = true;

                try
                {
                    var results = await _beerDrinkinClient.SearchBeersAsync(SearchTerm);

                    Beers.Clear();

                    if (results?.Count > 0)
                    {
                        foreach (var beer in results)
                        {
                            Beers.Add(beer);
                        }
                    }

                    _userDialogs.HideLoading();
                }
                catch (Exception ex)
                {
                    _userDialogs.ShowError(ex.Message);
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }
}