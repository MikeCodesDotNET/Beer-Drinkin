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
            var sfViewController = new SafariServices.SFSafariViewController(new NSUrl(url));
            sfViewController.View.TintColor = BeerDrinkin.Helpers.Colours.Blue.ToNative();
            sfViewController.View.BackgroundColor = BeerDrinkin.Helpers.Colours.Blue.ToNative();           


            PresentViewControllerAsync(sfViewController, true);
        }
    }
}