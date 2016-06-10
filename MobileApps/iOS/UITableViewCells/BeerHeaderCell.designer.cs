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
    [Register ("BeerHeaderCell")]
    partial class BeerHeaderCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView divider { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAbv { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblBrewery { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblConsumed { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblConsumedTitle { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblName { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblRating { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblRatingTitle { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbxAbv { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (divider != null) {
                divider.Dispose ();
                divider = null;
            }

            if (lblAbv != null) {
                lblAbv.Dispose ();
                lblAbv = null;
            }

            if (lblBrewery != null) {
                lblBrewery.Dispose ();
                lblBrewery = null;
            }

            if (lblConsumed != null) {
                lblConsumed.Dispose ();
                lblConsumed = null;
            }

            if (lblConsumedTitle != null) {
                lblConsumedTitle.Dispose ();
                lblConsumedTitle = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (lblRating != null) {
                lblRating.Dispose ();
                lblRating = null;
            }

            if (lblRatingTitle != null) {
                lblRatingTitle.Dispose ();
                lblRatingTitle = null;
            }

            if (tbxAbv != null) {
                tbxAbv.Dispose ();
                tbxAbv = null;
            }
        }
    }
}