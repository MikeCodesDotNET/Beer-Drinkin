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
		UIButton btnAdd { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnPay { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnRemove { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblPrice { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblPurchase { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblQuantity { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTotal { get; set; }

		[Action ("BtnAdd_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnAdd_TouchUpInside (UIButton sender);

		[Action ("BtnPay_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnPay_TouchUpInside (UIButton sender);

		[Action ("BtnRemove_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnRemove_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnAdd != null) {
				btnAdd.Dispose ();
				btnAdd = null;
			}
			if (btnPay != null) {
				btnPay.Dispose ();
				btnPay = null;
			}
			if (btnRemove != null) {
				btnRemove.Dispose ();
				btnRemove = null;
			}
			if (lblPrice != null) {
				lblPrice.Dispose ();
				lblPrice = null;
			}
			if (lblPurchase != null) {
				lblPurchase.Dispose ();
				lblPurchase = null;
			}
			if (lblQuantity != null) {
				lblQuantity.Dispose ();
				lblQuantity = null;
			}
			if (lblTotal != null) {
				lblTotal.Dispose ();
				lblTotal = null;
			}
		}
	}
}
