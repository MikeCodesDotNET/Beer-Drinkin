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
	[Register ("WelcomeViewController")]
	partial class WelcomeViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnCancel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnConnectWithFacebook { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnConnectWithGoogle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblAmazingFeatures { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblPromise { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTitle { get; set; }

		[Action ("BtnCancel_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnCancel_TouchUpInside (UIButton sender);

		[Action ("BtnConnectWithFacebook_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnConnectWithFacebook_TouchUpInside (UIButton sender);

		[Action ("BtnConnectWithGoogle_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnConnectWithGoogle_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}
			if (btnConnectWithFacebook != null) {
				btnConnectWithFacebook.Dispose ();
				btnConnectWithFacebook = null;
			}
			if (btnConnectWithGoogle != null) {
				btnConnectWithGoogle.Dispose ();
				btnConnectWithGoogle = null;
			}
			if (lblAmazingFeatures != null) {
				lblAmazingFeatures.Dispose ();
				lblAmazingFeatures = null;
			}
			if (lblPromise != null) {
				lblPromise.Dispose ();
				lblPromise = null;
			}
			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}
		}
	}
}
