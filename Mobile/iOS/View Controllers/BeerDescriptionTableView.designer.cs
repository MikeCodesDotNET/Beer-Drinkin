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
    [Register ("BeerDescriptionTableView")]
    partial class BeerDescriptionTableView
    {
        [Outlet]
        UIKit.UIButton applePayButton { get; set; }

        [Outlet]
        UIKit.UIButton btnCheckIn { get; set; }

        [Outlet]
        UIKit.UIBarButtonItem btnShare { get; set; }

        [Outlet]
        UIKit.UIButton BuyNowButton { get; set; }

        [Outlet]
        UIKit.UIImageView imgHeaderView { get; set; }

        [Outlet]
        UIKit.UIButton subTotalButton { get; set; }

        [Outlet]
        UIKit.UILabel subTotalLabel { get; set; }

        [Outlet]
        UIKit.UITableView tableView { get; set; }

        [Action ("BtnCheckIn_TouchUpInside:")]
        partial void BtnCheckIn_TouchUpInside (UIKit.UIButton sender);

        [Action ("btnShare_Activated:")]
        partial void btnShare_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnCheckIn != null) {
                btnCheckIn.Dispose ();
                btnCheckIn = null;
            }

            if (imgHeaderView != null) {
                imgHeaderView.Dispose ();
                imgHeaderView = null;
            }

            if (tableView != null) {
                tableView.Dispose ();
                tableView = null;
            }
        }
    }
}