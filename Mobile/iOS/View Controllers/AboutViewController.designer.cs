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
	[Register ("AboutViewController")]
	partial class AboutViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnTermsAndConditions { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell cellOnFacebook { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgAppIcon { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblMadeInGuildford { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblVersion { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnTermsAndConditions != null) {
				btnTermsAndConditions.Dispose ();
				btnTermsAndConditions = null;
			}
			if (cellOnFacebook != null) {
				cellOnFacebook.Dispose ();
				cellOnFacebook = null;
			}
			if (imgAppIcon != null) {
				imgAppIcon.Dispose ();
				imgAppIcon = null;
			}
			if (lblMadeInGuildford != null) {
				lblMadeInGuildford.Dispose ();
				lblMadeInGuildford = null;
			}
			if (lblVersion != null) {
				lblVersion.Dispose ();
				lblVersion = null;
			}
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}
}
