using System;
using System.Collections.Generic;
using System.Linq;

using CoreGraphics;
using Foundation;
using UIKit;

using BeerDrinkin.Core.ViewModels;
using BeerDrinkin.Core.Services;

using BeerDrinkin.Service.DataObjects;

using Acr.UserDialogs;
using Awesomizer;
using Xamarin;
using System.Threading.Tasks;

namespace BeerDrinkin.iOS
{
    public partial class SearchViewController : BaseViewController
    {
        #region Fields
        private readonly SearchViewModel viewModel = new SearchViewModel();
        private BarcodeLookupService barcodeLookupService = new BarcodeLookupService();
        #endregion

        #region Constructor
        public SearchViewController(IntPtr handle) : base(handle)
        {
        }

        #endregion

        #region Overrides
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            DismissKeyboardOnBackgroundTap();

            SetupUI();
            SetupEvents(); 

            if (TraitCollection.ForceTouchCapability == UIForceTouchCapability.Available)
                RegisterForPreviewingWithDelegate(new PreviewingDelegates.BeerDescriptionPreviewingDelegate(this), View);
        }
            
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var index = tableView.IndexPathForSelectedRow.Row;
            var selectedBeer = viewModel.Beers[index];

            selectedBeer.UPC = barcodeLookupService.UPC;
            selectedBeer.RateBeerId = barcodeLookupService.RateBeerID;
          
            if (segue.Identifier != "beerDescriptionSegue")
                return;

            var beerDescriptoinViewController = segue.DestinationViewController as BeerDescriptionTableView;
            if (beerDescriptoinViewController == null)
                return;

            beerDescriptoinViewController.EnableCheckIn = true;
            beerDescriptoinViewController.SetBeer(selectedBeer);
        }

        #endregion

        private void SetupUI()
        {
            Title = BeerDrinkin.Core.Helpers.Strings.Search_Title;
        }

        private void SetupEvents()
        {
            searchBar.TextChanged += SearchBarTextChanged;           

            searchBar.SearchButtonClicked += SearchForBeers;

            searchBar.BarcodeButtonClicked += async () => await ScanBarcode();

            viewModel.Beers.CollectionChanged += delegate
            {
                DisplayBeers(viewModel.Beers.ToList());

                UserDialogs.Instance.HideLoading();
                searchBar.ResignFirstResponder();
            };
        }
            
        private async Task ScanBarcode()
        {
           try
            {
                var barcodeScanner = new ZXing.Mobile.MobileBarcodeScanner(this);
                var barcodeResult =  await barcodeScanner.Scan();

                if(string.IsNullOrEmpty(barcodeResult.Text))
                    return;

                //UserDialogs.Instance.Loading("Core.Helpers.Strings.Search_SearchingDatabase");
                var beerItems = await barcodeLookupService.SearchForBeer(barcodeResult.Text);

                if(beerItems != null)
                {
                    DisplayBeers(beerItems);
                }
            }
            catch (Exception ex)
            {
                Insights.Report(ex);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private void DisplayBeers(List<BeerItem> beers)
        {
            DataSource = new SearchDataSource(beers);
            DataSource.DidSelectBeer += delegate
            {
                PerformSegue("beerDescriptionSegue", this);
                tableView.DeselectRow(tableView.IndexPathForSelectedRow, true);
            };

            tableView.Source = DataSource;
            tableView.ReloadData();

            View.BringSubviewToFront(tableView);
            UserDialogs.Instance.HideLoading();
        }

        #region UI Control Event Handlers

        partial void BtnSearch_Activated(UIBarButtonItem sender)
        {
            //Animate SearchView into frame
            this.View.AddSubview(searchView);
        }

        private void SearchBarTextChanged(object sender, UISearchBarTextChangedEventArgs uiSearchBarTextChangedEventArgs)
        {
            barcodeLookupService.ForgetLastSearch();

            if (!string.IsNullOrEmpty(searchBar.Text))
                return;

            //Send table view to back and clear it.
            View.SendSubviewToBack(tableView);
            tableView.Source = new SearchDataSource(new List<BeerItem>());
            tableView.ReloadData();
        }

        private async void SearchForBeers (object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Searching");
            await viewModel.SearchForBeersCommand(searchBar.Text);
        }

        #endregion

        #region Properties
        public SearchDataSource DataSource {get; private set;}

        public UITableView SearchResultsTableView
        {
            get
            {
                return tableView;
            }
        }

        #endregion

    }
}