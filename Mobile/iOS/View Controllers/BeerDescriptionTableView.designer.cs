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
		UIButton btnCheckIn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgHeaderView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnCheckIn != null) {
				btnCheckIn.Dispose ();
				btnCheckIn = null;
			}
			if (imgHeaderView != null) {
				imgHeaderView.Dispose ();
				imgHeaderView = null;
			}
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}
}
