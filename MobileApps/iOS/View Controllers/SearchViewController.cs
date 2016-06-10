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
        readonly SearchViewModel viewModel = new SearchViewModel();

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
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DismissKeyboardOnBackgroundTap();

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

		public UIViewController GetViewControllerForPreview (IUIViewControllerPreviewing previewingContext, CGPoint location)
		{
			// Obtain the index path and the cell that was pressed.
			var indexPath = searchResultsTableView.IndexPathForRowAtPoint (location);

			if (indexPath == null)
				return null;

			var cell = searchResultsTableView.CellAt (indexPath);

			if (cell == null)
				return null;

			// Create a detail view controller and set its properties.
			var detailViewController = (BeerDescriptionTableView)Storyboard.InstantiateViewController ("beerDescriptionTableView");
			if (detailViewController == null)
				return null;

			detailViewController.PreferredContentSize = new CGSize (0, 200);
			previewingContext.SourceRect = cell.Frame;
			return detailViewController;
		}

        #endregion

        void SetupUI() 
        {
            Title = "Discover";
            searchBar.Layer.BorderWidth = 1;
            searchBar.Layer.BorderColor = "15A9FE".ToUIColor().CGColor;

            searchBar.TextChanged += delegate
            {                 

            };

        }

        void SetupEvents()
        {
            searchBar.SearchButtonClicked += SearchForBeers;  
        }

        void DisplayBeers(List<Beer> beers)
        {
            DataSource = new SearchDataSource(beers);
            DataSource.DidSelectBeer += delegate
            {
                PerformSegue("beerDescriptionSegue", this);
                    placeHolderTableView.DeselectRow(placeHolderTableView.IndexPathForSelectedRow, true);
            };

            placeHolderTableView.Source = DataSource;
            placeHolderTableView.ReloadData();

            View.BringSubviewToFront(placeHolderTableView);
            UserDialogs.Instance.HideLoading();
        }

        #region UI Control Event Handlers
        void SearchBarTextChanged(object sender, UISearchBarTextChangedEventArgs uiSearchBarTextChangedEventArgs)
        {
            /*
            if (!string.IsNullOrEmpty(searchBar.Text))
                return;

            //Send table view to back and clear it.
            View.SendSubviewToBack(tableView);
            tableView.Source = new SearchDataSource(new List<BeerItem>());
            tableView.ReloadData();

            */
        }

        async void SearchForBeers (object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Searching");
            var beers = await viewModel.Search(searchBar.Text);

            var source = new SearchDataSource(beers);
            source.DidSelectBeer += BeerSelected;
            
            searchResultsTableView.Source = source;
            searchResultsTableView.ReloadData();
            View.BringSubviewToFront(searchResultsTableView);

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
            searchResultsTableView.DeselectRow(placeHolderTableView.IndexPathForSelectedRow, true);
        }

        #endregion


        #region Properties
        public SearchDataSource DataSource {get; private set;}

        public UITableView SearchResultsTableView
        {
            get
            {
                return placeHolderTableView;
            }
        }

       #endregion
    }
}