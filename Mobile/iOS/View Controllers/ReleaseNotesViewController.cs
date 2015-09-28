using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.IO;

namespace BeerDrinkin.iOS
{
	partial class ReleaseNotesViewController : UIViewController
	{
		public ReleaseNotesViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            string localHtmlUrl = Path.Combine(NSBundle.MainBundle.BundlePath, "ReleaseNotes.html");
            webView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
            webView.ScalesPageToFit = false;
        }
	}
}
