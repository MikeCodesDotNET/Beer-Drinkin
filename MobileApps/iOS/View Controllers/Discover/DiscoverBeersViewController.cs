using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using BeerDrinkin.DataObjects;
using SDWebImage;
using BeerDrinkin.iOS.CustomControls;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverBeersViewController : UITableViewController
    {
        Core.ViewModels.DiscoverViewModel viewModel;
        string TrendingBeerCellIndeitifier = "TRENDING_BEER_CELL";
        List<Beer> trendingBeers = new List<Beer>();

        public DiscoverBeersViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            viewModel = new Core.ViewModels.DiscoverViewModel();
            trendingBeers = await viewModel.TrendingBeers(10);
            TableView.ReloadData();
        }

        #region UITableViewSource

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return trendingBeers.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var beer = trendingBeers[indexPath.Row];        
            var cell = tableView.DequeueReusableCell(TrendingBeerCellIndeitifier) as TrendingBeerCell;

            if (cell == null)
            {
                cell = new TrendingBeerCell(new NSString(TrendingBeerCellIndeitifier));
            }

            cell.Name = beer.Name;
            cell.Brewery = beer.Brewery;

            if (beer.ImageMedium != null)
            {
                cell.Image.SetImage(new NSUrl(beer.ImageMedium), UIImage.FromBundle("BeerDrinkin.png"));
            }
            else
            {
                cell.Image.Image = UIImage.FromBundle("BeerDrinkin.png");
            }

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

        partial void PhotoImportButton_TouchUpInside(DiscoverCameraButton sender)
        {
            throw new NotImplementedException();
        }
    }
}