using System;
using System.Collections.ObjectModel;
using System.Linq;

using Foundation;
using UIKit;

using Colour = BeerDrinkin.Helpers.Colours;

using SDWebImage;
using SWTableViewCell;
using Splat;
using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.iOS
{
    public class MyBeersDataSource : UITableViewSource
    {
        #region Fields
        private readonly ObservableCollection<BeerInfo> beers;
        private readonly NSString cellIdentifier = new NSString("beercell");

        #endregion

        #region Constructor
        public MyBeersDataSource(ObservableCollection<BeerInfo> beers)
        {
            this.beers = beers;
        }

        #endregion

        async void DeleteItem(string beerId)
        {
            await Client.Instance.BeerDrinkinClient.DeleteBeerCheckinsAsync(beerId);
        }

        #region Implemented abstract members of UITableViewSourceSink

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var beerCheckedIn = beers[indexPath.Row];
            var beer = beerCheckedIn.CheckIns.FirstOrDefault().Beer;

            var cell = tableView.DequeueReusableCell(cellIdentifier) as MyBeersTableViewCell ?? new MyBeersTableViewCell(cellIdentifier);
            cell.Name = beerCheckedIn.Name;
            cell.Brewery = beer?.Brewery;
           
            if (beer.ImageMedium != null)
            {
                cell.Image.SetImage(new NSUrl(beer?.ImageMedium), UIImage.FromBundle("BeerDrinkin.png"));
            }
            else
            {
                cell.Image.Image = UIImage.FromBundle("BeerDrinkin.png");
            }

            var cellDelegate = new MyBeerCellDelegate();
            cellDelegate.DeleteBeer += () =>
            {
                var beerId = beers[indexPath.Row].BreweryDbId;
                DeleteItem(beerId);
                beers.RemoveAt(indexPath.Row);                
            };

            cell.Delegate = cellDelegate;
            var deleteButton = new UIButton(UIButtonType.RoundedRect)
            {
                BackgroundColor = Colour.Red.ToNative(),
                TintColor = Colour.White.ToNative()
            };
            deleteButton.SetImage(UIImage.FromFile("711-trash@3x.png"), UIControlState.Normal);
            cell.SetRightUtilityButtons(new[] { deleteButton }, 90);


            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return beers.Count;
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            DidSelectBeer?.Invoke(beers[indexPath.Row]);
        }

        public delegate void RowSelectedHandler(BeerInfo beer);

        public event RowSelectedHandler DidSelectBeer;

        #endregion

        class MyBeerCellDelegate : SWTableViewCellDelegate
        {
            public override void DidTriggerRightUtilityButton(SWTableViewCell.SWTableViewCell cell, nint index)
            {
                DeleteBeer();
            }

            public delegate void DeleteBeerHandler();

            public event DeleteBeerHandler DeleteBeer;
        }
    }
}