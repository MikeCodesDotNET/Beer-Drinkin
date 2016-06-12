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
    [Register ("SettingsViewController")]
    partial class SettingsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnClose { get; set; }

        [Action ("btnClose_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnClose_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnClose != null) {
                btnClose.Dispose ();
                btnClose = null;
            }
        }
    }
}