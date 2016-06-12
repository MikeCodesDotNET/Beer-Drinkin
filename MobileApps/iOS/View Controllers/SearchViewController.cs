using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation;
using UIKit;
using CoreGraphics;

using BeerDrinkin.Core.ViewModels;

using Acr.UserDialogs;
using MikeCodesDotNET.iOS;

using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using BeerDrinkin.iOS.DataSources;
using BeerDrinkin.DataObjects;
using BeerDrinkin.iOS.Helpers;

namespace BeerDrinkin.iOS
{
	public partial class SearchViewController : BaseViewController
    {
        #region Fields
        readonly DiscoverViewModel viewModel = new DiscoverViewModel();

        SearchIndexClient indexClient;
        Beer selectedBeer;
        #endregion

		public Beer SelectedBeer
		{
			get
			{
				return selectedBeer;
			}
		}

        #region Constructor
        public SearchViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion

        #region Overrides
        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DismissKeyboardOnBackgroundTap();

            if (string.IsNullOrEmpty(Utils.Helpers.Settings.UserId))
            {
                var vc = Storyboard.InstantiateViewController("SOCIAL_AUTH");
                await PresentViewControllerAsync(vc, false);
            }

            SetupUI();
            SetupEvents();
        }
       
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {            
            if (segue.Identifier != "beerDescriptionSegue")
                return;
         
            var beerDescriptoinViewController = segue.DestinationViewController as BeerDescriptionTableView;
            if (beerDescriptoinViewController == null)
                return;

            beerDescriptoinViewController.EnableCheckIn = true;
            beerDescriptoinViewController.SetBeer(selectedBeer);

            selectedBeer = null;
		}
        		
        #endregion

        void SetupUI() 
        {
            Title = "Discover";
            searchBar.Layer.BorderWidth = 1;
            searchBar.Layer.BorderColor = "15A9FE".ToUIColor().CGColor;

            searchBar.TextChanged += SearchBarTextChanged;    
        }

        void SetupEvents()
        {
            searchBar.SearchButtonClicked += SearchForBeers;  
        }

      
        #region UI Control Event Handlers
        void SearchBarTextChanged(object sender, UISearchBarTextChangedEventArgs uiSearchBarTextChangedEventArgs)
        {
            if (!string.IsNullOrEmpty(searchBar.Text))
                return;

            //Send table view to back and clear it.
            SearchResultsTable.Source = new DiscoverBeerSearchResultsSource(new List<Beer>());
            SearchResultsTable.ReloadData();
        }

        async void SearchForBeers (object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Searching");
            var beers = await viewModel.Search(searchBar.Text);

            var source = new DiscoverBeerSearchResultsSource(beers);
            source.DidSelectBeer += BeerSelected;
            
            SearchResultsTable.Source = source;
            SearchResultsTable.ReloadData();
            View.BringSubviewToFront(SearchResultsTable);

            UserDialogs.Instance.HideLoading();
        }

        void BeerSelected(Beer beer)
        {
            selectedBeer = beer;

            var searchHistory = SearchHistory.History;
            searchHistory.Enqueue(beer.Name);
            if (searchHistory.Count > 3)
                searchHistory.Dequeue();

            PerformSegue("beerDescriptionSegue", this);
            SearchResultsTable.DeselectRow(SearchResultsTable.IndexPathForSelectedRow, true);
        }

        #endregion


        #region Properties
        public DiscoverBeerSearchResultsSource DataSource {get; private set;}

       #endregion
    }
}