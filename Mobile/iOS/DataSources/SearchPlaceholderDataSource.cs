using System;
using UIKit;
using Foundation;
using BeerDrinkin.iOS.CustomControls;
using Acr.UserDialogs;
using BeerDrinkin.Core.Services;
using Xamarin;
using BeerDrinkin.iOS.Helpers;

namespace BeerDrinkin.iOS.DataSources
{
    public class SearchPlaceholderDataSource : UITableViewSource
    {        
		private BarcodeLookupService barcodeLookupService = new BarcodeLookupService();
		private SearchViewController viewController;

        public SearchPlaceholderDataSource(SearchViewController viewController)
        {
			this.viewController = viewController;
        }

        #region implemented abstract members of UITableViewSource

        public override nint NumberOfSections(UITableView tableView)
        {
			return CameraDeviceAvailable == true ? 2 : 1;
		}

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            if(indexPath.Section == 0)
            {
                var index = indexPath.Row;
                if (index == 0)
                {
                    var cellIdentifier = new NSString("noRecentSearchesViewCell");
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

			if (UIImagePickerController.IsCameraDeviceAvailable(UIImagePickerControllerCameraDevice.Rear) == true)
			{
				if(indexPath.Section == 1)
				{
					var cellIdentifier = new NSString("barcodeSearchTableViewCell");
					var cell = tableView.DequeueReusableCell(cellIdentifier) as BarcodeSearchTableViewCell ?? new BarcodeSearchTableViewCell(cellIdentifier);
					cell.ScanBeer += async () =>
					{
						try
						{
							var barcodeScanner = new ZXing.Mobile.MobileBarcodeScanner(viewController);
							var barcodeResult = await barcodeScanner.Scan();

							if (string.IsNullOrEmpty(barcodeResult.Text))
								return;

							var Beers = await barcodeLookupService.SearchForBeer(barcodeResult.Text);
							if (Beers != null)
							{
							}
						}
						catch (Exception ex)
						{
							Insights.Report(ex);
						}
						finally
						{
							UserDialogs.Instance.HideLoading();
						}
					};
					return cell;
				}
			}

            return new UITableViewCell();           
        }

		public override UIView GetViewForHeader(UITableView tableView, nint section)
		{
			var cellIdentifier = new NSString("searchHeaderViewCell");
			var headerCell = tableView.DequeueReusableCell(cellIdentifier) as SearchHeaderViewCell ?? new SearchHeaderViewCell(cellIdentifier);

			if (section == 0)
			{
				headerCell.Title = "Your recent searches";
			}

			if (CameraDeviceAvailable == true)
			{
				if (section == 1)
				{
					headerCell.Title = "Barcode";
				}

			}
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
                return 116;
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
    }
}

