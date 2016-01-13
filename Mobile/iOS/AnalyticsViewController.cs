using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using AMViralSwitch;
using Awesomizer;
using Splat;

namespace BeerDrinkin.iOS
{
	partial class AnalyticsViewController : UIViewController
	{
		public AnalyticsViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            swtCriticalBugs.SetAnimationElementsOn (
                AnimationElement.TextColor (lblCriticalBugs, UIColor.White),
                AnimationElement.TextColor (lblCriticalBugsDescription, UIColor.White)
            );

            swtCriticalBugs.SetAnimationElementsOff(
                AnimationElement.TextColor(lblCriticalBugs, "514F52".ToUIColor()),
                AnimationElement.TextColor(lblCriticalBugsDescription, "514F52".ToUIColor())
            );

            swtCriticalBugs.OnCompleted += delegate
            {
                imgCriticalBugIcon.Image = imgCriticalBugIcon.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                imgCriticalBugIcon.TintColor = UIColor.White;
            };

            swtCriticalBugs.OffCompleted += delegate
            {
                imgCriticalBugIcon.Image = imgCriticalBugIcon.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                imgCriticalBugIcon.TintColor = BeerDrinkin.Helpers.Colours.Blue.ToNative();
            };
        }
	}
}
