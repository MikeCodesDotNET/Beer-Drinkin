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
	[Register ("ShakeWelcomeViewController")]
	partial class ShakeWelcomeViewController
	{
		[Outlet]
		UIKit.UIButton btnGotIt { get; set; }

		[Outlet]
		UIKit.UIImageView imgDevice { get; set; }

		[Outlet]
		UIKit.UILabel lblDescription { get; set; }

		[Outlet]
		UIKit.UILabel lblTitle { get; set; }

		[Action ("BtnGotIt_TouchUpInside:")]
		partial void BtnGotIt_TouchUpInside (UIKit.UIButton sender);
		
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
