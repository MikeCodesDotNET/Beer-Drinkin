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
    [Register ("MyBeersTableViewCell")]
    partial class MyBeersTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgLabel { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblBrewery { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblName { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNumberOfServings { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView sideColor { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgLabel != null) {
                imgLabel.Dispose ();
                imgLabel = null;
            }

            if (lblBrewery != null) {
                lblBrewery.Dispose ();
                lblBrewery = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (lblNumberOfServings != null) {
                lblNumberOfServings.Dispose ();
                lblNumberOfServings = null;
            }

            if (sideColor != null) {
                sideColor.Dispose ();
                sideColor = null;
            }
        }
    }
}