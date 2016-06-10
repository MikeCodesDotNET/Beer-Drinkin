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
        UIKit.UIButton btnBeer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBreweries { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnUsers { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrollView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        BeerDrinkin.iOS.SearchBar searchBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView searchTypeView { get; set; }

        [Action ("BtnBeer_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnBeer_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnBreweries_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnBreweries_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnUsers_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnUsers_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnBeer != null) {
                btnBeer.Dispose ();
                btnBeer = null;
            }

            if (btnBreweries != null) {
                btnBreweries.Dispose ();
                btnBreweries = null;
            }

            if (btnUsers != null) {
                btnUsers.Dispose ();
                btnUsers = null;
            }

            if (scrollView != null) {
                scrollView.Dispose ();
                scrollView = null;
            }

            if (searchBar != null) {
                searchBar.Dispose ();
                searchBar = null;
            }

            if (searchTypeView != null) {
                searchTypeView.Dispose ();
                searchTypeView = null;
            }
        }
    }
}