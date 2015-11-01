using System;
using UIKit;
using System.Threading.Tasks;
using BeerDrinkin.iOS.Helpers;

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

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            imgLogo.FadeOut(0.3, 0);
        }

        async Task AttemptSignIn()
        {
            //TODO Check in an auth token already exists. I removed this code when ripping out Akavache

            var vc = Storyboard.InstantiateViewController("welcomeView");
            await PresentViewControllerAsync(vc, false);
        }
    }
}
