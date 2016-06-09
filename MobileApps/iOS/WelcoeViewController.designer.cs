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
	[Register ("WelcoeViewController")]
	partial class WelcoeViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnConnectWithFacebook { get; set; }

		[Action ("BtnConnectWithFacebook_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnConnectWithFacebook_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnConnectWithFacebook != null) {
				btnConnectWithFacebook.Dispose ();
				btnConnectWithFacebook = null;
			}
		}
	}
}
