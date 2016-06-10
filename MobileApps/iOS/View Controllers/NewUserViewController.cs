using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class NewUserViewController : UIViewController
	{
		public NewUserViewController (IntPtr handle) : base (handle)
		{
		}

        async partial void BtnOK_TouchUpInside(UIButton sender)
        {
            var vc = Storyboard.InstantiateViewController("welcomeView");
            await PresentViewControllerAsync(vc, true);
        }

        partial void BtnCancel_TouchUpInside(UIButton sender)
        {
            this.DismissViewControllerAsync(true);
        }
	}
}
