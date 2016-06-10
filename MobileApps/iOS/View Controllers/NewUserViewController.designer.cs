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
	[Register ("NewUserViewController")]
	partial class NewUserViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnCancel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnOK { get; set; }

		[Action ("BtnCancel_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnCancel_TouchUpInside (UIButton sender);

		[Action ("BtnOK_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnOK_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}
			if (btnOK != null) {
				btnOK.Dispose ();
				btnOK = null;
			}
		}
	}
}
