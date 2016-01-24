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
	[Register ("SendFeedbackViewController")]
	partial class SendFeedbackViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView beerSelectionRatingPlaceholder { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem btnBack { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem btnSend { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView tbxFeedback { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView userInterfaceRatingPlaceholder { get; set; }

		[Action ("btnBack_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnBack_Activated (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (beerSelectionRatingPlaceholder != null) {
				beerSelectionRatingPlaceholder.Dispose ();
				beerSelectionRatingPlaceholder = null;
			}
			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}
			if (btnSend != null) {
				btnSend.Dispose ();
				btnSend = null;
			}
			if (tbxFeedback != null) {
				tbxFeedback.Dispose ();
				tbxFeedback = null;
			}
			if (userInterfaceRatingPlaceholder != null) {
				userInterfaceRatingPlaceholder.Dispose ();
				userInterfaceRatingPlaceholder = null;
			}
		}
	}
}
