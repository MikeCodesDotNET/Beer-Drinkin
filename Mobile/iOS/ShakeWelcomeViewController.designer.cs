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
	[Register ("ShakeWelcomeViewController")]
	partial class ShakeWelcomeViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnGotIt { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgDevice { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblDescription { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTitle { get; set; }

		[Action ("BtnGotIt_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnGotIt_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnGotIt != null) {
				btnGotIt.Dispose ();
				btnGotIt = null;
			}
			if (imgDevice != null) {
				imgDevice.Dispose ();
				imgDevice = null;
			}
			if (lblDescription != null) {
				lblDescription.Dispose ();
				lblDescription = null;
			}
			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}
		}
	}
}
