using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreLocation;
using System.Threading.Tasks;

namespace BeerDrinkin.iOS
{
	partial class WelcomeMapViewController : UIViewController
	{
		public WelcomeMapViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnOK.Layer.CornerRadius = 4;
            btnSkip.Layer.CornerRadius = 20;

            imgMap.Alpha = 0;
            btnSkip.Alpha = 0;
            lblTitle.Alpha = 0;
            lblDescription.Alpha = 0;
            btnOK.Alpha = 0;

               
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            UIView.Animate(1, 0.2, UIViewAnimationOptions.TransitionCurlUp,
                () =>
                {
                    imgMap.Alpha = 1;
                    btnSkip.Alpha = 1;
                    lblTitle.Alpha = 1;
                    lblDescription.Alpha = 1;
                    btnOK.Alpha = 1;
                }, () =>
                {                    
                });         
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            imgMap.Alpha = 0;
            btnSkip.Alpha = 0;
            lblTitle.Alpha = 0;
            lblDescription.Alpha = 0;
            btnOK.Alpha = 0;
        }

        CLLocationManager locationManager = new CLLocationManager();
        async partial void BtnOK_TouchUpInside(UIButton sender)
        {
            //Request permission to use location
            locationManager.RequestWhenInUseAuthorization();

            locationManager.AuthorizationChanged += (object s, CLAuthorizationChangedEventArgs e) => {
            if(e.Status == CLAuthorizationStatus.Denied)
                {
                    Acr.UserDialogs.UserDialogs.Instance.ShowError("Location updates denied");
                    return;
                }};

            await Task.Run(() =>
            {
                var location = Geolocator.Plugin.CrossGeolocator.Current.GetPositionAsync().Result;
                var topsBeers = Client.Instance.BeerDrinkinClient.GetPopularBeersAsync(location.Longitude, location.Latitude).Result;
            });

            UIView.Animate(1, 0.2, UIViewAnimationOptions.TransitionCurlUp,
                () =>
                {
                    imgMap.Alpha = 0;
                    btnSkip.Alpha = 0;
                    lblTitle.Alpha = 0;
                    lblDescription.Alpha = 0;
                    btnOK.Alpha = 0;
                }, () =>
                {                    
                });      

            var skakeView = Storyboard.InstantiateViewController("shakeWelcomeView");
            await PresentViewControllerAsync(skakeView, false);
        }
	}
}
