using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.PreviewingDelegate
{
    public class DiscoverBeerPreviewingDelegate : UIViewControllerPreviewingDelegate
    {
        public DiscoverBeersViewController beerViewController { get; set; }

        public DiscoverBeerPreviewingDelegate(DiscoverBeersViewController viewController)
        {
            beerViewController = viewController;
        }

        public DiscoverBeerPreviewingDelegate(NSObjectFlag t) : base(t)
        {
        }

        public DiscoverBeerPreviewingDelegate(IntPtr handle) : base (handle)
        {
        }

        public override void CommitViewController(IUIViewControllerPreviewing previewingContext, UIViewController viewControllerToCommit)
        {
            beerViewController.ShowViewController(viewControllerToCommit, this);
        }

        public override UIViewController GetViewControllerForPreview(IUIViewControllerPreviewing previewingContext, CGPoint location)
        {

            // Grab the item to preview
            var indexPath = beerViewController.TableView.IndexPathForRowAtPoint(location);
            var cell = beerViewController.TableView.CellAt(indexPath);
            var item = beerViewController.Beers[indexPath.Row];

            // Grab a controller and set it to the default sizes
            var detailViewController = beerViewController.Storyboard.InstantiateViewController("BEER_DESCRIPTION") as BeerDescriptionTableView;
            detailViewController.PreferredContentSize = new CGSize(0, 0);

            // Set the data for the display
            detailViewController.SetBeer(item);
            detailViewController.NavigationItem.LeftBarButtonItem = beerViewController.SplitViewController.DisplayModeButtonItem;
            detailViewController.NavigationItem.LeftItemsSupplementBackButton = true;

            // Set the source rect to the cell frame, so everything else is blurred.
            previewingContext.SourceRect = cell.Frame;

            return detailViewController;
        }
    }
}

