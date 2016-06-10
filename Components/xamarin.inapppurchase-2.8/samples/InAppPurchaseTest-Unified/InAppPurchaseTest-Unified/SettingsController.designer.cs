// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace InAppPurchaseTest
{
	[Register ("SettingsController")]
	partial class SettingsController
	{
		[Outlet]
		UIKit.UIButton AddButton { get; set; }

		[Outlet]
		UIKit.UITextView AddDescription { get; set; }

		[Outlet]
		UIKit.UILabel AddLabel { get; set; }

		[Outlet]
		UIKit.UITextField AddProduct { get; set; }

		[Outlet]
		UIKit.UIButton ResetButton { get; set; }

		[Outlet]
		UIKit.UISwitch ShuffleSwitch { get; set; }

		[Outlet]
		UIKit.UITapGestureRecognizer ViewTouched { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AddButton != null) {
				AddButton.Dispose ();
				AddButton = null;
			}

			if (AddProduct != null) {
				AddProduct.Dispose ();
				AddProduct = null;
			}

			if (ResetButton != null) {
				ResetButton.Dispose ();
				ResetButton = null;
			}

			if (ShuffleSwitch != null) {
				ShuffleSwitch.Dispose ();
				ShuffleSwitch = null;
			}

			if (ViewTouched != null) {
				ViewTouched.Dispose ();
				ViewTouched = null;
			}

			if (AddLabel != null) {
				AddLabel.Dispose ();
				AddLabel = null;
			}

			if (AddDescription != null) {
				AddDescription.Dispose ();
				AddDescription = null;
			}
		}
	}
}
