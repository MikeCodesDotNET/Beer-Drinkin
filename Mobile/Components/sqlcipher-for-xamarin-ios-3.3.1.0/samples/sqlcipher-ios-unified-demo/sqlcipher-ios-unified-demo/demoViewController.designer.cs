// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace demo
{
	[Register ("demoViewController")]
	partial class demoViewController
	{
		[Outlet]
		UIKit.UIButton mainButton { get; set; }

		[Outlet]
		UIKit.UIButton clearButton { get; set; }

		[Outlet]
		UIKit.UITextView outputDisplay { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (mainButton != null) {
				mainButton.Dispose ();
				mainButton = null;
			}

			if (clearButton != null) {
				clearButton.Dispose ();
				clearButton = null;
			}

			if (outputDisplay != null) {
				outputDisplay.Dispose ();
				outputDisplay = null;
			}
		}
	}
}
