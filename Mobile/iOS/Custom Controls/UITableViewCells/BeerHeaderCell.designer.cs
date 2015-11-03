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
	[Register ("BeerHeaderCell")]
	partial class BeerHeaderCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView divider { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblAbv { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblBrewery { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblConsumed { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblConsumedTitle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblRating { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblRatingTitle { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (divider != null) {
				divider.Dispose ();
				divider = null;
			}
			if (lblAbv != null) {
				lblAbv.Dispose ();
				lblAbv = null;
			}
			if (lblBrewery != null) {
				lblBrewery.Dispose ();
				lblBrewery = null;
			}
			if (lblConsumed != null) {
				lblConsumed.Dispose ();
				lblConsumed = null;
			}
			if (lblConsumedTitle != null) {
				lblConsumedTitle.Dispose ();
				lblConsumedTitle = null;
			}
			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}
			if (lblRating != null) {
				lblRating.Dispose ();
				lblRating = null;
			}
			if (lblRatingTitle != null) {
				lblRatingTitle.Dispose ();
				lblRatingTitle = null;
			}
		}
	}
}
