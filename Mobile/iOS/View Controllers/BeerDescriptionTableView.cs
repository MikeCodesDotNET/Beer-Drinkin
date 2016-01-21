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

using SDWebImage;
using Xamarin;
using JudoDotNetXamariniOSSDK;
using JudoPayDotNet.Models;
using JudoDotNetXamarin;

namespace BeerDrinkin.iOS
{
    partial class BeerDescriptionTableView : UIViewController
    {
        #region Fields

        /// <summary>
        /// The tracker handle for Insights.
        /// </summary>
        ITrackHandle trackerHandle;
        private BeerItem beer;
        private BeerInfo beerInfo;
        private const string activityName = "com.beerdrinkin.beer";
        private List<UITableViewCell> cells = new List<UITableViewCell> ();
        private UIView headerView;
        private nfloat headerViewHeight = 200;
        private PriceLookupService _priceLookup = new PriceLookupService ();
        private JudoPaymentService paymentService = new JudoPaymentService ();
        int BeerQuantity = 1;

        #endregion

        #region Constructor

        public BeerDescriptionTableView (IntPtr handle) : base (handle)
        {
        }

        #endregion

        #region Overrides

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            StartInsightsTracking ();
            SetUpUI ();
            //TODO make title case on the server...
            Title = new CultureInfo ("en-US").TextInfo.ToTitleCase (beer.Name);

            NavigationItem.SetLeftBarButtonItem (new UIBarButtonItem (
                UIImage.FromFile ("backArrow.png"), UIBarButtonItemStyle.Plain, (sender, args) => {
                NavigationController.PopViewController (true);
            }), true);

            btnCheckIn.TouchUpInside += async delegate
            {
                var checkIn = new CheckInItem();
                checkIn.Beer = beer;
                checkIn.BeerId = beer.Id;
                checkIn.CheckedInBy = ClientManager.Instance.BeerDrinkinClient.GetUserId;
                await ClientManager.Instance.BeerDrinkinClient.CheckInBeerAsync(checkIn);
            };

            headerView = tableView.TableHeaderView;
            tableView.TableHeaderView = null;
            tableView.AddSubview (headerView);
            tableView.ContentInset = new UIEdgeInsets (headerViewHeight, 0, 0, 0);
            tableView.BackgroundColor = UIColor.Clear;

            if (beer?.Id != null) {
                beer.Price = _priceLookup.GetPriceForBeer (beer.Id);
                RefreshSubTotal ();
            }

            if (beer?.ImageMedium != null) {
                imgHeaderView.SetImage (new NSUrl (beer?.ImageMedium), UIImage.FromBundle ("BeerDrinkin.png"));
            } else {
                imgHeaderView.Image = UIImage.FromBundle ("BeerDrinkin.png");
            }
                
            AddHeaderInfo ();
            AddDescriptionView ();
            AddPurchaseView();

            tableView.Source = new DescriptionTableViewSource (ref cells);
            var deleg = new DescriptionDelegate (ref cells);
            deleg.DidScroll += UpdateHeaderView;
            tableView.Delegate = deleg;
            tableView.RowHeight = UITableView.AutomaticDimension;
            ;
            tableView.ReloadData ();
            View.SetNeedsDisplay ();

        }

        void RefreshSubTotal ()
        {

        }

        void SetUpUI ()
        {           

        }

        public override void ViewDidAppear (bool animated)
        {
            base.ViewDidAppear (animated);
            if (TabBarController != null)
                TabBarController.TabBar.Hidden = false;

            tableView.ReloadData ();
        
        }

        public override void ViewDidLayoutSubviews ()
        {
            base.ViewDidLayoutSubviews ();
            headerView.Frame = new CGRect (headerView.Frame.Location, new CGSize (tableView.Frame.Width, headerView.Frame.Height));
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


        partial void BtnCheckIn_TouchUpInside (UIButton sender)
        {
            if (ClientManager.Instance.BeerDrinkinClient.CurrentAccount != null) {
                
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

        void StartInsightsTracking ()
        {
            
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
                var response = ClientManager.Instance.BeerDrinkinClient.GetBeerInfoAsync (beer.Id).Result;
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

        void AddDescriptionView()
        {
            if (!string.IsNullOrEmpty(beer.Description))
            {
                var cellIdentifier = new NSString("descriptionCell");
                var cell = tableView.DequeueReusableCell(cellIdentifier) as BeerDescriptionCell ??
                           new BeerDescriptionCell(cellIdentifier);
                cell.Text = beer.Description;
                cells.Add(cell);
            }

        }

        void AddPurchaseView()
        {
            if (!string.IsNullOrEmpty (beer.Description)) 
            {
                
                var cellIdentifier = new NSString ("purchaseCell");
                BeerPaymentViewModel beerModel = new BeerPaymentViewModel ();

                var cell = tableView.DequeueReusableCell (cellIdentifier) as PurchaseTableViewCell ??
                    new PurchaseTableViewCell (cellIdentifier);

                var price = _priceLookup.GetPriceForBeer(beer.Id);
                cell.Price.Text = price;
                BeerQuantity = 0;
                cell.Quantity.Text = BeerQuantity.ToString();
                cell.Total.Text = "Total: £0.00";

                cell.AddBeer += delegate
                {
                    BeerQuantity++;
                    cell.Quantity.Text = $"Quantity: {BeerQuantity}";
                        var p = double.Parse(price);
                    var total = (p * BeerQuantity).ToString();
                    cell.Total.Text = $"Total: £{total}";
                };

                cell.RemoveBeer += delegate
                {
                    BeerQuantity--;
                    cell.Quantity.Text = $"Quantity: {BeerQuantity}";   
                        var p = double.Parse(price);
                        var total = (p * BeerQuantity).ToString();
                        cell.Total.Text = $"Total: £{total}";
                };

                cell.Pay += delegate
                {
                        InvokeOnMainThread(() =>
                            {
                                Pay();
                            });
                };

                cell.Price.Text = $"Price: £{price}";
                cell.Quantity.Text = $"Quantity: {BeerQuantity}";

                cells.Add(cell);
            }
        }

        public void Pay()
        {
            BeerPaymentViewModel beerModel = new BeerPaymentViewModel ();
            beerModel.AddItem(beer, BeerQuantity);
            paymentService.BuyBeer (beerModel);    
        }

    }
  

        #endregion

        #region Classses

       class DescriptionTableViewSource : UITableViewSource
        {
            readonly List<UITableViewCell> cells = new List<UITableViewCell> ();

            public DescriptionTableViewSource (ref List<UITableViewCell> cells)
            {
                this.cells = cells;
            }

            #region implemented abstract members of UITableViewSource

            public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
            {
                return cells [indexPath.Row];
            }

            public override nint RowsInSection (UITableView tableview, nint section)
            {
                return cells.Count;
            }

            #endregion
        }

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

                if (cell.GetType() == typeof(PurchaseTableViewCell))
                    return 129;

                return 0;
            }



            public override nfloat EstimatedHeight (UITableView tableView, NSIndexPath indexPath)
            {
                return GetHeightForRow (tableView, indexPath);
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
