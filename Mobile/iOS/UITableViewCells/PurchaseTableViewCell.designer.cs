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
	[Register ("PurchaseTableViewCell")]
	partial class PurchaseTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnApplePay { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnBuyNow { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblQuantity { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTotal { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIStepper stepper { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnApplePay != null) {
				btnApplePay.Dispose ();
				btnApplePay = null;
			}
			if (btnBuyNow != null) {
				btnBuyNow.Dispose ();
				btnBuyNow = null;
			}
			if (lblQuantity != null) {
				lblQuantity.Dispose ();
				lblQuantity = null;
			}
			if (lblTotal != null) {
				lblTotal.Dispose ();
				lblTotal = null;
			}
			if (stepper != null) {
				stepper.Dispose ();
				stepper = null;
			}
		}
	}
}
