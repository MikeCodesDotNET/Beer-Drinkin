using System;
using CoreGraphics;
using UIKit;
using Color = BeerDrinkin.Helpers.Colours;
using Splat;
using Strings = BeerDrinkin.Core.Helpers.Strings;

namespace BeerDrinkin.iOS
{
    partial class TabBarController : UITabBarController
    {
        public TabBarController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //On the inital launch of the app (ie, the user is not authenticated, we want to only show the search tab). 
            if(Client.Instance.BeerDrinkinClient.CurrenMobileServicetUser == null)
            {
                //We just want the middle on and we've 3 tabs. This is a little flaky...TODO, probably make this more robust.
                ViewControllers = new UIViewController[] { ViewControllers[1] };
            }

            SetupUI();
            SetupTabChangeAnimation();           
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

        }

        void SetupUI()
        {
            TabBar.Items[0].Title = Strings.TabControllerMyBeers;
            TabBar.Items[1].Title = Strings.TabControllerSearchTab;
            TabBar.Items[2].Title = Client.Instance.BeerDrinkinClient.CurrentAccount == null ? Strings.TabControllerProfile : Client.Instance.BeerDrinkinClient.CurrentAccount.FirstName;
            TabBar.SelectedImageTintColor = Color.Blue.ToNative();
        }

        void SetupTabChangeAnimation()
        {
            ShouldSelectViewController = (tabController, controller) =>
            {
                if (SelectedViewController == null || controller == SelectedViewController)
                    return true;

                var fromView = SelectedViewController.View;
                var toView = controller.View;

                var destFrame = fromView.Frame;
                const float offset = 25;

                //Position toView off screen
                fromView.Superview.AddSubview(toView);
                toView.Frame = new CGRect(offset, destFrame.Y, destFrame.Width, destFrame.Height);

                UIView.Animate(0.1,
                    () =>
                    {
                        toView.Frame = new CGRect(0, destFrame.Y, destFrame.Width, destFrame.Height);
                    }, () =>
                    {
                        //Completion handler. Remove old view
                        fromView.RemoveFromSuperview();
                        SelectedViewController = controller;
                    });
                return true;
            };
                 }
    }
}