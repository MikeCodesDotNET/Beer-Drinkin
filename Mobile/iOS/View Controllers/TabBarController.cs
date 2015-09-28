using System;
using CoreGraphics;
using UIKit;
using Color = BeerDrinkin.Shared.Colour;
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

            SetupUI();
            SetupTabChangeAnimation();
        }

        void SetupUI()
        {
            TabBar.Items[0].Title = Strings.TabControllerMyBeers;
            TabBar.Items[1].Title = Strings.TabControllerSearchTab;
            TabBar.Items[2].Title = Client.Instance.BeerDrinkinClient.CurrentAccount == null ? Strings.TabControllerProfile : Client.Instance.BeerDrinkinClient.CurrentAccount.FirstName;
            TabBar.SelectedImageTintColor = Color.Blue;
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