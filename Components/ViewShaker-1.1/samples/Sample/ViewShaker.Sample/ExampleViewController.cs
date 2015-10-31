using System;
using CoreGraphics;

using Foundation;
using UIKit;

namespace ViewShaker.Example
{
	public partial class ExampleViewController : UIViewController
	{
		public ExampleViewController()
			: base("ExampleViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var viewShaker = new ViewShaker(this.viewToShake);

			viewShaker.AnimationCompleted += this.OnAnimationCompleted;

			btnShake.TouchUpInside += (sender, e) => 
			{
				viewShaker.Shake();
			};
		}

		private void OnAnimationCompleted(object sender, EventArgs e)
		{
			new UIAlertView("Animation Finished", "Animation Finished", null, "OK", null).Show();
		}
	}
}