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
    [Register ("InAppPurchaseViewController")]
    partial class InAppPurchaseViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnClose { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnPay { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnRestore { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgBeerLogo { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgHeart { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAlreadyPaid { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTitle { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView stvwDarkTheme { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView stvwEndlessLove { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView stvwUnlockBarcode { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView stvwUnlockOcr { get; set; }

        [Action ("BtnClose_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnClose_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnClose != null) {
                btnClose.Dispose ();
                btnClose = null;
            }

            if (btnPay != null) {
                btnPay.Dispose ();
                btnPay = null;
            }

            if (btnRestore != null) {
                btnRestore.Dispose ();
                btnRestore = null;
            }

            if (imgBeerLogo != null) {
                imgBeerLogo.Dispose ();
                imgBeerLogo = null;
            }

            if (imgHeart != null) {
                imgHeart.Dispose ();
                imgHeart = null;
            }

            if (lblAlreadyPaid != null) {
                lblAlreadyPaid.Dispose ();
                lblAlreadyPaid = null;
            }

            if (lblTitle != null) {
                lblTitle.Dispose ();
                lblTitle = null;
            }

            if (stvwDarkTheme != null) {
                stvwDarkTheme.Dispose ();
                stvwDarkTheme = null;
            }

            if (stvwEndlessLove != null) {
                stvwEndlessLove.Dispose ();
                stvwEndlessLove = null;
            }

            if (stvwUnlockBarcode != null) {
                stvwUnlockBarcode.Dispose ();
                stvwUnlockBarcode = null;
            }

            if (stvwUnlockOcr != null) {
                stvwUnlockOcr.Dispose ();
                stvwUnlockOcr = null;
            }
        }
    }
}