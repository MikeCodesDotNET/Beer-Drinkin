// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace InAppPurchaseTest
{
	[Register ("PurchaseTableCell")]
	partial class PurchaseTableCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel AvailableQuantity { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ItemDescription { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView ItemImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ItemTitle { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UpdateButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AvailableQuantity != null) {
				AvailableQuantity.Dispose ();
				AvailableQuantity = null;
			}

			if (ItemDescription != null) {
				ItemDescription.Dispose ();
				ItemDescription = null;
			}

			if (ItemImage != null) {
				ItemImage.Dispose ();
				ItemImage = null;
			}

			if (ItemTitle != null) {
				ItemTitle.Dispose ();
				ItemTitle = null;
			}

			if (UpdateButton != null) {
				UpdateButton.Dispose ();
				UpdateButton = null;
			}
		}
	}
}
