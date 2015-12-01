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
	[Register ("SearchViewController")]
	partial class SearchViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem btnSettings { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		SearchBar searchBar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tableView { get; set; }

		[Action ("BtnSettings_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnSettings_Activated (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnSettings != null) {
				btnSettings.Dispose ();
				btnSettings = null;
			}
			if (searchBar != null) {
				searchBar.Dispose ();
				searchBar = null;
			}
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}
}
