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
    [Register ("SearchBeerTableViewCell")]
    partial class SearchBeerTableViewCell
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
        UIKit.UILabel lblStyle { get; set; }

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

            if (lblStyle != null) {
                lblStyle.Dispose ();
                lblStyle = null;
            }
        }
    }
}