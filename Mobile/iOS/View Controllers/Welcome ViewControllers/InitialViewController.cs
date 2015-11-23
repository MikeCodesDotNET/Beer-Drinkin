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

            //Lets check if we've got any tokens sitting around
            if(!string.IsNullOrEmpty(BeerDrinkin.Core.Helpers.Settings.FacebookToken))
            {
                //We've a facebook token!    
            }

            if(!string.IsNullOrEmpty(BeerDrinkin.Core.Helpers.Settings.GoogleToken))
            {
                //We've a Google token!    
            }

            //We've nothing. Lets go ahead and load the inital view. 
            var vc = Storyboard.InstantiateViewController("searchNavigation");
            await PresentViewControllerAsync(vc, true);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            imgLogo.FadeOut(0.3, 0);
        }

    }
}
