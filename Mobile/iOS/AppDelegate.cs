﻿using System;
using System.IO;

using BeerDrinkin.Core.Helpers;

using Foundation;
using UIKit;

using Color = BeerDrinkin.Helpers.Colours;
using Microsoft.WindowsAzure.MobileServices;
using Splat;
using Xamarin;

using JudoDotNetXamarin;
using JudoPayDotNet.Enums;

namespace BeerDrinkin.iOS
{
    [Register ("AppDelegate")]
    partial class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        #region Overrides

        public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {          
            //Xamarin Insights
            Insights.Initialize (Keys.XamarinInsightsKey);
            Insights.HasPendingCrashReport += PurgeCrashReports;

            #if DEBUG
            //BeerDrinkin.Core.Helpers.Settings.FirstRun = true;
            Calabash.Start ();
            #endif

            //Windows Azure
            CurrentPlatform.Init ();
            SQLitePCL.CurrentPlatform.Init ();

            Client.Instance.BeerDrinkinClient.InitializeStoreAsync();

            SetupGlobalAppearances();
            ConfigureJudoPayments();

            return true;
        }

        void ConfigureJudoPayments ()
        {
            var configInstance = JudoConfiguration.Instance;

            //setting for Sandnox
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

        #endregion

        static void PurgeCrashReports (object sender, bool isStartupCrash)
        {
            if (isStartupCrash) {
                Insights.PurgePendingCrashReports ().Wait ();
            } 
        }

        static void SetupGlobalAppearances ()
        {
            //NavigationBar
            UINavigationBar.Appearance.BarTintColor = Color.Blue.ToNative();
            UINavigationBar.Appearance.TintColor = Color.White.ToNative();
          
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
                {
                    Font = UIFont.FromName("Avenir-Medium", 17f),
                    TextColor = Color.White.ToNative()
                });
            //NavigationBar Buttons 
            UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes
                {
                    Font = UIFont.FromName("Avenir-Medium", 17f),
                    TextColor = Color.White.ToNative()
                }, UIControlState.Normal);

            //TabBar
            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes{ Font = UIFont.FromName("Avenir-Book", 10f) }, UIControlState.Normal);
        }
    }
}