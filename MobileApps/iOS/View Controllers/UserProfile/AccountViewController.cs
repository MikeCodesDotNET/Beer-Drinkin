using System;
using System.Collections.Generic;

using CoreGraphics;
using Foundation;
using UIKit;

using BeerDrinkin.Core.Abstractions.ViewModels;
using BeerDrinkin.Utils;

namespace BeerDrinkin.iOS
{
    partial class AccountViewController : UITableViewController
    {
        IUserProfileViewModel viewModel;
        float defaultHeaderHeight = 350;
        ProfileHeaderView profileHeader; 

        public AccountViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            viewModel = ServiceLocator.Instance.Resolve<IUserProfileViewModel>();

            NavigationController.NavigationBarHidden = true;
        }   

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            profileHeader = ProfileHeaderView.Create();
            profileHeader.Frame = new CGRect(0, 0, View.Frame.Width, defaultHeaderHeight);

            TableView.AddSubview(profileHeader);
            TableView.ContentInset = new UIEdgeInsets(defaultHeaderHeight, 0, 0, 0);
            TableView.BackgroundColor = Helpers.Style.Colors.Grey;
            UpdateHeaderView();

            var dataSource = new AccountDataSource();
            TableView.Source = dataSource;

            var deleg = new AccountDelegate();
            deleg.DidScroll += UpdateHeaderView;
            TableView.Delegate = deleg;
        }

        void UpdateHeaderView()
        {
            var headerRect = new CGRect(0, -defaultHeaderHeight, TableView.Frame.Width, defaultHeaderHeight);
            if (TableView.ContentOffset.Y < -defaultHeaderHeight)
            {
                headerRect.Location = new CGPoint(headerRect.Location.X, TableView.ContentOffset.Y);
                headerRect.Size = new CGSize(headerRect.Size.Width, -TableView.ContentOffset.Y);
            }
            profileHeader.Frame = headerRect;
        }

        #region Classses
        class AccountDelegate : UITableViewDelegate
        {
            readonly List<UITableViewCell> cells = new List<UITableViewCell>();

            public AccountDelegate()
            {
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                return 50;
            }

            public override void Scrolled(UIScrollView scrollView)
            {
                DidScroll();
            }

            public delegate void DidScrollEventHandler();
            public event DidScrollEventHandler DidScroll;
        }

        class AccountDataSource : UITableViewSource
        {
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                return new UITableViewCell();
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return 0;
            }
        }
        #endregion
    }
}