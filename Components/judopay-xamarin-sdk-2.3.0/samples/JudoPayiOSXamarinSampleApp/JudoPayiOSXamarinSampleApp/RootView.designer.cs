// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace JudoPayiOSXamarinSampleApp
{
	[Register ("RootView")]
	partial class RootView
	{
		[Outlet]
		UIKit.UITableView ButtonTable { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint TableHeightConstrant { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TableHeightConstrant != null) {
				TableHeightConstrant.Dispose ();
				TableHeightConstrant = null;
			}

			if (ButtonTable != null) {
				ButtonTable.Dispose ();
				ButtonTable = null;
			}
		}
	}
}
