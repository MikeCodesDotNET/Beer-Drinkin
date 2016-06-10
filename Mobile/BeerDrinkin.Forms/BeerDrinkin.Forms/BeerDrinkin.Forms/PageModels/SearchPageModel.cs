using Acr.UserDialogs;
using BeerDrinkin.Forms.Interfaces;
using BeerDrinkin.Forms.Models;
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
    internal class SearchPageModel : FreshBasePageModel
    {
        private readonly IUserDialogs _userDialogs;
        private readonly IBreweryDbClient _breweryDbClient;
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

        public Beer SelectedBeer
        {
            get { return _selectedBeer; }
            set
            {
                _selectedBeer = value;

                if (_selectedBeer != null)
                {
                    Insights.Track("Selected Beer", SearchTerm, _selectedBeer.Name);
                    CoreMethods.PushPageModel<BeerDetailsPageModel>(_selectedBeer);
                }

                _selectedBeer = null;
            }
        }

        public Command SearchBeersCommand
        {
            get { return _searchBeersCommand ?? (_searchBeersCommand = new Command(async () => await ExecuteSearchBeersCommand())); }
        }

        public SearchPageModel(IUserDialogs userDialogs, IBreweryDbClient breweryDbClient)
        {
            _userDialogs = userDialogs;
            _breweryDbClient = breweryDbClient;
        }

        private async Task ExecuteSearchBeersCommand()
        {
            if (IsBusy)
                return;

            using (Xamarin.Insights.TrackTime("BeerSearch", "searchTerm", SearchTerm))
            {
                _userDialogs.ShowLoading("Searching...");

                IsBusy = true;
                IsSearched = true;

                try
                {
                    var results = await _breweryDbClient.SearchBeersAsync(SearchTerm);

                    Beers.Clear();

                    if (results?.Count > 0)
                    {
                        foreach (var beer in results)
                        {
                            Beers.Add(new Beer
                            {
                                Abv = beer.Abv.ToString(),
                                BreweryDbId = beer.Id,
                                Name = beer.Name.ToString(),
                                ImageSmall = beer.Labels?.Icon
                            });
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