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
            var imagePicker = new UIImagePickerController();
            imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
            PresentViewController(imagePicker, true, null);
            imagePicker.Canceled += async delegate
            {
                await imagePicker.DismissViewControllerAsync(true);
            };

            imagePicker.FinishedPickingMedia += async (object s, UIImagePickerMediaPickedEventArgs e) =>
            {
                try
                {
                    await imagePicker.DismissViewControllerAsync(true);

                    var image = e.OriginalImage;
                    Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Uploading photo");

                    var stream = ScaledImage(image, 500, 500).AsPNG().AsStream();
                    await viewModel.ImageLookup(stream);
                    Acr.UserDialogs.UserDialogs.Instance.HideLoading();

                }
                catch (Exception ex)
                {
                    Acr.UserDialogs.UserDialogs.Instance.ShowError(ex.Message);
                }
            };


        }

        UIImage ScaledImage(UIImage image, nfloat maxWidth, nfloat maxHeight)
        {
            var maxResizeFactor = Math.Min(maxWidth / image.Size.Width, maxHeight / image.Size.Height);
            var width = maxResizeFactor * image.Size.Width;
            var height = maxResizeFactor * image.Size.Height;
            return image.Scale(new CoreGraphics.CGSize(width, height));
        }

    }
}