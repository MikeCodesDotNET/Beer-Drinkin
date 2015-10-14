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

            var vc = Storyboard.InstantiateViewController("welcomeViewController");
            PresentViewController(vc, false, null);
        }

        async Task AttemptSignIn()
        {
            var userService = new UserService();

            /*
#if DEBUG
           // await userService.RemoveAuthToken();
#endif
            */
                         
            var user = await userService.GetUser();

            if (user != null)
            {
                var vc = Storyboard.InstantiateViewController("tabBarController");
                await PresentViewControllerAsync(vc, false);
            }
            else
            {
                var vc = Storyboard.InstantiateViewController("welcomeViewController");
                PresentViewController(vc, false, null);
            }
        }
    }
}
