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
    [Register ("DiscoverUsersTableViewCell")]
    partial class DiscoverUsersTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView avatar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel location { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel name { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (avatar != null) {
                avatar.Dispose ();
                avatar = null;
            }

            if (location != null) {
                location.Dispose ();
                location = null;
            }

            if (name != null) {
                name.Dispose ();
                name = null;
            }
        }
    }
}