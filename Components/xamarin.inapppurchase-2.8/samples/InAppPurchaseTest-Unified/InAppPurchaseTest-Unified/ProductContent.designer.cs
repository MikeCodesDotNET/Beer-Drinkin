// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace InAppPurchaseTest
{
	[Register ("ProductContent")]
	partial class ProductContent
	{
		[Outlet]
		UIKit.UIBarButtonItem BackButton { get; set; }

		[Outlet]
		UIKit.UILabel ContentVersion { get; set; }

		[Outlet]
		UIKit.UIImageView HeaderImage { get; set; }

		[Outlet]
		UIKit.UINavigationItem TitleBar { get; set; }

		[Outlet]
		UIKit.UIWebView WebView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BackButton != null) {
				BackButton.Dispose ();
				BackButton = null;
			}

			if (HeaderImage != null) {
				HeaderImage.Dispose ();
				HeaderImage = null;
			}

			if (TitleBar != null) {
				TitleBar.Dispose ();
				TitleBar = null;
			}

			if (WebView != null) {
				WebView.Dispose ();
				WebView = null;
			}

			if (ContentVersion != null) {
				ContentVersion.Dispose ();
				ContentVersion = null;
			}
		}
	}
}
