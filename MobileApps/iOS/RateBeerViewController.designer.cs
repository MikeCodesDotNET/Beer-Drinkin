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
        BeerDrinkin.iOS.CustomControls.PlaceholderTextView tbxComment { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnCheckIn != null) {
                btnCheckIn.Dispose ();
                btnCheckIn = null;
            }

            if (tbxComment != null) {
                tbxComment.Dispose ();
                tbxComment = null;
            }
        }
    }
}