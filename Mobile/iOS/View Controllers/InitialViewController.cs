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

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Extensions
            var controller = NCWidgetController.GetWidgetController();
            controller.SetHasContent(true, "com.mikejames.beerbrinkin.todayextension");

            var vc = Storyboard.InstantiateViewController("welcomeViewController");
            PresentViewController(vc, false, null);


            //await AttemptSignIn();
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
