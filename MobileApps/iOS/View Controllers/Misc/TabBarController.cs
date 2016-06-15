using System;

using CoreGraphics;
using UIKit;

using System.Threading.Tasks;

namespace BeerDrinkin.iOS
{
	partial class TabBarController : UITabBarController
	{
		#region Constructor
		public TabBarController(IntPtr handle) : base(handle)
		{
		}

		#endregion

		#region Overrides
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			SetupTabChangeAnimation();
		}

		#endregion

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
						fromView.RemoveFromSuperview();
						SelectedViewController = controller;
					});
				return true;
			};
		}
	}
}