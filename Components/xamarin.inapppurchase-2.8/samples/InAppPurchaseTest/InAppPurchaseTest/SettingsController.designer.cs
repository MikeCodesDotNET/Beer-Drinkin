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
	[Register ("SettingsController")]
	partial class SettingsController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton AddButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView AddDescription { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel AddLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField AddProduct { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ResetButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch ShuffleSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITapGestureRecognizer ViewTouched { get; set; }
		
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
