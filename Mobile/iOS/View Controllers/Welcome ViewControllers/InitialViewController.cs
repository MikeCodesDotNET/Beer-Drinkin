using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Threading.Tasks;
using BeerDrinkin.Service;
using NotificationCenter;

namespace BeerDrinkin.iOS
{
    partial class InitialViewController : UIViewController
    {
        public InitialViewController(IntPtr handle) : base(handle)
        {
        }

        public async override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            await AttemptSignIn();

            var vc = Storyboard.InstantiateViewController("welcomeView");
            await PresentViewControllerAsync(vc, false);
        }

        async Task AttemptSignIn()
        {
            //TODO Check in an auth token already exists. I removed this code when ripping out Akavache

            var vc = Storyboard.InstantiateViewController("welcomeView");
            await PresentViewControllerAsync(vc, false);
        }
    }
}
