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
    [Register ("DiscoverViewController")]
    partial class DiscoverViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView beerResultsTable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView placeholderBackgroundView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        BeerDrinkin.iOS.SearchBar searchBar { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (beerResultsTable != null) {
                beerResultsTable.Dispose ();
                beerResultsTable = null;
            }

            if (placeholderBackgroundView != null) {
                placeholderBackgroundView.Dispose ();
                placeholderBackgroundView = null;
            }

            if (searchBar != null) {
                searchBar.Dispose ();
                searchBar = null;
            }
        }
    }
}