using System;
using BeerDrinkin.Service;
using Foundation;
using UIKit;
using Colour = BeerDrinkin.Helpers.Colours;
using Splat;
using Xamarin;

namespace BeerDrinkin.iOS
{
    partial class SettingsViewController : UITableViewController
    {
        public SettingsViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnClose.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Avenir-Book", 14f),
                TextColor = Colour.White.ToNative()
            }, UIControlState.Normal);

            TableView.WeakDelegate = this;
        }

        async partial void btnClose_Activated(UIBarButtonItem sender)
        {
            await DismissViewControllerAsync(true);
        }

        //TODO FIX THIS!
        [Export("tableView:didSelectRowAtIndexPath:")]
        async public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Section == 1 && indexPath.Row == 1)
            {
                var signInView = UIApplication.SharedApplication.KeyWindow.RootViewController.ChildViewControllers[1];
                var tabView = signInView.ChildViewControllers[0];

                if (tabView != null)
                {
                    tabView.DismissViewController(true, null);
                }
            }

            if( indexPath.Section == 3 & indexPath.Row == 0)
            {
                var numberOfBeersInCache = await Client.Instance.BeerDrinkinClient.GetCacheItemCountAsync();
                if(BeerDrinkin.Core.Helpers.Settings.UserTrackingEnabled)
                {
                    Insights.Track("Cache Cleared", "Items Removed", numberOfBeersInCache.ToString());
                }

                if(numberOfBeersInCache == 0)
                {
                    Acr.UserDialogs.UserDialogs.Instance.InfoToast("Your cache is already empty");

                    return;
                }

                //Clear Cache 
                var result = await Client.Instance.BeerDrinkinClient.ClearCache();
                if (result)
                    Acr.UserDialogs.UserDialogs.Instance.ShowSuccess(string.Format("{0} beers removed from your cache", numberOfBeersInCache));
                else
                    Acr.UserDialogs.UserDialogs.Instance.ShowError("Failure to clear cache");
            }

        }
    }
}