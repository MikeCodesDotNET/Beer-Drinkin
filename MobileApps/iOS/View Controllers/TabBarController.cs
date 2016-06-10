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
			SetupUI();
			SetupTabChangeAnimation();
		}

		#endregion

		async Task SetupUI()
		{
			var currentUser = await Client.Instance.BeerDrinkinClient.Users.CurrentUser();

			TabBar.Items[0].Title = Strings.Tabs_MyBeers;
			TabBar.Items[1].Title = Strings.Tabs_WishList;
			TabBar.Items[2].Title = Strings.Tabs_Search;

			if (currentUser != null)
				TabBar.Items[3].Title = currentUser.UserName;

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
						fromView.RemoveFromSuperview();
						SelectedViewController = controller;
					});
				return true;
			};
		}
	}
}