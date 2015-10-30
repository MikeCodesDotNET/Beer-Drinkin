// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	[Register ("SearchViewController")]
	partial class SearchViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem btnBarCodeScanner { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgSearch { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblFindBeers { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblSearchBeerDrinkin { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIScrollView scrllPlaceHolder { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISearchBar searchBar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tableView { get; set; }

		[Action ("BtnBarCodeScanner_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnBarCodeScanner_Activated (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnBarCodeScanner != null) {
				btnBarCodeScanner.Dispose ();
				btnBarCodeScanner = null;
			}
			if (imgSearch != null) {
				imgSearch.Dispose ();
				imgSearch = null;
			}
			if (lblFindBeers != null) {
				lblFindBeers.Dispose ();
				lblFindBeers = null;
			}
			if (lblSearchBeerDrinkin != null) {
				lblSearchBeerDrinkin.Dispose ();
				lblSearchBeerDrinkin = null;
			}
			if (scrllPlaceHolder != null) {
				scrllPlaceHolder.Dispose ();
				scrllPlaceHolder = null;
			}
			if (searchBar != null) {
				searchBar.Dispose ();
				searchBar = null;
			}
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}
}
