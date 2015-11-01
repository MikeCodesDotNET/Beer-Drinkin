using System;
using UIKit;
using Foundation;
using CoreGraphics;
using BeerDrinkin.Core.ViewModels;

namespace BeerDrinkin.iOS.PreviewingDelegates
{
    public class BeerDescriptionPreviewingDelegate : UIViewControllerPreviewingDelegate
    {
        #region Computed Properties
        SearchViewController SearchController;
        #endregion

        #region Constructors
        public BeerDescriptionPreviewingDelegate (SearchViewController searchController)
        {
            // Initialize
            SearchController = searchController;
        }

        public BeerDescriptionPreviewingDelegate (NSObjectFlag t) : base(t)
        {
        }

        public BeerDescriptionPreviewingDelegate (IntPtr handle) : base (handle)
        {
        }
        #endregion

        #region Override Methods
        /// Present the view controller for the "Pop" action.
        public override void CommitViewController (IUIViewControllerPreviewing previewingContext, UIViewController viewControllerToCommit)
        {
            // Reuse Peek view controller for details presentation
            SearchController.ShowViewController(viewControllerToCommit,this);
        }

        /// Create a previewing view controller to be shown at "Peek".
        public override UIViewController GetViewControllerForPreview (IUIViewControllerPreviewing previewingContext, CGPoint location)
        {
            // Grab the item to preview
            var indexPath = SearchController.SearchResultsTableView.IndexPathForRowAtPoint (location);
            var cell = SearchController.SearchResultsTableView.CellAt (indexPath);
            var item = SearchController.DataSource.Beers[indexPath.Row];

            // Grab a controller and set it to the default sizes
            var detailViewController = SearchController.Storyboard.InstantiateViewController ("beerDescriptionView") as BeerDescriptionTableView;
            detailViewController.PreferredContentSize = new CGSize (0, 0);

            // Set the data for the display
            detailViewController.SetBeer (item);
            detailViewController.NavigationItem.LeftBarButtonItem = SearchController.SplitViewController.DisplayModeButtonItem;
            detailViewController.NavigationItem.LeftItemsSupplementBackButton = true;

            // Set the source rect to the cell frame, so everything else is blurred.
            previewingContext.SourceRect = cell.Frame;

            return detailViewController;
        }
        #endregion


    }
}

