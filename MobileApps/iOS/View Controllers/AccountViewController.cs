using System;
using BeerDrinkin.Core.ViewModels;
using Foundation;
using UIKit;
using SDWebImage;
using Color = BeerDrinkin.Helpers.Colours;
using Splat;
using Xamarin;
using MikeCodesDotNET.iOS;
using Plugin.Connectivity;
using System.Threading.Tasks;

namespace BeerDrinkin.iOS
{
    partial class AccountViewController : UIViewController
    {
        readonly AccountViewModel viewModel = new AccountViewModel();
        bool isFirstRun = true;
        bool connected;

        public AccountViewController(IntPtr handle) : base(handle)
        {
        }

        async public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupUI();
            SetupBindings();

            connected = await CrossConnectivity.Current.IsReachable("google.com", 1500);
            if(connected)
            {
                await viewModel.Reload();
            }
        }

        async public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            connected = await CrossConnectivity.Current.IsReachable("google.com");
            BeerDrinkin.Core.Services.UserTrackingService.ReportViewLoaded("AccountViewController", "ViewDidAppear");
            if(connected)
            {
                await viewModel.Reload();
            }
            else
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError("No internet connectivity");
            }
        }

        void SetupUI()
        {
			//NavigationBar
			/*
			NavigationController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
			NavigationController.NavigationBar.ShadowImage = new UIImage();
			NavigationController.NavigationBar.Translucent = true;
			*/

            //Profile Image
          //  imgAvatar.ContentMode = UIViewContentMode.ScaleAspectFill;
            if(isFirstRun){imgAvatar.Pop(0.7f, 0, 0.2f);}
            isFirstRun = false;
        }

        void SetupBindings()
        {
            viewModel.PropertyChanged += async delegate
            {
                await RefreshUI();
            };
        }
            
        void RefreshAvatar()
        {
            if (string.IsNullOrEmpty(viewModel.AvararUrl))
                return; 
            
            imgAvatar.Layer.CornerRadius = imgAvatar.Frame.Size.Width / 2;
            imgAvatar.ClipsToBounds = true;
    
            var avatarUrl = viewModel.AvararUrl;
            imgAvatar.SetImage(new NSUrl(avatarUrl), UIImage.FromBundle("BeerDrinkin.png"));
        }

        async Task RefreshUI()
        {
            NavigationController.NavigationBar.TopItem.Title = viewModel.FirstName;
            NavigationController.Title = viewModel.FirstName;

			/*
            lblBeersCount.Text = viewModel.BeerCount;
            lblRatingCount.Text = viewModel.RatingsCount;
            lblPhotoCount.Text = viewModel.PhotoCount;

            var layout = new UICollectionViewFlowLayout();   
            layout.SectionInset = new UIEdgeInsets(5, 5, 2.5f, 2.5f);
            */
            RefreshAvatar();

            return;
         }
    }
}