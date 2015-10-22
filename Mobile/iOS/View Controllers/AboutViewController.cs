using System;
using UIKit;
using Xamarin;
using System.Collections.Generic;
using Foundation;

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

        async partial void btnBack_Activated(UIBarButtonItem sender)
        {
            NavigationController.PopViewController(true);
        }

        [Export("tableView:didSelectRowAtIndexPath:")]
        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Section == 0 && indexPath.Row == 0)
            {
                //Xamarin
                UIApplication.SharedApplication.OpenUrl(new NSUrl("http://www.xamarin.com/"));
            }

            if (indexPath.Section == 1 && indexPath.Row == 0)
            {
                //Facebook
                UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.facebook.com/beerdrinkinapp"));
            }

            if (indexPath.Section == 1 && indexPath.Row == 1)
            {
                //Twitter
                UIApplication.SharedApplication.OpenUrl(new NSUrl("http://twitter.com/BeerDrinkinApp"));
            }


        }
    }
}