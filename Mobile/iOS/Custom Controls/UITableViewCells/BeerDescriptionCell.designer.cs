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
	[Register ("BeerDescriptionCell")]
	partial class BeerDescriptionCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView divider { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView tbxDescription { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (divider != null) {
				divider.Dispose ();
				divider = null;
			}
			if (tbxDescription != null) {
				tbxDescription.Dispose ();
				tbxDescription = null;
			}
		}
	}
}
