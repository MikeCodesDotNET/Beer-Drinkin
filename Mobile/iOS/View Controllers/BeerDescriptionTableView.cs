using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using CoreGraphics;
using CoreLocation;
using Foundation;
using MapKit;
using UIKit;

using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.iOS.DataSources;

using Xamarin;
using SDWebImage;
using JudoDotNetXamariniOSSDK;
using JudoPayDotNet.Models;
using JudoDotNetXamarin;

namespace BeerDrinkin.iOS
{
    partial class BeerDescriptionTableView : UIViewController
    {
        #region Fields

        ITrackHandle trackerHandle;
        ClientService clientService;
        PriceLookupService priceLookup = new PriceLookupService ();
        JudoPaymentService paymentService = new JudoPaymentService ();
        List<UITableViewCell> cells = new List<UITableViewCell> ();

        BeerItem beer;
        BeerInfo beerInfo;
        const string activityName = "com.beerdrinkin.beer";
        UIView headerView;
        nfloat headerViewHeight = 200;
        int BeerQuantity = 1;

        #endregion

        #region Constructor

        public BeerDescriptionTableView (IntPtr handle) : base (handle)
        {
            clientService = new ClientService ();
        }

        #endregion

        #region Overrides

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            SetUpUI ();
        }

        async void AddPurchase()
        {

            var response = await Client.Instance.BeerDrinkinClient.GetBeerDistributors(beer.Id);
            if (response.Result == null)
                return;

            var cellIdentifier = new NSString("distributorCell");
            var cell = tableView.DequeueReusableCell (cellIdentifier) as PurchaseTableViewCell ??
                new PurchaseTableViewCell (cellIdentifier);

            var price = priceLookup.GetPriceForBeer(beer.Id.ToString());
            beer.Price = price;

            var beerPrice = decimal.Parse(price);
            cell.Price = beerPrice;
            cell.Quantity = 0;
            cell.DistributorName = "Beer Merchants";
            cell.TagLine = "Great beers to your door";

            cells.Add (cell);
        }

        void SetUpUI ()
        {
            Title = new CultureInfo ("en-US").TextInfo.ToTitleCase (beer.Name);

            NavigationItem.SetLeftBarButtonItem (new UIBarButtonItem (
                UIImage.FromFile ("backArrow.png"), UIBarButtonItemStyle.Plain, (sender, args) => {
                NavigationController.PopViewController (true);
            }), true);


            headerView = tableView.TableHeaderView;
            tableView.TableHeaderView = null;
            tableView.AddSubview (headerView);
            tableView.ContentInset = new UIEdgeInsets (headerViewHeight, 0, 0, 0);
            tableView.BackgroundColor = UIColor.Clear;

            if (beer?.ImageMedium != null) {
                imgHeaderView.SetImage (new NSUrl (beer?.ImageMedium), UIImage.FromBundle ("BeerDrinkin.png"));
            } else {
                imgHeaderView.Image = UIImage.FromBundle ("BeerDrinkin.png");
            }

            //Add Cells
            AddHeaderInfo ();
            AddDescription ();
            AddPurchase();

            //Update Tableview
            tableView.Source = new BeerDescriptionDataSource(ref cells);
            var deleg = new DescriptionDelegate (ref cells);
            deleg.DidScroll += UpdateHeaderView;
            tableView.Delegate = deleg;

            tableView.ReloadData ();
            View.SetNeedsDisplay ();

            /*
            BuyNowButton.Layer.CornerRadius = 5f;
            subTotalButton.Layer.CornerRadius = subTotalButton.Bounds.Size.Width / 2f;
            subTotalButton.Layer.BorderWidth = 2f;
          
            subTotalButton.Layer.BorderColor = UIColor.Black.CGColor;

            subTotalButton.TouchUpInside += delegate {
                BeerQuantity++;
                subTotalButton.SetTitle (BeerQuantity.ToString (), UIControlState.Normal);
                RefreshSubTotal ();
            };

            BuyNowButton.TouchUpInside += delegate {
                BeerPaymentViewModel beerModel = new BeerPaymentViewModel ();
                beerModel.AddItem (beer, BeerQuantity);
              
              
                _paymentService.BuyBeer (beerModel);
            };


            if (_clientService.ApplePayAvailable) {
                applePayButton.TouchUpInside += delegate {
                    BeerPaymentViewModel beerModel = new BeerPaymentViewModel ();
                    beerModel.AddItem (beer, BeerQuantity);


                    _paymentService.BuyBeerApplePay (beerModel);
                };
            } else {
                applePayButton.Hidden = true;
            }
            */
        }

        public override void ViewDidAppear (bool animated)
        {
            base.ViewDidAppear (animated);
            BeerDrinkin.Core.Services.UserTrackingService.ReportViewLoaded("BeerDescriptionTableView", $"{beer.Name} Loaded");
            tableView.ReloadData ();
        }

        public override void ViewDidLayoutSubviews ()
        {
            base.ViewDidLayoutSubviews ();
            headerView.Frame = new CGRect (headerView.Frame.Location, new CGSize (tableView.Frame.Width, headerView.Frame.Height));
            UpdateHeaderView();
            View.SetNeedsDisplay ();
        }

        public override void ViewWillDisappear (bool animated)
        {
            base.ViewWillDisappear (animated);
            if (trackerHandle != null) {
                trackerHandle.Stop ();
                trackerHandle = null;
            }
        }

        public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier != "addBeerSegue")
                return;

            // set in Storyboard
            var navctlr = segue.DestinationViewController as AddBeerTableViewController;
            if (navctlr == null)
                return;
            navctlr.SetBeer (beer);
        }

        #endregion

        #region UI Control Events

        async partial void btnShare_Activated (UIBarButtonItem sender)
        {
            var text = string.Format ("Grab yourself a {0}, its a great beer!", beer.Name);
            var items = new NSObject[] { new NSString (text) };
            var activityController = new UIActivityViewController (items, null);
            await PresentViewControllerAsync (activityController, true);
        }

        async partial void BtnCheckIn_TouchUpInside (UIButton sender)
        {
            var checkInItem = new CheckInItem ();
            checkInItem.Beer = beer;
            checkInItem.BeerId = beer.Id;
            await Client.Instance.BeerDrinkinClient.CheckInBeerAsync (checkInItem);

            if (Client.Instance.BeerDrinkinClient.CurrentUser != null) {
            } else {
                var welcomeViewController = Storyboard.InstantiateViewController ("welcomeView");
                PresentModalViewController (welcomeViewController, true);
            }
        }

        #endregion

        #region Properties

        public bool EnableCheckIn = false;

        #endregion

        public void SetBeer (BeerItem item)
        {
            beer = item;    
        }

        public void SetBeerInfo (BeerInfo item)
        {
            beerInfo = item;
        }

        private void UpdateHeaderView ()
        {
            var headerRect = new CGRect (0, -headerViewHeight, tableView.Frame.Width, headerViewHeight);
            if (tableView.ContentOffset.Y < -headerViewHeight) {
                headerRect.Location = new CGPoint (headerRect.Location.X, tableView.ContentOffset.Y);
                headerRect.Size = new CGSize (headerRect.Size.Width, -tableView.ContentOffset.Y);
            }
            headerView.Frame = headerRect;
        }

        #region AddCells

        void AddHeaderInfo ()
        {
            var headerCellIdentifier = new NSString ("headerCell");
            var headerCell = tableView.DequeueReusableCell (headerCellIdentifier) as BeerHeaderCell ??
                             new BeerHeaderCell (headerCellIdentifier);
            headerCell.Name = beer?.Name;
            headerCell.Brewery = beer?.Brewery;
            headerCell.Abv = beer.ABV.ToString ();

            headerCell.ConsumedAlpha = 0.3f;
            headerCell.RatingAlpha = 0.3f;
            //Lets fire up another thread so we can continue loading our UI and makes the app seem faster.
            Task.Run (() => {
                var response = Client.Instance.BeerDrinkinClient.GetBeerInfoAsync (beer.Id.ToString()).Result;
                if (response.Result != null)
                    beerInfo = response.Result;

                InvokeOnMainThread (() => {
                    if (beerInfo == null)
                        return;

                    headerCell.Consumed = beerInfo?.CheckIns.ToList ().Count.ToString ();
                    headerCell.Rating = beerInfo?.AverageRating != 0 ? beerInfo.AverageRating.ToString (CultureInfo.InvariantCulture) : "NA";

                    UIView.Animate (0.3, 0, UIViewAnimationOptions.TransitionCurlUp, () => {
                        headerCell.ConsumedAlpha = 1f;
                        headerCell.RatingAlpha = 1f;

                    }, () => {
                    });
                });
            });


            cells.Add (headerCell);
        }

        void AddDescription ()
        {
            if (!string.IsNullOrEmpty (beer.Description)) {
                var cellIdentifier = new NSString ("descriptionCell");
                var cell = tableView.DequeueReusableCell (cellIdentifier) as BeerDescriptionCell ??
                           new BeerDescriptionCell (cellIdentifier);
                cell.Text = beer.Description;
                cells.Add (cell);
            }
        }

        #endregion

        #region Classses
        class DescriptionDelegate : UITableViewDelegate
        {
            readonly List<UITableViewCell> cells = new List<UITableViewCell> ();

            public DescriptionDelegate (ref List<UITableViewCell> cells)
            {
                this.cells = cells;
            }


            public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
            {
                var cell = cells [indexPath.Row];

                if (cell.GetType () == typeof(BeerDescriptionCell)) {
                    var c = cell as BeerDescriptionCell;
                    return c.PreferredHeight + 50;
                }

                if (cell.GetType () == typeof(BeerHeaderCell)) {
                    var c = cell as BeerHeaderCell;
                    return c.Frame.Height;
                }
                    

                if (cell.GetType () == typeof(CheckInLocationMapCell))
                    return 200;

                if (cell.GetType () == typeof(PurchaseTableViewCell))
                    return 87;

                return 0;

            }



            public override void Scrolled (UIScrollView scrollView)
            {
                DidScroll ();
            }

            public delegate void DidScrollEventHandler ();

            public event DidScrollEventHandler DidScroll;
        }

        #endregion
    }
}