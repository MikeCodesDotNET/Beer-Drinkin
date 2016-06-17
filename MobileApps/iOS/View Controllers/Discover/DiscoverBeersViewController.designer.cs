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
    [Register ("DiscoverBeersViewController")]
    partial class DiscoverBeersViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        BeerDrinkin.iOS.CustomControls.DiscoverCameraButton photoImportButton { get; set; }

        [Action ("PhotoImportButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PhotoImportButton_TouchUpInside (BeerDrinkin.iOS.CustomControls.DiscoverCameraButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (photoImportButton != null) {
                photoImportButton.Dispose ();
                photoImportButton = null;
            }
        }
    }
}