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
	[Register ("TinderViewController")]
	partial class TinderViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnFinished { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgBeer1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgBeer2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgBeer3 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgBeer4 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblBeersCount { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView tinderView { get; set; }

		[Action ("BtnFinished_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnFinished_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnFinished != null) {
				btnFinished.Dispose ();
				btnFinished = null;
			}
			if (imgBeer1 != null) {
				imgBeer1.Dispose ();
				imgBeer1 = null;
			}
			if (imgBeer2 != null) {
				imgBeer2.Dispose ();
				imgBeer2 = null;
			}
			if (imgBeer3 != null) {
				imgBeer3.Dispose ();
				imgBeer3 = null;
			}
			if (imgBeer4 != null) {
				imgBeer4.Dispose ();
				imgBeer4 = null;
			}
			if (lblBeersCount != null) {
				lblBeersCount.Dispose ();
				lblBeersCount = null;
			}
			if (tinderView != null) {
				tinderView.Dispose ();
				tinderView = null;
			}
		}
	}
}
