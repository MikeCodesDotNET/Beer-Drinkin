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
	[Register ("CheckInTableViewCell")]
	partial class CheckInTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnCheckIn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnRateMinus { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnRatePlus { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSnapAPhoto { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblRating { get; set; }

		[Action ("btnCheckIn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnCheckIn_TouchUpInside (UIButton sender);

		[Action ("btnRateMinus_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnRateMinus_TouchUpInside (UIButton sender);

		[Action ("btnRatePlus_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnRatePlus_TouchUpInside (UIButton sender);

		[Action ("btnSnapAPhoto_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnSnapAPhoto_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnCheckIn != null) {
				btnCheckIn.Dispose ();
				btnCheckIn = null;
			}
			if (btnRateMinus != null) {
				btnRateMinus.Dispose ();
				btnRateMinus = null;
			}
			if (btnRatePlus != null) {
				btnRatePlus.Dispose ();
				btnRatePlus = null;
			}
			if (btnSnapAPhoto != null) {
				btnSnapAPhoto.Dispose ();
				btnSnapAPhoto = null;
			}
			if (lblRating != null) {
				lblRating.Dispose ();
				lblRating = null;
			}
		}
	}
}
