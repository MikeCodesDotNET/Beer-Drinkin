// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using UIKit;

namespace BeerDrinkin.iOS
{
    [Register ("ProfileHeaderView")]
    partial class ProfileHeaderView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView backgroundImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnMore { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSettings { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel followingLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel follwersLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel locationLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel nameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView profileImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView whiteView { get; set; }

        [Action ("BtnMore_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnMore_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnSettings_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSettings_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (backgroundImage != null) {
                backgroundImage.Dispose ();
                backgroundImage = null;
            }

            if (btnMore != null) {
                btnMore.Dispose ();
                btnMore = null;
            }

            if (btnSettings != null) {
                btnSettings.Dispose ();
                btnSettings = null;
            }

            if (followingLabel != null) {
                followingLabel.Dispose ();
                followingLabel = null;
            }

            if (follwersLabel != null) {
                follwersLabel.Dispose ();
                follwersLabel = null;
            }

            if (locationLabel != null) {
                locationLabel.Dispose ();
                locationLabel = null;
            }

            if (nameLabel != null) {
                nameLabel.Dispose ();
                nameLabel = null;
            }

            if (profileImage != null) {
                profileImage.Dispose ();
                profileImage = null;
            }

            if (whiteView != null) {
                whiteView.Dispose ();
                whiteView = null;
            }
        }
    }
}