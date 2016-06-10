using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.PreviewingDelegates
{
	public class SearchPreviewingDelegate : UIViewControllerPreviewingDelegate
	{
		#region Computed Properties
		public SearchViewController MasterController { get; set; }
		#endregion

		#region Constructors
		public SearchPreviewingDelegate(SearchViewController masterController)
		{
			// Initialize
			this.MasterController = masterController;
		}

		public SearchPreviewingDelegate (NSObjectFlag t) : base(t)
		{
		}

		public SearchPreviewingDelegate (IntPtr handle) : base (handle)
		{
		}
		#endregion

		#region Override Methods
		/// Present the view controller for the "Pop" action.
		public override void CommitViewController (IUIViewControllerPreviewing previewingContext, UIViewController viewControllerToCommit)
		{
			// Reuse Peek view controller for details presentation
			MasterController.ShowViewController(viewControllerToCommit,this);
		}

		/// Create a previewing view controller to be shown at "Peek".
		public override UIViewController GetViewControllerForPreview (IUIViewControllerPreviewing previewingContext, CGPoint location)
		{
			// Grab the item to preview
			var indexPath = MasterController.SearchResultsTableView.IndexPathForRowAtPoint (location);
			var cell = MasterController.SearchResultsTableView.CellAt (indexPath);
			var item = MasterController.SelectedBeer;

			// Grab a controller and set it to the default sizes
			var detailViewController = MasterController.Storyboard.InstantiateViewController ("beerDetailsTableViewController") as BeerDescriptionTableView;
			detailViewController.PreferredContentSize = new CGSize (0, 0);

			// Set the data for the display
			detailViewController.SetBeer (item);
			detailViewController.NavigationItem.LeftBarButtonItem = MasterController.SplitViewController.DisplayModeButtonItem;
			detailViewController.NavigationItem.LeftItemsSupplementBackButton = true;

			// Set the source rect to the cell frame, so everything else is blurred.
			previewingContext.SourceRect = cell.Frame;

			return detailViewController;
		}
		#endregion
	}
}

