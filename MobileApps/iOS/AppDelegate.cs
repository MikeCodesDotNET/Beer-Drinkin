using System;

using Foundation;
using UIKit;

using Microsoft.WindowsAzure.MobileServices;

using JudoDotNetXamarin;
using JudoPayDotNet.Enums;
using BeerDrinkin.DataObjects;
using MikeCodesDotNET.iOS;
using BeerDrinkin.Utils;
using BeerDrinkin.Services.Abstractions;
using BeerDrinkin.iOS.Helpers;
using BeerDrinkin.AzureClient;
using BeerDrinkin.Core.Abstractions.Services;
using BeerDrinkin.iOS.Services;

namespace BeerDrinkin.iOS
{
    [Register ("AppDelegate")]
    partial class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        #region Overrides

        public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
            Core.ViewModels.ViewModelBase.Init();
            ServiceLocator.Instance.Add<IAppInsights, AppInsights>();
            ServiceLocator.Instance.Add<IDeviceSearchProvider, SpotlightService>();

#if DEBUG
            Utils.Helpers.Settings.UserId = string.Empty;

            Xamarin.Calabash.Start();
            #endif

            //Windows Azure
            CurrentPlatform.Init ();
            SQLitePCL.CurrentPlatform.Init ();

            SetupGlobalAppearances();
            ConfigureJudoPayments();

			var shouldPerformAdditionalDelegateHandling = true;

			// Get possible shortcut item
			if (launchOptions != null) {
				LaunchedShortcutItem = launchOptions [UIApplication.LaunchOptionsShortcutItemKey] as UIApplicationShortcutItem;
				shouldPerformAdditionalDelegateHandling = (LaunchedShortcutItem == null);
			}

			// Add dynamic shortcut items
			if (application.ShortcutItems.Length == 0) 
            {
				var shortcut3 = new UIMutableApplicationShortcutItem(ShortcutIdentifier.MyBeers, "My Beer")
				{
					LocalizedSubtitle = "See the beers you've already had",
					Icon = UIApplicationShortcutIcon.FromTemplateImageName("quickAction.myBeers.png")
				};

				// Update the application providing the initial 'dynamic' shortcut items.
				application.ShortcutItems = new UIApplicationShortcutItem[]{shortcut3};
			}
			return shouldPerformAdditionalDelegateHandling;
        }

        void ConfigureJudoPayments ()
        {
            var configInstance = JudoConfiguration.Instance;

            //setting for Sandbox
            configInstance.Environment = JudoEnvironment.Live;

            configInstance.ApiToken = "MzEtkQK1bHi8v8qy";
            configInstance.ApiSecret = "c158b4997dfc7595a149a20852f7af2ea2e70bd2df794b8bdbc019cc5f799aa1";
            configInstance.JudoId = "100915867";
        }

        public override bool WillFinishLaunching (UIApplication application, NSDictionary launchOptions)
        {
            UIApplication.SharedApplication.SetStatusBarStyle (UIStatusBarStyle.LightContent, false);
            return true;
        }

        public override bool ContinueUserActivity (UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
        {
            switch (userActivity.ActivityType) 
            {
				case "com.micjames.beerdrinkin.mybeers":
                    break;
				case "com.micjames.beerdrinkin.wishlist":
                    break;
				case "com.micjames.beerdrinkin.search":
                    break;
				case "com.micjames.beerdrinkin.profile":
                    break;
				case "com.micjames.beerdrinkin.beerdetails":
                    var info = userActivity.UserInfo;
                if (this.Window.RootViewController.ChildViewControllers[0] is UITabBarController) 
                {
					var tabController = this.Window.RootViewController.ChildViewControllers[0] as UITabBarController;
					tabController.SelectedIndex = 2;

						var beerItem = new Beer();

						var id = new NSObject();
						info.TryGetValue(new NSString("id"), out id);

						var name = new NSObject();
						info.TryGetValue(new NSString("name"), out name);

						var description = new NSObject();
						info.TryGetValue(new NSString("description"), out description);

						var imageUrl = new NSObject();
						info.TryGetValue(new NSString("imageUrl"), out imageUrl);

						var breweryDbId = new NSObject();
						info.TryGetValue(new NSString("breweryDbId"), out breweryDbId);

						beerItem.Name = name.ToString();
						beerItem.Description = description.ToString();
						beerItem.Image.MediumUrl = imageUrl.ToString();
						beerItem.BreweryDbId = breweryDbId.ToString();

						if (!string.IsNullOrEmpty(beerItem.BreweryDbId))
						{
							var storyboard = UIStoryboard.FromName("Main", null);
							var vc = storyboard.InstantiateViewController ("BEER_DESCRIPTION") as BeerDescriptionTableView;
							vc.SetBeer (beerItem);
							var navigationControler = tabController.SelectedViewController as UINavigationController;
							navigationControler.PushViewController (vc, true);
						}
                }
                break;
            }

            return true;
        }

		// Minimum number of seconds between a background refresh
		// 15 minutes = 15 * 60 = 900 seconds
		const double MINIMUM_BACKGROUND_FETCH_INTERVAL = 900;

		void SetMinimumBackgroundFetchInterval ()
		{
			UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval (MINIMUM_BACKGROUND_FETCH_INTERVAL);
		}

		// Called whenever your app performs a background fetch
		public override void PerformFetch (UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
		{
			
		}


        #endregion

		#region Quick Action

		public static class ShortcutIdentifier
		{
			public const string MyBeers = "com.micjames.beerdrinkin.mybeers";
			public const string WishList = "com.micjames.beerdrinkin.wishlist";
			public const string Search = "com.micjames.beerdrinkin.search";
			public const string Me = "com.micjames.beerdrinkin.profile";
		}


		public UIApplicationShortcutItem LaunchedShortcutItem { get; set; }
		public override void OnActivated (UIApplication application)
		{
			Console.WriteLine ("OnActivated");

			// Handle any shortcut item being selected
			HandleShortcutItem(LaunchedShortcutItem);

			// Clear shortcut after it's been handled
			LaunchedShortcutItem = null;
		}

		// if app is already running
		public override void PerformActionForShortcutItem (UIApplication application, UIApplicationShortcutItem shortcutItem, UIOperationHandler completionHandler)
		{
			var handled = HandleShortcutItem(shortcutItem);
			completionHandler(handled);
		}
		public bool HandleShortcutItem(UIApplicationShortcutItem shortcutItem)
		{
			var handled = false;

			// Anything to process?
			if (shortcutItem == null) 
				return false;
             
			// Take action based on the shortcut type
			switch (shortcutItem.Type) 
			{
				case ShortcutIdentifier.MyBeers:
					if (this.Window.RootViewController.ChildViewControllers[0] is UITabBarController)
					{
						var tabController = this.Window.RootViewController.ChildViewControllers[0] as UITabBarController;
						tabController.SelectedIndex = 0;
					}
					handled = true;
				break;
				case ShortcutIdentifier.WishList:
					if (this.Window.RootViewController.ChildViewControllers[0] is UITabBarController)
					{
						var tabController = this.Window.RootViewController.ChildViewControllers[0] as UITabBarController;
						tabController.SelectedIndex = 1;
					}
					handled = true;
				break;
				case ShortcutIdentifier.Search:
					if (this.Window.RootViewController.ChildViewControllers[0] is UITabBarController)
					{
						var tabController = this.Window.RootViewController.ChildViewControllers[0] as UITabBarController;
						tabController.SelectedIndex = 2;
					}
					handled = true;
				break;
				case ShortcutIdentifier.Me:
					if (this.Window.RootViewController.ChildViewControllers[0] is UITabBarController)
					{
						var tabController = this.Window.RootViewController.ChildViewControllers[0] as UITabBarController;
						tabController.SelectedIndex = 3;
					}
					handled = true;
				break;
			}

			Console.Write (handled);
			// Return results
			return handled;
		}

		#endregion

        static void SetupGlobalAppearances ()
        {
            //NavigationBar
            UINavigationBar.Appearance.BarTintColor = Helpers.Style.Colors.NavigationBar;
            UINavigationBar.Appearance.TintColor = Helpers.Style.Colors.NavigationTint;
            UINavigationBar.Appearance.Translucent = false;

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                    Font = Helpers.Style.Fonts.Heading,
                    TextColor = Helpers.Style.Colors.NavigationTint
            });

            //NavigationBar Buttons 
            UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes
                {
                    Font = Helpers.Style.Fonts.NavigationButton,
                    TextColor = Helpers.Style.Colors.NavigationTint
                }, UIControlState.Normal);

            //TabBar
            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes{ Font = Helpers.Style.Fonts.TabBar }, UIControlState.Normal);
            UITabBar.Appearance.BarTintColor = "222630".ToUIColor();
            UITabBar.Appearance.TintColor = Helpers.Style.Colors.Blue;
        }
    }
}