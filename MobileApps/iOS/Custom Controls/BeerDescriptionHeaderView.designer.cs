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
    [Register ("BeerDescriptionHeaderView")]
    partial class BeerDescriptionHeaderView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        BeerDrinkin.iOS.CustomControls.BeerStatsView statsView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (image != null) {
                image.Dispose ();
                image = null;
            }

            if (statsView != null) {
                statsView.Dispose ();
                statsView = null;
            }
        }
    }
}