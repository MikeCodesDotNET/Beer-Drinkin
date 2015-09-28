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
		UIButton btnFacebookConnect { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblPromise { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTitle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIScrollView scrollView { get; set; }

		[Action ("BtnFacebookConnect_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnFacebookConnect_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnFacebookConnect != null) {
				btnFacebookConnect.Dispose ();
				btnFacebookConnect = null;
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
