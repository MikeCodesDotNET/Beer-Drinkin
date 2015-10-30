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
	[Register ("BarCodeTableViewCell")]
	partial class BarCodeTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnAddBarcode { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblBarcodeNumber { get; set; }

		[Action ("BtnAddBarcode_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnAddBarcode_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnAddBarcode != null) {
				btnAddBarcode.Dispose ();
				btnAddBarcode = null;
			}
			if (lblBarcodeNumber != null) {
				lblBarcodeNumber.Dispose ();
				lblBarcodeNumber = null;
			}
		}
	}
}
