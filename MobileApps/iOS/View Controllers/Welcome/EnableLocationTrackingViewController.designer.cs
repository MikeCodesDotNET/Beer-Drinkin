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
    [Register ("EnableLocationTrackingViewController")]
    partial class EnableLocationTrackingViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnEnableLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnNoThanks { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgMap { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTitle { get; set; }

        [Action ("BtnEnableLocation_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnEnableLocation_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnNoThanks_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnNoThanks_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnEnableLocation != null) {
                btnEnableLocation.Dispose ();
                btnEnableLocation = null;
            }

            if (btnNoThanks != null) {
                btnNoThanks.Dispose ();
                btnNoThanks = null;
            }

            if (imgMap != null) {
                imgMap.Dispose ();
                imgMap = null;
            }

            if (lblTitle != null) {
                lblTitle.Dispose ();
                lblTitle = null;
            }
        }
    }
}