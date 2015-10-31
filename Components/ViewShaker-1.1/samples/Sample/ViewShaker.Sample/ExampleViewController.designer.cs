// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ViewShaker.Example
{
	[Register ("ExampleViewController")]
	partial class ExampleViewController
	{
		[Outlet]
		UIKit.UIButton btnShake { get; set; }

		[Outlet]
		UIKit.UIView viewToShake { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (viewToShake != null) {
				viewToShake.Dispose ();
				viewToShake = null;
			}

			if (btnShake != null) {
				btnShake.Dispose ();
				btnShake = null;
			}
		}
	}
}
