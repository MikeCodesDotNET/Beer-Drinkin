using System;
using System.Collections.ObjectModel;
using System.Linq;

using Foundation;
using UIKit;


using SDWebImage;
using SWTableViewCell;
using BeerDrinkin.Models;

namespace BeerDrinkin.iOS
{
    public class MyBeersDataSource : UITableViewSource
    {
        #region Fields
        private readonly ObservableCollection<Beer> beers;
        private readonly NSString cellIdentifier = new NSString("beercell");

        #endregion

        #region Constructor
        public MyBeersDataSource(ObservableCollection<Beer> beers)
        {
            this.beers = beers;
        }

        #endregion

        void DeleteItem(string beerId)
        {
        }

        #region Implemented abstract members of UITableViewSourceSink

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell();
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

        public delegate void RowSelectedHandler(Beer beer);

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