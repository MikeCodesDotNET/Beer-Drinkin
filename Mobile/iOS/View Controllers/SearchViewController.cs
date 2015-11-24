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

namespace BeerDrinkin.iOS
{
    public partial class SearchViewController : BaseViewController
    {
        #region Fields
        private readonly SearchViewModel viewModel = new SearchViewModel();
        private BarcodeLookupService barcodeLookupService = new BarcodeLookupService();
        private bool isFirstRun = true;
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

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (isFirstRun)
            {
                imgSearch.Pop(0.7f, 0, 0.2f);
                lblFindBeers.Pop(0.7f, 0, 0.2f);
                lblSearchBeerDrinkin.Pop(0.7f, 0, 0.2f);
            }

            isFirstRun = false;
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
            lblSearchBeerDrinkin.Text = BeerDrinkin.Core.Helpers.Strings.Search_PlaceHolderTitle;
            lblFindBeers.Text = BeerDrinkin.Core.Helpers.Strings.Search_SubPlaceHolderTitle;
            searchBar.Clicked += delegate
            {
                ScanBarcode();
            };

            View.BringSubviewToFront(scrllPlaceHolder);
        }

        private void SetupEvents()
        {
            searchBar.TextChanged += SearchBarTextChanged;           

            searchBar.SearchButtonClicked += SearchForBeers;

            viewModel.Beers.CollectionChanged += delegate
            {
                DisplayBeers(viewModel.Beers.ToList());

                UserDialogs.Instance.HideLoading();

                View.BringSubviewToFront(tableView);
                searchBar.ResignFirstResponder();
            };
        }
            
        private async void ScanBarcode()
        {
           try
            {
                var barcodeScanner = new ZXing.Mobile.MobileBarcodeScanner(this);
                var barcodeResult =  await barcodeScanner.Scan();

                var beerItems = await barcodeLookupService.SearchForBeer(barcodeResult.Text);

                if(beerItems != null)
                    DisplayBeers(beerItems);
                
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

            DataSource.CheckInBeer += async (beer, index) =>
            {
                var result = await viewModel.QuickCheckIn(beer);
                var cell = tableView.CellAt(index) as SearchBeerTableViewCell;
                if (cell != null)
                    cell.isCheckedIn = result;
            };

            UserDialogs.Instance.HideLoading();
        }

        #region UI Control Event Handlers
        private void SearchBarTextChanged(object sender, UISearchBarTextChangedEventArgs uiSearchBarTextChangedEventArgs)
        {
            barcodeLookupService.ForgetLastSearch();

            if (!string.IsNullOrEmpty(searchBar.Text))
                return;

            //Setup text and image for scaling animation
            scrllPlaceHolder.Alpha = 0.6f;
            var smallTransform = CGAffineTransform.MakeIdentity();
            smallTransform.Scale(0.6f, 0.6f);
            imgSearch.Transform = smallTransform;
            lblFindBeers.Transform = smallTransform;
            lblSearchBeerDrinkin.Transform = smallTransform;

            //Send table view to back and clear it.
            View.SendSubviewToBack(tableView);
            tableView.Source = new SearchDataSource(new List<BeerItem>());
            tableView.ReloadData();

            //Animate the placeholder 
            var normalTransform = CGAffineTransform.MakeIdentity();
            smallTransform.Scale(1f, 1f);
            UIView.Animate(0.3, 0, UIViewAnimationOptions.TransitionCurlUp,
                () =>
                {
                    scrllPlaceHolder.Alpha = 1;

                    imgSearch.Transform = normalTransform;
                    lblFindBeers.Transform = normalTransform;
                    lblSearchBeerDrinkin.Transform = normalTransform;
                }, () =>
                {
                });
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