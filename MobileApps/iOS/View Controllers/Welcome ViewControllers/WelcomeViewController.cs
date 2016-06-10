using System;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;
using System.Collections.Generic;
using Xamarin;
using BeerDrinkin.iOS.Helpers;
using System.Threading.Tasks;
using MikeCodesDotNET.iOS;

namespace BeerDrinkin.iOS
{
    partial class WelcomeViewController : UIViewController
    {
        public WelcomeViewController(IntPtr handle): base(handle)
        {
        }

        ITrackHandle trackerHandle;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            trackerHandle = Insights.TrackTime("Time spent on welcome screen");
            trackerHandle.Start();
           
            lblTitle.Text = Strings.Welcome_Title;
            lblPromise.Text = Strings.Welcome_Promise;
            btnConnectWithFacebook.SetTitle(Strings.Welcome_Facebook, UIControlState.Normal);
            btnConnectWithGoogle.SetTitle(Strings.Welcome_Google, UIControlState.Normal);

            btnConnectWithFacebook.Alpha = 0;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            btnConnectWithFacebook.Alpha = 0;
            btnConnectWithGoogle.Alpha = 0;
            lblTitle.Alpha = 0;
            lblPromise.Alpha = 0;
            lblAmazingFeatures.Alpha = 0;

            if (Core.Helpers.Settings.FirstRun == true)
            {
                Core.Helpers.Settings.FirstRun = false;

                var tinderBeer = Storyboard.InstantiateViewController("welcomeMapView");
                PresentViewControllerAsync(tinderBeer, false);
            }

            const double duration = 0.4;
            const float delay = 0.3f;

            //btnClose.FadeIn(duration, delay);
            lblTitle.FadeIn(duration, delay);
            lblAmazingFeatures.FadeIn(duration, delay);

            btnConnectWithFacebook.FadeIn(duration, delay + 0.5f);
            btnConnectWithGoogle.FadeIn(duration, delay + 0.7f);
            lblPromise.FadeIn(duration, delay + 0.7f);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            if (trackerHandle != null)
            {
                trackerHandle.Stop();
                trackerHandle = null;
            }
        }

        async partial void BtnConnectWithFacebook_TouchUpInside(UIButton sender)
        {
            try
            {   
                btnConnectWithFacebook.PulseToSize(0.9f, 0.2, false);

                await Client.Instance.BeerDrinkinClient.ServiceClient.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                UserAuthenticiated();
            }
            catch
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError(Strings.Welcome_AuthError);
            }
        }

        async partial void BtnConnectWithGoogle_TouchUpInside(UIButton sender)
        {
            try
            {   
                btnConnectWithGoogle.PulseToSize(0.9f, 0.2, false);

                await Client.Instance.BeerDrinkinClient.ServiceClient.LoginAsync(this, MobileServiceAuthenticationProvider.Google);
                UserAuthenticiated();
            }
            catch
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError(Strings.Welcome_AuthError);
            }
        }

        async void UserAuthenticiated()
        {
			Acr.UserDialogs.UserDialogs.Instance.ShowSuccess("Signed In", 1500);
			await DismissViewControllerAsync(true);
            await Client.Instance.BeerDrinkinClient.RefreshAll();           
        }

        partial void BtnCancel_TouchUpInside(UIButton sender)
        {
            this.DismissViewController(true, null);
        }
    }
}
