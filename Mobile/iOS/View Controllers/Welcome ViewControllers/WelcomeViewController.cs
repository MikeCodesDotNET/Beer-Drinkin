using System;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;
using Color = BeerDrinkin.Helpers.Colours;
using Splat;
using Strings = BeerDrinkin.Core.Helpers.Strings;
using System.Collections.Generic;
using Xamarin;
using BeerDrinkin.iOS.Helpers;
using System.Threading.Tasks;
using Awesomizer;

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

            if (BeerDrinkin.Core.Helpers.Settings.FirstRun == true)
            {
                BeerDrinkin.Core.Helpers.Settings.FirstRun = false;

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
                //We'll hide all the subviews
                View.FadeSubviewsOut(0.5, 0.2f);
                await Task.Delay(550); //Delays the loading of the next view so we can see the animation.

                await ClientManager.Instance.BeerDrinkinClient.ServiceClient.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                UserAuthenticiated();
            }
            catch
            {
                //We'll make all the subviews visible again
                View.FadeSubviewsIn(2, 0);

                Acr.UserDialogs.UserDialogs.Instance.ShowError(Strings.Welcome_AuthError);
            }
        }

        async partial void BtnConnectWithGoogle_TouchUpInside(UIButton sender)
        {
            try
            {   
                btnConnectWithGoogle.PulseToSize(0.9f, 0.2, false);
                //We'll hide all the subviews
                View.FadeSubviewsOut(0.5, 0.2f);
                await Task.Delay(550); //Delays the loading of the next view so we can see the animation.

                await ClientManager.Instance.BeerDrinkinClient.ServiceClient.LoginAsync(this, MobileServiceAuthenticationProvider.Google);
                UserAuthenticiated();
            }
            catch
            {
                //We'll make all the subviews visible again
                View.FadeSubviewsIn(2, 0);

                Acr.UserDialogs.UserDialogs.Instance.ShowError(Strings.Welcome_AuthError);
            }
        }

        async void UserAuthenticiated()
        {
            var vc = Storyboard.InstantiateViewController("tabBarController");
            await PresentViewControllerAsync(vc, false);

            await ClientManager.Instance.BeerDrinkinClient.RefreshAll();

            if(BeerDrinkin.Core.Helpers.Settings.UserTrackingEnabled)
            {
                var account = ClientManager.Instance.BeerDrinkinClient.CurrentAccount;
                var dateOfBirth = Convert.ToDateTime(account.DateOfBirth);
                DateTime today = DateTime.Today;
                int age = today.Year - dateOfBirth.Year;
                string gender = account.IsMale ? "Male" : "Female";

                var traits = new Dictionary<string, string> {
                    {Insights.Traits.Email, account.Email},
                    {Insights.Traits.FirstName, account.FirstName},
                    {Insights.Traits.LastName, account.LastName},
                    {Insights.Traits.Age, age.ToString()},
                    {Insights.Traits.Gender, gender},
                };
                Insights.Identify(account.Id, traits);


            }
        }

     
        partial void BtnCancel_TouchUpInside(UIButton sender)
        {
            this.DismissViewController(true, null);
        }
    }
}
