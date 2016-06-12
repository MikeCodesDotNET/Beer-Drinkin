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
    [Register ("SocialAuthViewController")]
    partial class SocialAuthViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnConnectWithFacebook { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAmazingFeatures { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPromise { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTitle { get; set; }
        [Action ("BtnConnectWithFacebook_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnConnectWithFacebook_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnConnectWithFacebook != null) {
                btnConnectWithFacebook.Dispose ();
                btnConnectWithFacebook = null;
            }

            if (lblAmazingFeatures != null) {
                lblAmazingFeatures.Dispose ();
                lblAmazingFeatures = null;
            }

            if (lblPromise != null) {
                lblPromise.Dispose ();
                lblPromise = null;
            }

            if (lblTitle != null) {
                lblTitle.Dispose ();
                lblTitle = null;
            }
        }
    }
}