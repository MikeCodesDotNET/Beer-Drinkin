using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using CoreGraphics;
using UIKit;

using BeerDrinkin.DataObjects;
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

        List<UITableViewCell> cells = new List<UITableViewCell> ();
		bool justSignedIn;
        Beer beer;

        const string activityName = "com.beerdrinkin.beer";
        UIView headerView;
        nfloat headerViewHeight = 200;

        #endregion

        #region Constructor

        public BeerDescriptionTableView (IntPtr handle) : base (handle)
        {
            beer = new Beer();
        }

        #endregion

        #region Overrides

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            NavigationController.NavigationBar.BackgroundColor = Helpers.Style.Colors.Blue;
            NavigationController.NavigationBar.TintColor = UIColor.White;
            SetUpUI();
        }

		public override void ViewDidAppear (bool animated)
        {
            base.ViewDidAppear (animated);
            TabBarController.TabBar.Hidden = true;

            tableView.ReloadData ();	
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
            var vc = Storyboard.InstantiateViewController("BEER_CHECKIN") as CheckInViewController;
            if (vc == null)
                return;

            vc.Beer = beer;
            await PresentViewControllerAsync(vc, true);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            TabBarController.TabBar.Hidden = false;
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
				info.Add(new NSString("abv"), new NSString(beer?.Abv.ToString()));
				info.Add(new NSString("breweryDbId"), new NSString(beer.BreweryDbId));
			
                if (beer.Image != null)
				{
					info.Add(new NSString("imageUrl"), new NSString(beer?.Image.MediumUrl));
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

        public void SetBeer (Beer item)
        {
            beer = item;
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

            UIBarButtonItem btnShare = new UIBarButtonItem();
            btnShare.Clicked += delegate
            {
                Share();
            };
            btnShare.Title = "Share";
            btnShare.Image = UIImage.FromFile("702-share.png");
            NavigationItem.RightBarButtonItem = btnShare;

            headerView = tableView.TableHeaderView;
            tableView.TableHeaderView = null;
            tableView.AddSubview (headerView);
            tableView.ContentInset = new UIEdgeInsets (headerViewHeight, 0, 0, 0);
            tableView.BackgroundColor = UIColor.Clear;

			if (string.IsNullOrEmpty(beer.Image.MediumUrl) == false) {
                imgHeaderView.SetImage (new NSUrl (beer?.Image.MediumUrl), UIImage.FromBundle ("BeerDrinkin.png"));
            } else {
                imgHeaderView.Image = UIImage.FromBundle ("BeerDrinkin.png");
            }

            //Add Cells
            AddHeaderInfo ();
            AddDescription ();

            //Update Tableview
            tableView.Source = new BeerDescriptionDataSource(ref cells);
            var deleg = new DescriptionDelegate (ref cells);
            deleg.DidScroll += UpdateHeaderView;
            tableView.Delegate = deleg;

            tableView.ReloadData ();
            View.SetNeedsDisplay ();
        }

        #region AddCells

        void AddHeaderInfo ()
        {
            var headerCellIdentifier = new NSString ("headerCell");
            var headerCell = tableView.DequeueReusableCell (headerCellIdentifier) as BeerHeaderCell ??
                             new BeerHeaderCell (headerCellIdentifier);
            headerCell.Name = beer?.Name;
            headerCell.Brewery = beer?.Brewery?.Name;
            headerCell.Abv = beer.Abv.ToString();

            headerCell.ConsumedAlpha = 0.3f;
            headerCell.RatingAlpha = 0.3f;

			headerCell.EditingAbv += delegate 
            {
				NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate 
                {
					headerCell.EndEditingAbv();
					NavigationItem.RightBarButtonItem = null;
				}), true);
			};

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