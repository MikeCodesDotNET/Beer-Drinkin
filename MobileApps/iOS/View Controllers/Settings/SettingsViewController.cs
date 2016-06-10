using System;
using Foundation;
using UIKit;

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
                TextColor = UIColor.White
            }, UIControlState.Normal);

            TableView.WeakDelegate = this;
        }

        async partial void btnClose_Activated(UIBarButtonItem sender)
        {
            await DismissViewControllerAsync(true);
        }

        //TODO FIX THIS!
        [Export("tableView:didSelectRowAtIndexPath:")]
        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Section == 1 && indexPath.Row == 1)
            {
				var welcomeViewController = Storyboard.InstantiateViewController ("welcomeView");
				PresentModalViewController (welcomeViewController, true);
            }

            if (indexPath.Section == 3 & indexPath.Row == 0)
            {
                
            }
        }
    }
}