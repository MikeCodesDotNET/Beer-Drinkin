#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

using System.Drawing;
using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace PDRatingSample {
    public class Application {
        static void Main(string[] args) {
			UIApplication.Main(args, null, "AppDelegate");
        }
    }
	[Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate {
        UIWindow window;
        UITabBarController tabBarController;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
            window = new UIWindow(UIScreen.MainScreen.Bounds);
            window.BackgroundColor = UIColor.White;

            UIViewController viewController1 = new FiveStarViewController();
            UIViewController viewController2 = new TenTomatoesViewController();
            UIViewController viewController3 = new SixMoustachesViewController();
            UIViewController viewController4 = new CustomBackgroundViewController();
            UIViewController viewController5 = new SampleTableViewControllerController();
            tabBarController = new UITabBarController();
            tabBarController.ViewControllers = new[] {
                viewController1,
                viewController2,
                viewController3,
                viewController4,
                viewController5,
            };
            window.RootViewController = tabBarController;
            window.MakeKeyAndVisible();
            return true;
        }
    }
}

