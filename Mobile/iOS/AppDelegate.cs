using System;
using System.IO;
using BeerDrinkin.Core.Helpers;
using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;
using Xamarin;
using Color = BeerDrinkin.Helpers.Colours;
using Splat;

namespace BeerDrinkin.iOS
{
    [Register("AppDelegate")]
    partial class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        #region Overrides

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {            
            SetupGlobalAppearances();

            //Xamarin Insights
            Insights.HasPendingCrashReport += PurgeCrashReports;
            Insights.Initialize(Keys.XamarinInsightsKey);

            //Akavache
            Akavache.BlobCache.ApplicationName = "BeerDrinkin";

            #if DEBUG
            Akavache.BlobCache.UserAccount.InvalidateAll();
            //BeerDrinkin.Core.Helpers.Settings.FirstRun = true;
            #endif

            //Windows Azure
            CurrentPlatform.Init();
            SQLitePCL.CurrentPlatform.Init();
            Client.Instance.BeerDrinkinClient.InitializeStoreAsync(SqlDbLocation);
           
            return true;
        }

        public override bool WillFinishLaunching(UIApplication application, NSDictionary launchOptions)
        {
            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
            return true;
        }

        public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
        {          
            //TODO Complete loading the beer
            var userInfo = userActivity.UserInfo;
            var beerID = userInfo.ValueForKey(new NSString("kCSSearchableItemActivityIdentifier"));
            Console.WriteLine(beerID);

            Window.RestoreUserActivityState(userActivity);

            return true;
        }

        #endregion

        static void PurgeCrashReports(object sender, bool isStartupCrash)
        {
            if (isStartupCrash)
            {
                Insights.PurgePendingCrashReports().Wait();
            } 
        }

        static void SetupGlobalAppearances()
        {
            //NavigationBar
            UINavigationBar.Appearance.BarTintColor = Color.Blue.ToNative();
            UINavigationBar.Appearance.TintColor = Color.White.ToNative();
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes{ Font = UIFont.FromName("Avenir-Medium", 20f), TextColor = Color.White.ToNative() });

            //NavigationBar Buttons 
            UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes{ Font = UIFont.FromName("Avenir-Medium", 14f), TextColor = Color.White.ToNative() }, UIControlState.Normal);

            //TabBar
            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes{ Font = UIFont.FromName("Avenir-Book", 10f) }, UIControlState.Normal);
        }

        static string SqlDbLocation
        {
            get
            {
                const string filename = "beerdrinkin.db";

                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var libraryPath = Path.Combine(Directory.GetParent(documentsPath).ToString(), "Library");
                var path = Path.Combine(libraryPath, filename);

                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
                return path;
            }
        }
    }
}