using System;
using System.Threading.Tasks;
using BeerDrinkin.Core.ViewModels;
using CoreGraphics;
using Foundation;
using UIKit;
using SDWebImage;
using Color = BeerDrinkin.Helpers.Colours;
using Splat;
using System.Collections.Generic;
using Xamarin;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.IO;
using System.Reactive.Linq; 
using BeerDrinkin.iOS.Helpers;
using CoreAnimation;
using Awesomizer;

namespace BeerDrinkin.iOS
{
    partial class AccountViewController : UIViewController
    {
        bool avatarBusy;
        readonly AccountViewModel viewModel = new AccountViewModel();
       
        public AccountViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.NavigationController.NavigationBar.Translucent = false;
            this.NavigationController.NavigationBar.ShadowImage = new UIImage();

            if(BeerDrinkin.Core.Helpers.Settings.UserTrackingEnabled)
            {
                Insights.Track("Loaded AccountView", "ViewController", "AccountViewController");
            }

            imgAvatar.ContentMode = UIViewContentMode.ScaleAspectFill;

            SetupBindings();
            viewModel.Reload();
        }

        bool isFirstRun = true;
        async public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            NavigationController.NavigationBar.BarTintColor = Color.Blue.ToNative();
            await viewModel.Reload();

            if(isFirstRun)
                imgAvatar.Pop(0.7f, 0, 0.2f);

            isFirstRun = false;
        }

        private void SetupBindings()
        {
            viewModel.PropertyChanged += (sender, e) => InvokeOnMainThread(RefreshUI);
        }

        public void RefreshAvatar()
        {
            imgAvatar.Layer.CornerRadius = imgAvatar.Frame.Size.Width / 2;
            imgAvatar.ClipsToBounds = true;
    
            var avatarUrl = viewModel.AvararUrl;
            imgAvatar.SetImage(new NSUrl(avatarUrl), UIImage.FromBundle("BeerDrinkin.png"));

        }

        public void RefreshUI()
        {
            NavigationController.NavigationBar.TopItem.Title = viewModel.FirstName;
            NavigationController.Title = viewModel.FirstName;

            //lblBeerCount.Text = viewModel.BeerCount;
            lblRatingCount.Text = viewModel.RatingsCount;
            lblPhotoCount.Text = viewModel.PhotoCount;
            //lblName.Text = viewModel.FullName;

            var layout = new UICollectionViewFlowLayout();   
            layout.SectionInset = new UIEdgeInsets(5, 5, 2.5f, 2.5f);
            RefreshAvatar();

        }
 
    }
}