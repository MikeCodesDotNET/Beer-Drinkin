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
	[Register ("WelcomeMapViewController")]
	partial class WelcomeMapViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnOK { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSkip { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgMap { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblDescription { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTitle { get; set; }

		[Action ("BtnOK_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnOK_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnOK != null) {
				btnOK.Dispose ();
				btnOK = null;
			}
			if (btnSkip != null) {
				btnSkip.Dispose ();
				btnSkip = null;
			}
			if (imgMap != null) {
				imgMap.Dispose ();
				imgMap = null;
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
