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
	[Register ("BeerDescriptionTableView")]
	partial class BeerDescriptionTableView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem btnShare { get; set; }

		[Action ("btnShare_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnShare_Activated (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnShare != null) {
				btnShare.Dispose ();
				btnShare = null;
			}
		}
	}
}
