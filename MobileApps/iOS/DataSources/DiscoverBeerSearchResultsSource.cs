using System;
using System.Collections.Generic;

using Foundation;
using UIKit;

using SDWebImage;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.iOS
{
    public class DiscoverBeerSearchResultsSource : UITableViewSource
    {
        #region Fields
        private readonly NSString cellIdentifier = new NSString("DISCOVER_BEER_RESULT");

        #endregion

        #region Constructor
        public DiscoverBeerSearchResultsSource(List<Beer> beers)
        {
            Beers = beers;
        }

        #endregion

        #region Properties
        public readonly List<Beer> Beers;

        #endregion



        #region Implemented abstract members of UITableViewSource

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var Beer = Beers[indexPath.Row];

            var cell = tableView.DequeueReusableCell(cellIdentifier) as DiscoverBeerResultCell ?? new DiscoverBeerResultCell(cellIdentifier);

            cell.Name = Beer.Name;

            /*
            if (!string.IsNullOrEmpty(Beer.Image.MediumUrl))
            {
                cell.Image.SetImage(new NSUrl(Beer?.Image?.MediumUrl), UIImage.FromBundle("BeerDrinkin.png"));
            }
            else
            {
                cell.Image.Image = UIImage.FromBundle("BeerDrinkin.png");
            }
            */
                          
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

        public delegate void RowSelectedHandler(Beer beer);
        public event RowSelectedHandler DidSelectBeer;

        #endregion
    }
}