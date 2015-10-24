using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class ShakeWelcomeViewController : UIViewController
	{
		public ShakeWelcomeViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {

            lblTitle.Alpha = 0;
            lblDescription.Alpha = 0;
            imgDevice.Alpha = 0;

            btnGotIt.Layer.CornerRadius = 20;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            UIView.Animate(1f, 0.4f, UIViewAnimationOptions.TransitionCurlUp,
                () =>
                {

                    lblTitle.Alpha = 1;
                    lblDescription.Alpha = 1;
                    imgDevice.Alpha = 1;
                    btnGotIt.Alpha = 1;

                }, () =>
                {  
                    var viewShaker = new ViewShaker.ViewShaker(this.imgDevice);
                    viewShaker.Shake(1f);
                });    
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            lblTitle.Alpha = 0;
            lblDescription.Alpha = 0;
            imgDevice.Alpha = 0;

        }

        async partial void BtnGotIt_TouchUpInside(UIButton sender)
        {
            var tinderView = Storyboard.InstantiateViewController("tinderView");
            this.PresentViewControllerAsync(tinderView, true);

        }
	}
}
