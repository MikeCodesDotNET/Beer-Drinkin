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
    [Register ("RateBeerViewController")]
    partial class RateBeerViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCheckIn { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLoveIt { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNotForMe { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider sldRating { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        BeerDrinkin.iOS.CustomControls.PlaceholderTextView tbxComment { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnCheckIn != null) {
                btnCheckIn.Dispose ();
                btnCheckIn = null;
            }

            if (lblLoveIt != null) {
                lblLoveIt.Dispose ();
                lblLoveIt = null;
            }

            if (lblNotForMe != null) {
                lblNotForMe.Dispose ();
                lblNotForMe = null;
            }

            if (sldRating != null) {
                sldRating.Dispose ();
                sldRating = null;
            }

            if (tbxComment != null) {
                tbxComment.Dispose ();
                tbxComment = null;
            }
        }
    }
}