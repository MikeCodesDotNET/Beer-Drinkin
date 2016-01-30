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
    [Register ("PurchaseTableViewCell")]
    partial class PurchaseTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDistributorName { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPrice { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTagLine { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblDistributorName != null) {
                lblDistributorName.Dispose ();
                lblDistributorName = null;
            }

            if (lblPrice != null) {
                lblPrice.Dispose ();
                lblPrice = null;
            }

            if (lblTagLine != null) {
                lblTagLine.Dispose ();
                lblTagLine = null;
            }
        }
    }
}