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
    [Register ("InAppPurchaseSearchTableViewCell")]
    partial class InAppPurchaseSearchTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSnapAPhoto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgCamera { get; set; }

        [Action ("BtnSnapAPhoto_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSnapAPhoto_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnSnapAPhoto != null) {
                btnSnapAPhoto.Dispose ();
                btnSnapAPhoto = null;
            }

            if (imgCamera != null) {
                imgCamera.Dispose ();
                imgCamera = null;
            }
        }
    }
}