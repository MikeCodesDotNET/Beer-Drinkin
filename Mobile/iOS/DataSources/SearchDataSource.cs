using System;
using System.Collections.Generic;
using BeerDrinkin.Service.DataObjects;
using Foundation;
using SDWebImage;
using SWTableViewCell;
using UIKit;
using Color = BeerDrinkin.Helpers.Colours;
using Splat;

namespace BeerDrinkin.iOS
{
    public class SearchDataSource : UITableViewSource
    {
        public readonly List<BeerItem> Beers;
        private readonly NSString cellIdentifier = new NSString("beercell");

        public SearchDataSource(List<BeerItem> beers)
        {
            this.Beers = beers;
        }

        #region implemented abstract members of UITableViewSource

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var beer = Beers[indexPath.Row];

            var cell = tableView.DequeueReusableCell(cellIdentifier) as SearchBeerTableViewCell ??
                       new SearchBeerTableViewCell(cellIdentifier);
            cell.Name = beer.Name;
            cell.Brewery = beer.Brewery;
            cell.Style = beer.Style?.Name;
            cell.isCheckedIn = beer.IsCheckedIn;
            if (beer.Large != null)
                cell.Image.SetImage(new NSUrl(beer.Large), UIImage.FromBundle("BeerDrinkin.png")
                );
            else
            {
                cell.Image.Image = UIImage.FromBundle("BeerDrinkin.png");
            }

            var cellDelegate = new LookUpBeerCellDelegate();
            cellDelegate.CheckedInAt += delegate
            {
                CheckInBeer?.Invoke(beer, indexPath);
            };

            cell.Delegate = cellDelegate;
            var quickCheckInButton = new UIButton(UIButtonType.RoundedRect)
            {
                BackgroundColor = Color.Green.ToNative(),
                Font = UIFont.FromName("Avenir Book", 12),
                TintColor = UIColor.White
            };
            quickCheckInButton.SetTitle("Check In", UIControlState.Normal);
            cell.SetLeftUtilityButtons(new[] { quickCheckInButton }, 90);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Beers.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            DidSelectBeer?.Invoke(Beers[indexPath.Row]);
        }

        public delegate void RowSelectedHandler(BeerItem beer);

        public event RowSelectedHandler DidSelectBeer;

        public delegate void CheckInHandler(BeerItem beer,NSIndexPath indexPath);

        public event CheckInHandler CheckInBeer;

        /// <summary>
        /// The Cell Delegate used to handle the left swipe for quick checkin 
        /// </summary>
        private class LookUpBeerCellDelegate : SWTableViewCellDelegate
        {
            public delegate void CheckInSelectedHandler(int index);

            public override void DidTriggerLeftUtilityButton(SWTableViewCell.SWTableViewCell cell, nint index)
            {
                var searchBeerCell = cell as SearchBeerTableViewCell;
                if (searchBeerCell == null)
                    return;

                cell.ShowRightUtilityButtons(true);
                CheckedInAt?.Invoke((int)index);
            }

            public event CheckInSelectedHandler CheckedInAt;
        }

        #endregion
    }
}