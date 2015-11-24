using System;
using System.Collections.Generic;

using Foundation;
using UIKit;

using BeerDrinkin.Service.DataObjects;
using Color = BeerDrinkin.Helpers.Colours;

using SDWebImage;

namespace BeerDrinkin.iOS
{
    public class SearchDataSource : UITableViewSource
    {
        #region Fields
        private readonly NSString cellIdentifier = new NSString("beercell");

        #endregion

        #region Constructor
        public SearchDataSource(List<BeerItem> beers)
        {
            Beers = beers;
        }

        #endregion

        #region Properties
        public readonly List<BeerItem> Beers;

        #endregion

        #region Implemented abstract members of UITableViewSource

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var beerItem = Beers[indexPath.Row];

            var cell = tableView.DequeueReusableCell(cellIdentifier) as SearchBeerTableViewCell ?? new SearchBeerTableViewCell(cellIdentifier);

            cell.Name = beerItem.Name;
            cell.Brewery = beerItem.Brewery;
            cell.Style = beerItem.Style?.Name;
            cell.isCheckedIn = beerItem.IsCheckedIn;
            if (beerItem.Large != null)
            {
                cell.Image.SetImage(new NSUrl(beerItem.Large), UIImage.FromBundle("BeerDrinkin.png"));
            }
            else
            {
                cell.Image.Image = UIImage.FromBundle("BeerDrinkin.png");
            }
                          
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

        #endregion
    }
}