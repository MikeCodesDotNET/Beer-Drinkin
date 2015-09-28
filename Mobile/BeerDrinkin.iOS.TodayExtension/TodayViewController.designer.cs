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

namespace BeerDrinkin.iOS.TodayExtension
{
	[Register ("TodayViewController")]
	partial class TodayViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblBeerCount { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblBeers { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTodayYouve { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblBeerCount != null) {
				lblBeerCount.Dispose ();
				lblBeerCount = null;
			}
			if (lblBeers != null) {
				lblBeers.Dispose ();
				lblBeers = null;
			}
			if (lblTodayYouve != null) {
				lblTodayYouve.Dispose ();
				lblTodayYouve = null;
			}
		}
	}
}
