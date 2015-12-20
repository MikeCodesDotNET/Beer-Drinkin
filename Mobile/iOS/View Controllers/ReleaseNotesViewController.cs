using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.IO;
using Splat;

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

            NavigationItem.BackBarButtonItem.SetTitleTextAttributes(new UITextAttributes
                {
                    Font = UIFont.FromName("Avenir-Book", 14f),
                    TextColor = UIColor.White
                }, UIControlState.Normal); 

            string localHtmlUrl = Path.Combine(NSBundle.MainBundle.BundlePath, "ReleaseNotes.html");
            webView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
            webView.ScalesPageToFit = false;
        }
	}
}
