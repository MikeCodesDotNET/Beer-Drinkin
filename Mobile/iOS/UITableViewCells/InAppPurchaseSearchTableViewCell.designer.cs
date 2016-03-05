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
        UIKit.UIButton btnLearnMore { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgLockIcon { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAvailableForPurchase { get; set; }

        [Action ("BtnLearnMore_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnLearnMore_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnLearnMore != null) {
                btnLearnMore.Dispose ();
                btnLearnMore = null;
            }

            if (imgLockIcon != null) {
                imgLockIcon.Dispose ();
                imgLockIcon = null;
            }

            if (lblAvailableForPurchase != null) {
                lblAvailableForPurchase.Dispose ();
                lblAvailableForPurchase = null;
            }
        }
    }
}