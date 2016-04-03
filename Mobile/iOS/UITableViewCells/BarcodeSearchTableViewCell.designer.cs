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
    [Register ("BarcodeSearchTableViewCell")]
    partial class BarcodeSearchTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnScan { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAvailableForPurchase { get; set; }

        [Action ("BtnScan_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnScan_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnScan != null) {
                btnScan.Dispose ();
                btnScan = null;
            }

            if (lblAvailableForPurchase != null) {
                lblAvailableForPurchase.Dispose ();
                lblAvailableForPurchase = null;
            }
        }
    }
}