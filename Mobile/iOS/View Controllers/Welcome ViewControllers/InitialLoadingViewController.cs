using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using BeerDrinkin.iOS.Helpers;
using MikeCodesDotNET.iOS;

namespace BeerDrinkin.iOS
{
	partial class InitialLoadingViewController : UIViewController
	{
		public InitialLoadingViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            lblTitle.Alpha = 0;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            lblTitle.FadeIn(2, 1);
        }
	}
}
