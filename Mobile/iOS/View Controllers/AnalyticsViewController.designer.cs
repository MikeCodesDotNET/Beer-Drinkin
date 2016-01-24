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
	[Register ("AnalyticsViewController")]
	partial class AnalyticsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgCriticalBugIcon { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblCriticalBugs { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblCriticalBugsDescription { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		AMViralSwitch.ViralSwitch swtCriticalBugs { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		AMViralSwitch.ViralSwitch swtResponsiveness { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (imgCriticalBugIcon != null) {
				imgCriticalBugIcon.Dispose ();
				imgCriticalBugIcon = null;
			}
			if (lblCriticalBugs != null) {
				lblCriticalBugs.Dispose ();
				lblCriticalBugs = null;
			}
			if (lblCriticalBugsDescription != null) {
				lblCriticalBugsDescription.Dispose ();
				lblCriticalBugsDescription = null;
			}
			if (swtCriticalBugs != null) {
				swtCriticalBugs.Dispose ();
				swtCriticalBugs = null;
			}
			if (swtResponsiveness != null) {
				swtResponsiveness.Dispose ();
				swtResponsiveness = null;
			}
		}
	}
}
