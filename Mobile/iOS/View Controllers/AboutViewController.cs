using System;
using UIKit;
using Xamarin;
using System.Collections.Generic;

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
    }
}