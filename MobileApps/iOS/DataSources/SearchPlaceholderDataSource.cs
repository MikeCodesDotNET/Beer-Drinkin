using System;
using UIKit;
using Foundation;
using BeerDrinkin.iOS.Helpers;

namespace BeerDrinkin.iOS.DataSources
{
    public class SearchPlaceholderDataSource : UITableViewSource
    {        
		SearchViewController viewController;

        public SearchPlaceholderDataSource(SearchViewController viewController)
        {
			this.viewController = viewController;
        }

        #region implemented abstract members of UITableViewSource

        public override nint NumberOfSections(UITableView tableView)
        {
#if !DEBUG
			return CameraDeviceAvailable == true ? 2 : 1;
#else
			return 2;
			#endif
		}

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            if(indexPath.Section == 0)
            {
                var index = indexPath.Row;
                if (index == 0)
                {
                    var cellIdentifier = new NSString("NO_RECENT_SEARCHES__CELL_IDENTIFER");
                    var cell = tableView.DequeueReusableCell(cellIdentifier) as NoRecentSearchesViewCell ?? new NoRecentSearchesViewCell(cellIdentifier);

					if (SearchHistory.History.Count > 0)
					{
						cell.Text = SearchHistory.History.ToArray()[index];
						if (index == SearchHistory.History.Count)
						{
							cell.Background.Footer = true;
						}
						else
						{
							cell.Background.Default = true;
						}
					}

                    return cell;
                }
            }

			#if !DEBUG
			if (UIImagePickerController.IsCameraDeviceAvailable(UIImagePickerControllerCameraDevice.Rear) == true)
			{
				if(indexPath.Section == 1)
				{
					var cellIdentifier = new NSString("inAppPurchaseSearchTableViewCell");
					var cell = tableView.DequeueReusableCell(cellIdentifier) as InAppPurchaseSearchTableViewCell ?? new InAppPurchaseSearchTableViewCell(cellIdentifier);
					return cell;
				}
			}
			#else
			if(indexPath.Section == 1)
			{
				var cellIdentifier = new NSString("IMAGE_SCANNER_CELL_IDENTIFER");
				var cell = tableView.DequeueReusableCell(cellIdentifier) as InAppPurchaseSearchTableViewCell ?? new InAppPurchaseSearchTableViewCell(cellIdentifier);
				cell.SnapPhotoButtonTapped += delegate 
				{
					SnapPhotoButtonTapped();
				};
				return cell;
			}
			#endif

            return new UITableViewCell();           
        }

		public override UIView GetViewForHeader(UITableView tableView, nint section)
		{
			var cellIdentifier = new NSString("SEARCH_HEADER_CELL_IDENTIFER");
			var headerCell = tableView.DequeueReusableCell(cellIdentifier) as SearchHeaderViewCell ?? new SearchHeaderViewCell(cellIdentifier);

			if (section == 0)
			{
				headerCell.Title = "Your recent searches";
			}

			#if !DEBUG
			if (CameraDeviceAvailable == true)
			{
				if (section == 1)
				{
					headerCell.Title = "Image Recognition";
				}

			}
			#else
			if (section == 1)
			{
				headerCell.Title = "Image Recognition";
			}
			#endif

            return headerCell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
			if (section == 0)
			{
				var count = SearchHistory.History.Count;
				if (count == 0)
					return 1;
				return count;
			}
            return 1;
        }


        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 36;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            if(indexPath.Section == 1)
            {
				return 164;
            }
            return 36;
        }

		bool CameraDeviceAvailable
		{
			get
			{
				return UIImagePickerController.IsCameraDeviceAvailable(UIImagePickerControllerCameraDevice.Rear);
			}
		}

        #endregion

        public delegate void SnapPhotoButtonTappedHandler();
        public event SnapPhotoButtonTappedHandler SnapPhotoButtonTapped;
    }
}

