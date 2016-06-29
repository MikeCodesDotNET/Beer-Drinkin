using Foundation;
using System;
using UIKit;
using BeerDrinkin.Utils;
using BeerDrinkin.Core.Abstractions.ViewModels;
using MikeCodesDotNET.iOS;

namespace BeerDrinkin.iOS
{
    public partial class EnableLocationTrackingViewController : UIViewController
    {
        IEnableUserLocationViewModel viewModel;
        string SocialAuth = "SOCIAL_AUTH";

        public EnableLocationTrackingViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            viewModel = ServiceLocator.Instance.Resolve<IEnableUserLocationViewModel>();
            btnEnableLocation.Layer.CornerRadius = 4;
            btnEnableLocation.Layer.MasksToBounds = true;
        }


        async partial void BtnEnableLocation_TouchUpInside(UIButton sender)
        {
            if (btnEnableLocation.Title(UIControlState.Normal) == "Enable Locations")
            {
                var granted = await viewModel.RequestPermission();

                if (granted == false)
                    Acr.UserDialogs.UserDialogs.Instance.ShowError("Location permission failed");

                if (granted == true)
                {
                    imgMap.Image = UIImage.FromFile("intro_location_map_success.png");
                    btnEnableLocation.BackgroundColor = "CA4AC2".ToUIColor();
                    btnEnableLocation.SetTitle("Next", UIControlState.Normal);
                    lblTitle.Text = "Success!";
                    btnNoThanks.Hidden = true;
                }
            }
            else
            {
                Auth();
            }

          
        }


        partial void BtnNoThanks_TouchUpInside(UIButton sender)
        {
            Auth();
        }

        async void Auth()
        {
            var vc = Storyboard.InstantiateViewController(SocialAuth);
            await PresentViewControllerAsync(vc, true);
        }
    }
}