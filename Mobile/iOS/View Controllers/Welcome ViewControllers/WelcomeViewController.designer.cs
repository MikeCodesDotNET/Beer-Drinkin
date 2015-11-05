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
		UIButton btnConnectWithFacebook { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnConnectWithGoogle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgLogo { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblPromise { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTitle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIScrollView scrollView { get; set; }

		[Action ("BtnConnectWithFacebook_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnConnectWithFacebook_TouchUpInside (UIButton sender);

		[Action ("BtnConnectWithGoogle_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnConnectWithGoogle_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnConnectWithFacebook != null) {
				btnConnectWithFacebook.Dispose ();
				btnConnectWithFacebook = null;
			}
			if (btnConnectWithGoogle != null) {
				btnConnectWithGoogle.Dispose ();
				btnConnectWithGoogle = null;
			}
			if (imgLogo != null) {
				imgLogo.Dispose ();
				imgLogo = null;
			}
			if (lblPromise != null) {
				lblPromise.Dispose ();
				lblPromise = null;
			}
			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}
			if (scrollView != null) {
				scrollView.Dispose ();
				scrollView = null;
			}
		}
	}
}
