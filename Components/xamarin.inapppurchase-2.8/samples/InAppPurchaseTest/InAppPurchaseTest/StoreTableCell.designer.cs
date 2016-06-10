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
	[Register ("StoreTableCell")]
	partial class StoreTableCell
	{
		[Outlet]
		MonoTouch.UIKit.UIButton BuyButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIProgressView DownloadProgress { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ItemDescription { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView ItemImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ItemPrice { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ItemTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BuyButton != null) {
				BuyButton.Dispose ();
				BuyButton = null;
			}

			if (ItemDescription != null) {
				ItemDescription.Dispose ();
				ItemDescription = null;
			}

			if (ItemImage != null) {
				ItemImage.Dispose ();
				ItemImage = null;
			}

			if (ItemPrice != null) {
				ItemPrice.Dispose ();
				ItemPrice = null;
			}

			if (ItemTitle != null) {
				ItemTitle.Dispose ();
				ItemTitle = null;
			}

			if (DownloadProgress != null) {
				DownloadProgress.Dispose ();
				DownloadProgress = null;
			}
		}
	}
}
