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
    [Register ("TrendingBeerCell")]
    partial class TrendingBeerCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel brewery { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel name { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (brewery != null) {
                brewery.Dispose ();
                brewery = null;
            }

            if (name != null) {
                name.Dispose ();
                name = null;
            }
        }
    }
}