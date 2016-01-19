// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace BeerDrinkin.iOS
{
    [Register ("BeerDescriptionTableView")]
    partial class BeerDescriptionTableView
    {
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
            if (subTotalLabel != null) {
                subTotalLabel.Dispose ();
                subTotalLabel = null;
            }

            if (btnCheckIn != null) {
                btnCheckIn.Dispose ();
                btnCheckIn = null;
            }

            if (btnShare != null) {
                btnShare.Dispose ();
                btnShare = null;
            }

            if (BuyNowButton != null) {
                BuyNowButton.Dispose ();
                BuyNowButton = null;
            }

            if (imgHeaderView != null) {
                imgHeaderView.Dispose ();
                imgHeaderView = null;
            }

            if (subTotalButton != null) {
                subTotalButton.Dispose ();
                subTotalButton = null;
            }

            if (tableView != null) {
                tableView.Dispose ();
                tableView = null;
            }
        }
    }
}
