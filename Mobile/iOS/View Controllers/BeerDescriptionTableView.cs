using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using CoreGraphics;
using UIKit;

using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.iOS.DataSources;

using Xamarin;
using SDWebImage;
using CoreSpotlight;
using Foundation;

using Splat;
using Plugin.Share;

namespace BeerDrinkin.iOS
{
    partial class BeerDescriptionTableView : UIViewController
    {
        #region Fields

        ITrackHandle trackerHandle;
        PriceLookupService priceLookup = new PriceLookupService ();
        List<UITableViewCell> cells = new List<UITableViewCell> ();
		bool justSignedIn;
        BeerItem beer;
        BeerInfo beerInfo;
        const string activityName = "com.beerdrinkin.beer";
        UIView headerView;
        nfloat headerViewHeight = 200;

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
            SetUpUI ();

			NavigationController.NavigationBar.BackgroundColor = BeerDrinkin.Helpers.Colours.Blue.ToNative();
			NavigationController.NavigationBar.TintColor = UIColor.White;

        }

		public override void ViewDidAppear (bool animated)
        {
            base.ViewDidAppear (animated);

			UIBarButtonItem btnShare = new UIBarButtonItem ();
			btnShare.Clicked += delegate 
			{
				Share();
			};
			btnShare.Title = "Share";
			btnShare.Image = UIImage.FromFile("702-share.png");
			NavigationItem.RightBarButtonItem = btnShare;


            Core.Services.UserTrackingService.ReportViewLoaded("BeerDescriptionTableView", $"{beer.Name} Loaded");
            tableView.ReloadData ();

			if (Client.Instance.BeerDrinkinClient.CurrentMobileServicetUser != null)
			{
				if (justSignedIn)
				{
					//If the user just signed in then it means we didn't check the beer in. Lets go ahead and do this.
					var vc = Storyboard.InstantiateViewController("rateBeerViewController") as RateBeerViewController;
					vc.SelectedBeer = beer;
					this.NavigationController.PushViewController(vc, false);

					justSignedIn = false;
				}
			}
		

            SetupSearch ();
        }

		public void Share()
		{
			CrossShare.Current.Share(beer.Name, beer.Description);
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

        partial void BtnCheckIn_TouchUpInside (UIButton sender)
        {
			var user = Client.Instance.BeerDrinkinClient.CurrentMobileServicetUser;
			if (user != null) 
			{
				var vc = Storyboard.InstantiateViewController("rateBeerViewController") as RateBeerViewController;
				vc.SelectedBeer = beer;
				NavigationController.PushViewController(vc, true);
            } 
			else 
			{
                var welcomeViewController = Storyboard.InstantiateViewController ("welcomeView");
                PresentModalViewController (welcomeViewController, true);
				justSignedIn = true;
            }
        }



        #endregion

        #region Properties

        public bool EnableCheckIn = false;

		#endregion

		void SetupSearch()
		{
			var activity = new NSUserActivity("com.micjames.beerdrinkin.beerdetails");

			if (!string.IsNullOrEmpty(beer.Description))
			{
				var info = new NSMutableDictionary();
				info.Add(new NSString("id"), new NSString(beer.BreweryDbId));
				info.Add(new NSString("name"), new NSString(beer.Name));
				info.Add(new NSString("description"), new NSString(beer.Description));
				info.Add(new NSString("abv"), new NSString(beer?.ABV.ToString()));
				info.Add(new NSString("breweryDbId"), new NSString(beer.BreweryDbId));
			
				if (string.IsNullOrEmpty(beer.ImageMedium) == false) 
				{
					info.Add(new NSString("imageUrl"), new NSString(beer?.ImageMedium));
				}

				var attributes = new CSSearchableItemAttributeSet();
				attributes.DisplayName = beer.Name;
				attributes.ContentDescription = beer.Description;

				var keywords = new NSString[] { new NSString(beer.Name), new NSString("beerName") };
				activity.Keywords = new NSSet<NSString>(keywords);
				activity.ContentAttributeSet = attributes;

				activity.Title = beer.Name;
				activity.UserInfo = info;

				activity.EligibleForSearch = true;
				activity.EligibleForPublicIndexing = true;
				activity.BecomeCurrent();
			}

        }

        public void SetBeer (BeerItem item)
        {
            beer = item;    
        }

        public void SetBeerInfo (BeerInfo item)
        {
            beerInfo = item;
        }

        void UpdateHeaderView ()
        {
            var headerRect = new CGRect (0, -headerViewHeight, tableView.Frame.Width, headerViewHeight);
            if (tableView.ContentOffset.Y < -headerViewHeight) {
                headerRect.Location = new CGPoint (headerRect.Location.X, tableView.ContentOffset.Y);
                headerRect.Size = new CGSize (headerRect.Size.Width, -tableView.ContentOffset.Y);
            }
            headerView.Frame = headerRect;
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

			if (string.IsNullOrEmpty(beer.ImageMedium) == false) {
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
        }

        async void AddPurchase()
        {

            var response = await Client.Instance.BeerDrinkinClient.GetBeerDistributors(beer.Id);
            if (response.Result == null)
                return;

            var cellIdentifier = new NSString("distributorCell");
            var cell = tableView.DequeueReusableCell (cellIdentifier) as PurchaseTableViewCell ?? new PurchaseTableViewCell (cellIdentifier);

            var price = priceLookup.GetPriceForBeer(beer.Id.ToString());
            beer.Price = price;

            var beerPrice = decimal.Parse(price);
            cell.Price = beerPrice;
            cell.Quantity = 0;
            cell.DistributorName = "Beer Merchants";
            cell.TagLine = "Great beers to your door";

            cells.Add (cell);
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

			headerCell.EditingAbv += delegate {
				this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIBarButtonSystemItem.Done,delegate {
					headerCell.EndEditingAbv();
					this.NavigationItem.RightBarButtonItem = null;
				}), true);
			};

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