using System;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;
using System.Collections.Generic;
using Xamarin;
using BeerDrinkin.iOS.Helpers;
using System.Threading.Tasks;
using MikeCodesDotNET.iOS;
using BeerDrinkin.Utils;
using BeerDrinkin.AzureClient;

namespace BeerDrinkin.iOS
{
    partial class WelcomeViewController : UIViewController
    {
        IAzureClient azure;
        public WelcomeViewController(IntPtr handle): base(handle)
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnConnectWithFacebook.Alpha = 0;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            btnConnectWithFacebook.Alpha = 0;
            lblTitle.Alpha = 0;
            lblPromise.Alpha = 0;
            lblAmazingFeatures.Alpha = 0;

            const double duration = 0.4;
            const float delay = 0.3f;

            lblTitle.FadeIn(duration, delay);
            lblAmazingFeatures.FadeIn(duration, delay);

            btnConnectWithFacebook.FadeIn(duration, delay + 0.5f);
            lblPromise.FadeIn(duration, delay + 0.7f);
        }

        async partial void BtnConnectWithFacebook_TouchUpInside(UIButton sender)
        {
            try
            {   
                btnConnectWithFacebook.PulseToSize(0.9f, 0.2, false);

                await azure.Client.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                UserAuthenticiated();
            }
            catch
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError("Cock it, couldn't log in");
            }
        }     

        async void UserAuthenticiated()
        {
			Acr.UserDialogs.UserDialogs.Instance.ShowSuccess("Signed In", 1500);
			await DismissViewControllerAsync(true);
        }
       
    }
}
