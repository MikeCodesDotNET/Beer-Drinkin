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
	[Register ("BarcodeSearchTableViewCell")]
	partial class BarcodeSearchTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnClear { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnScan { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblBarcodeNumber { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnClear != null) {
				btnClear.Dispose ();
				btnClear = null;
			}
			if (btnScan != null) {
				btnScan.Dispose ();
				btnScan = null;
			}
			if (lblBarcodeNumber != null) {
				lblBarcodeNumber.Dispose ();
				lblBarcodeNumber = null;
			}
		}
	}
}
