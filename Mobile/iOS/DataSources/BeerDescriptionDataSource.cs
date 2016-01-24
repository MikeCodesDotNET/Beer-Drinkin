using System;
using System.Collections.Generic;

using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.DataSources
{
    public class BeerDescriptionDataSource : UITableViewSource
    {
        readonly List<UITableViewCell> cells = new List<UITableViewCell> ();

        public BeerDescriptionDataSource (ref List<UITableViewCell> cells)
        {
            this.cells = cells;
        }

        #region implemented abstract members of UITableViewSource

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            var cell = cells[indexPath.Row];
            cell.LayoutSubviews();
            return cell;
        }

        public override nint RowsInSection (UITableView tableview, nint section)
        {
            return cells.Count;
        }

        #endregion
    }
}

