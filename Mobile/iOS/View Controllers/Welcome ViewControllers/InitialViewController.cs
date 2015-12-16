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

            //We've nothing. Lets go ahead and load the inital view. 
            var vc = Storyboard.InstantiateViewController("tabBarController");
            await PresentViewControllerAsync(vc, true);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            imgLogo.FadeOut(0.3, 0);
        }

    }
}
