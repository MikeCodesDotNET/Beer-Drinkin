using System;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.DataSources
{
	public class CheckInDataSource : UITableViewSource
	{
		public CheckInDataSource()
		{
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			return new UITableViewCell();
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return 4;
		}
	}
}

