using BeerDrinkin.Forms.Helpers;
using FFImageLoading.Forms.Touch;
using FormsToolkit.iOS;
using Foundation;
using SQLitePCL;
using UIKit;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace BeerDrinkin.Forms.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();

            InitPlugins();

            LoadApplication(new App());

            InitGlobalAppearance();

            return base.FinishedLaunching(app, options);
        }

        private void InitPlugins()
        {
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            CurrentPlatform.Init();
            CachedImageRenderer.Init();
            Toolkit.Init();
            Insights.Initialize(Keys.XamarinInsightsKey);
        }

        private static void InitGlobalAppearance()
        {
            UINavigationBar.Appearance.BarTintColor = ((Color)App.Current.Resources["PrimaryBarColor"]).ToUIColor();
            UINavigationBar.Appearance.TintColor = Color.White.ToUIColor();

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Avenir-Medium", 17f),
                TextColor = Color.White.ToUIColor()
            });

            //NavigationBar Buttons
            UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Avenir-Medium", 17f),
                TextColor = Color.White.ToUIColor()
            }, UIControlState.Normal);

            //TabBar
            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes { Font = UIFont.FromName("Avenir-Book", 10f) }, UIControlState.Normal);
        }
    }
}