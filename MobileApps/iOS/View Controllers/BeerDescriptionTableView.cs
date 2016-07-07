using System;
using System.Collections.Generic;
using System.Globalization;

using CoreGraphics;
using UIKit;

using BeerDrinkin.DataObjects;
using BeerDrinkin.iOS.DataSources;

using SDWebImage;
using Foundation;

using Plugin.Share;
using BeerDrinkin.Core.ViewModels;

namespace BeerDrinkin.iOS
{
    partial class BeerDescriptionTableView : UIViewController
    {
        BeerDescriptionViewModel viewModel;
        List<UITableViewCell> cells = new List<UITableViewCell> ();

        BeerDescriptionHeaderView headerView;
        nfloat headerViewHeight = 394;

        public BeerDescriptionTableView (IntPtr handle) : base (handle)
        {
        }

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
            tableView.ReloadData ();	
        }

		public void Share()
		{
			CrossShare.Current.Share(viewModel.Name, viewModel.Description);
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
            navctlr.SetBeer (viewModel.Beer);
        }


        async partial void btnShare_Activated (UIBarButtonItem sender)
        {
            var text = viewModel.SharingMessage;
            var items = new NSObject[] { new NSString (text) };
            var activityController = new UIActivityViewController (items, null);
            await PresentViewControllerAsync (activityController, true);
        }

        async partial void BtnCheckIn_TouchUpInside (UIButton sender)
        {
            var vc = Storyboard.InstantiateViewController("BEER_CHECKIN") as CheckInViewController;
            if (vc == null)
                return;

            vc.Beer = viewModel.Beer;
            await PresentViewControllerAsync(vc, true);
        }

        public bool EnableCheckIn = false;

        public void SetBeer (Beer beer)
        {
            viewModel = new BeerDescriptionViewModel(beer);
            viewModel.SearchProvider.AddBeerToIndex(beer);
        }

        void UpdateHeaderView ()
        {
            var headerRect = new CGRect (0, -headerViewHeight, tableView.Frame.Width, headerViewHeight);
            if (tableView.ContentOffset.Y < -headerViewHeight) 
            {
                headerRect.Location = new CGPoint (headerRect.Location.X, tableView.ContentOffset.Y);
                headerRect.Size = new CGSize (headerRect.Size.Width, -tableView.ContentOffset.Y);
            }
            headerView.Frame = headerRect;
        }

        void SetUpUI ()
        {
            Title = new CultureInfo ("en-US").TextInfo.ToTitleCase (viewModel.Name);
            NavigationItem.SetLeftBarButtonItem (new UIBarButtonItem (UIImage.FromFile ("NavigationBar_Back.png"), UIBarButtonItemStyle.Plain, (sender, args) => {NavigationController.PopViewController (true);}), true);

            btnCheckIn.Layer.CornerRadius = 4;
            btnCheckIn.Layer.MasksToBounds = true;

            headerView = BeerDescriptionHeaderView.Create();
            headerView.SetBeer(viewModel.Beer);
            tableView.TableHeaderView = null;
            tableView.AddSubview (headerView);
            tableView.ContentInset = new UIEdgeInsets (headerViewHeight, 0, 0, 0);
            tableView.BackgroundColor = UIColor.Clear;

            //Add Cells
            AddRating();
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

        void AddDescription ()
        {
            if (!string.IsNullOrEmpty (viewModel.Description)) {
                var cellIdentifier = new NSString ("descriptionCell");
                var cell = tableView.DequeueReusableCell (cellIdentifier) as BeerDescriptionCell ?? new BeerDescriptionCell (cellIdentifier);

                cell.Text = viewModel.Description;
                cells.Add (cell);
            }
        }

        void AddRating()
        {
            var cellIdentifier = new NSString("StarRatingCellIdentifier");
            var cell = tableView.DequeueReusableCell(cellIdentifier) as StarRatingTableViewCell ?? new StarRatingTableViewCell(cellIdentifier);

            cells.Add(cell);
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

                if (cell.GetType() == typeof(StarRatingTableViewCell))
                    return 74;

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