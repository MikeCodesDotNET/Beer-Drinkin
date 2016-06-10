using System;
using UIKit;
using Xamarin;
using System.Collections.Generic;
using Foundation;
using SafariServices;
using Splat;

namespace BeerDrinkin.iOS
{
    public partial class AboutViewController : UITableViewController
    {
        public AboutViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if(BeerDrinkin.Core.Helpers.Settings.UserTrackingEnabled)
            {
                Insights.Track("Loaded AboutView", "ViewController", "AboutViewController");
            }

			btnClose.SetTitleTextAttributes(new UITextAttributes
			{
				Font = UIFont.FromName("Avenir-Book", 14f),
				TextColor = UIColor.White
			}, UIControlState.Normal);

			btnClose.Clicked += delegate {
				this.NavigationController.PopViewController(true);
			};
        }

        /*
        partial void btnBack_Activated(UIBarButtonItem sender)
        {
            NavigationController.PopViewController(true);
        }
        */

        [Export("tableView:didSelectRowAtIndexPath:")]
        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Section == 0 && indexPath.Row == 0)
            {
                //Xamarin    
                OpenUrl("http://www.xamarin.com/");
            }


			if (indexPath.Section == 0 && indexPath.Row == 1)
			{
				var sfViewController = new SFSafariViewController(new NSUrl("ReleaseNotes.md"), true);
				PresentViewControllerAsync(sfViewController, true);
			}

            if (indexPath.Section == 1 && indexPath.Row == 0)
            {
                //Facebook
                OpenUrl("https://www.facebook.com/beerdrinkinapp");
            }

            if (indexPath.Section == 1 && indexPath.Row == 1)
            {
                //Twitter
                OpenUrl("http://twitter.com/BeerDrinkinApp");
            }
        }

        void OpenUrl(string url)
        {
            var sfViewController = new SFSafariViewController(new NSUrl(url), true);
            sfViewController.View.TintColor = BeerDrinkin.Helpers.Colours.Blue.ToNative();
            sfViewController.View.BackgroundColor = BeerDrinkin.Helpers.Colours.Blue.ToNative();  
            PresentViewControllerAsync(sfViewController, true);
        }
    }
}