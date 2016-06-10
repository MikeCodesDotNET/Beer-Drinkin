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
    [Register ("CameraViewController")]
    partial class CameraViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView bottomBar { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBack { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnTakePhoto { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnToggleFlash { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgPhoto { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView topBar { get; set; }

        [Action ("btnBack_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnBack_TouchUpInside (UIKit.UIButton sender);
        [Action ("btnTakePhoto_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnTakePhoto_TouchUpInside (UIKit.UIButton sender);
        [Action ("btnToggleFlash_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnToggleFlash_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (bottomBar != null) {
                bottomBar.Dispose ();
                bottomBar = null;
            }

            if (btnBack != null) {
                btnBack.Dispose ();
                btnBack = null;
            }

            if (btnTakePhoto != null) {
                btnTakePhoto.Dispose ();
                btnTakePhoto = null;
            }

            if (btnToggleFlash != null) {
                btnToggleFlash.Dispose ();
                btnToggleFlash = null;
            }

            if (imgPhoto != null) {
                imgPhoto.Dispose ();
                imgPhoto = null;
            }

            if (topBar != null) {
                topBar.Dispose ();
                topBar = null;
            }
        }
    }
}