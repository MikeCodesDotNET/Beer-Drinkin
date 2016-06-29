using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using BeerDrinkin.DataObjects;
using SDWebImage;
using BeerDrinkin.iOS.CustomControls;
using BeerDrinkin.iOS.PreviewingDelegate;
using BeerDrinkin.Core.Abstractions.ViewModels;
using BeerDrinkin.Utils;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverBeersViewController : UITableViewController
    {
        ITrendingBeersViewModel viewModel;
        string TrendingBeerCellIndeitifier = "TRENDING_BEER_CELL";
        public List<Beer> Beers = new List<Beer>();

        public DiscoverBeersViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            viewModel = ServiceLocator.Instance.Resolve<ITrendingBeersViewModel>();

            Console.WriteLine(TraitCollection.ForceTouchCapability);
            if (TraitCollection.ForceTouchCapability == UIForceTouchCapability.Available)
            {
                RegisterForPreviewingWithDelegate(new DiscoverBeerPreviewingDelegate(this), View);
            }

            Beers = await viewModel.FetchTrendingBeers(10);
            TableView.ReloadData();
        }

        #region UITableViewSource

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return Beers.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var beer = Beers[indexPath.Row];        
            var cell = tableView.DequeueReusableCell(TrendingBeerCellIndeitifier) as TrendingBeerCell;

            if (cell == null)
            {
                cell = new TrendingBeerCell(new NSString(TrendingBeerCellIndeitifier));
            }

            cell.Name = beer.Name;
            cell.Brewery = beer?.Brewery.Name;

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

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var beer = Beers[indexPath.Row];
            DidSelectBeer(beer);
        }
        #endregion

        public delegate void RowSelectedHandler(Beer beer);
        public event RowSelectedHandler DidSelectBeer;

        public delegate void PictureImportHandler();
        public event PictureImportHandler PictureImport;

        partial void PhotoImportButton_TouchUpInside(DiscoverCameraButton sender)
        {
            PictureImport();
        }
    }
}