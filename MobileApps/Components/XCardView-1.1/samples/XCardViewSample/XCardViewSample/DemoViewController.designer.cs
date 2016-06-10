// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using Softweb.Xamarin.Controls.iOS;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XCardViewSample
{
	[Register ("DemoViewController")]
	partial class DemoViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnReload { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSwipeLeft { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSwipeRight { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		Softweb.Xamarin.Controls.iOS.CardView DemoCardView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnReload != null) {
				btnReload.Dispose ();
				btnReload = null;
			}
			if (btnSwipeLeft != null) {
				btnSwipeLeft.Dispose ();
				btnSwipeLeft = null;
			}
			if (btnSwipeRight != null) {
				btnSwipeRight.Dispose ();
				btnSwipeRight = null;
			}
			if (DemoCardView != null) {
				DemoCardView.Dispose ();
				DemoCardView = null;
			}
		}
	}
}
