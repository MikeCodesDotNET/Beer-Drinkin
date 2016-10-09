using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using BeerDrinkin.Models;
using SDWebImage;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverUsersViewController : UITableViewController
    {
        string DiscoverUserCellIndeitifier = "DISCOVER_USER_CELL";
        List<User> trendingBeers = new List<User>();

        public DiscoverUsersViewController (IntPtr handle) : base (handle)
        {
        }

        #region UITableViewSource

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return trendingBeers.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var user = trendingBeers[indexPath.Row];
            var cell = tableView.DequeueReusableCell(DiscoverUserCellIndeitifier) as DiscoverUsersTableViewCell;

            if (cell == null)
            {
                cell = new DiscoverUsersTableViewCell(new NSString(DiscoverUserCellIndeitifier));
            }
            cell.Name = $"{user.FirstName} {user.LastName}";
           

            return cell;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 156;
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return false;
        }

        #endregion
    }
}