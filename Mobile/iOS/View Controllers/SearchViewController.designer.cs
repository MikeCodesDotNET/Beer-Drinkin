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
        UIKit.UITableView placeHolderTableView { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar searchBar { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView searchResultsTableView { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView suggestionsTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (placeHolderTableView != null) {
                placeHolderTableView.Dispose ();
                placeHolderTableView = null;
            }

            if (searchBar != null) {
                searchBar.Dispose ();
                searchBar = null;
            }

            if (searchResultsTableView != null) {
                searchResultsTableView.Dispose ();
                searchResultsTableView = null;
            }

            if (suggestionsTableView != null) {
                suggestionsTableView.Dispose ();
                suggestionsTableView = null;
            }
        }
    }
}