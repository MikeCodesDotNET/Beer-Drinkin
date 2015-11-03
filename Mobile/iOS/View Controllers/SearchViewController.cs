using System;
using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using BeerDrinkin.Core.ViewModels;
using BeerDrinkin.Service.DataObjects;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin;
using Awesomizer;
using BeerDrinkin.iOS.Helpers;

namespace BeerDrinkin.iOS
{
    public partial class SearchViewController : BaseViewController
    {
        private readonly SearchViewModel viewModel = new SearchViewModel();

        public SearchViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DismissKeyboardOnBackgroundTap();

            SetupUI();
            SetupEvents(); 

            if (TraitCollection.ForceTouchCapability == UIForceTouchCapability.Available)
            {
                //This devices supports 3D Touch
                RegisterForPreviewingWithDelegate(new PreviewingDelegates.BeerDescriptionPreviewingDelegate(this), View);
            }
        }

        bool isFirstRun = true;
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
            if (segue.Identifier != "beerDescriptionSegue")
                return;

            // set in Storyboard
            var navctlr = segue.DestinationViewController as BeerDescriptionTableView;
            if (navctlr == null)
                return;

            var rowPath = tableView.IndexPathForSelectedRow;
            var item = viewModel.Beers[rowPath.Row];
            item.UPC = upc;

            navctlr.EnableCheckIn = true;
            navctlr.SetBeer(item);
        }

        public void SetupUI()
        {
            var bounds = this.NavigationController.NavigationBar.Bounds;         
            var blur = UIBlurEffect.FromStyle (UIBlurEffectStyle.Light);
            var visualEffectView = new UIVisualEffectView(blur);
            visualEffectView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
            this.NavigationController.NavigationBar.AddSubview(visualEffectView);
            this.NavigationController.NavigationBar.Translucent = true;

            Title = BeerDrinkin.Core.Helpers.Strings.SearchTitle;
            lblSearchBeerDrinkin.Text = BeerDrinkin.Core.Helpers.Strings.SearchPlaceHolderTitle;
            lblFindBeers.Text = BeerDrinkin.Core.Helpers.Strings.SearchSubPlaceHolderTitle;
            searchBar.Clicked += delegate
            {
                ScanBarcode();
            };

            View.BringSubviewToFront(scrllPlaceHolder);
        }

        public void SetupEvents()
        {
            searchBar.TextChanged += SearchBarTextChanged;           

            searchBar.SearchButtonClicked += async delegate
            {
                UserDialogs.Instance.ShowLoading("Searching");
                await viewModel.SearchForBeersCommand(searchBar.Text);
            };

            viewModel.Beers.CollectionChanged += delegate
            {
                datasource = new SearchDataSource(viewModel.Beers.ToList());
                datasource.DidSelectBeer += delegate
                {
                    PerformSegue("beerDescriptionSegue", this);
                    tableView.DeselectRow(tableView.IndexPathForSelectedRow, true);
                };

                tableView.Source = datasource;
                tableView.ReloadData();

                datasource.CheckInBeer += async (beer, index) =>
                {
                    var result = await viewModel.QuickCheckIn(beer);
                    var cell = tableView.CellAt(index) as SearchBeerTableViewCell;
                    if (cell != null)
                        cell.isCheckedIn = result;
                };

                UserDialogs.Instance.HideLoading();

                View.BringSubviewToFront(tableView);
                searchBar.ResignFirstResponder();
            };
        }

        string upc = string.Empty;
        async void ScanBarcode()
        {
           try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner(this);
                var result =  await scanner.Scan();

                UserDialogs.Instance.ShowLoading("Searching for beer");
                upc = result.Text;
                var client = new RateBeer.Client();
                var response = await client.SearchForBeer(upc);

                if(response != null)
                {
                    searchBar.Text = response.BeerName;
                    searchBar.BecomeFirstResponder();
                    UserDialogs.Instance.HideLoading();

                    Insights.Track("User searched with barcode", new Dictionary<string, string> {
                        {"Beer Name", response.BeerName},
                        {"Beer UPC", result.Text}
                    });
                }
                else
                {
                    UserDialogs.Instance.ShowError("Unable to find beer with that barcode :(");
                }

            }
            catch (Exception ex)
            {
                Xamarin.Insights.Report(ex);
            }
        }

        /// <summary>
        /// Handles showing the placeholder when the text is null or empty. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uiSearchBarTextChangedEventArgs"></param>
        void SearchBarTextChanged(object sender, UISearchBarTextChangedEventArgs uiSearchBarTextChangedEventArgs)
        {
            upc = string.Empty;

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

        public UITableView SearchResultsTableView
        {
            get
            {
                return tableView;
            }
        }

        SearchDataSource datasource;
        public SearchDataSource DataSource
        {
            get
            {
                return datasource;
            }
        }

    }
}