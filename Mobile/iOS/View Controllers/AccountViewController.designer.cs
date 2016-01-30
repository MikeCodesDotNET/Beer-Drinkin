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
    [Register ("AccountViewController")]
    partial class AccountViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnSettings { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgAvatar { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblBeersCount { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPhotoCount { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblRatingCount { get; set; }

        [Action ("BtnSettings_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSettings_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnSettings != null) {
                btnSettings.Dispose ();
                btnSettings = null;
            }

            if (imgAvatar != null) {
                imgAvatar.Dispose ();
                imgAvatar = null;
            }

            if (lblBeersCount != null) {
                lblBeersCount.Dispose ();
                lblBeersCount = null;
            }

            if (lblPhotoCount != null) {
                lblPhotoCount.Dispose ();
                lblPhotoCount = null;
            }

            if (lblRatingCount != null) {
                lblRatingCount.Dispose ();
                lblRatingCount = null;
            }
        }
    }
}