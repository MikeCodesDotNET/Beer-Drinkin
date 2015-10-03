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
using Splat;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.IO;
using Akavache;
using System.Reactive.Linq; 


namespace BeerDrinkin.iOS
{
    partial class AccountViewController : UIViewController
    {
        bool avatarBusy;

        bool busy;
        readonly AccountViewModel viewModel = new AccountViewModel();
       
        public AccountViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if(BeerDrinkin.Core.Helpers.Settings.UserTrackingEnabled)
            {
                Insights.Track("Loaded AccountView", "ViewController", "AccountViewController");
            }

            imgAvatar.ContentMode = UIViewContentMode.ScaleAspectFill;

            SetupBindings();
            viewModel.FetchData();
        }

        async public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            NavigationController.NavigationBar.BarTintColor = Color.Blue.ToNative();
            await viewModel.FetchData();
        }

        private void SetupBindings()
        {
            viewModel.PropertyChanged += (sender, e) =>
            {
                    InvokeOnMainThread(() =>{
                        RefreshUI();
                    });      
            };

            scrollView.Scrolled += (object sender, EventArgs e) =>
            {
                parallaxScrollView.ContentOffset = new CGPoint(0, scrollView.ContentOffset.Y / 3);

                if (scrollView.ContentOffset.Y < -5)
                {
                    viewModel.FetchData(true);
                }
            };
        }

        public void RefreshAvatar()
        {
            if (avatarBusy)
                return;

            imgAvatar.Layer.CornerRadius = imgAvatar.Frame.Size.Width / 2;
            imgAvatar.ClipsToBounds = true;
    
            var avatarUrl = viewModel.AvararUrl;
            imgAvatar.SetImage(new NSUrl(avatarUrl), UIImage.FromBundle("BeerDrinkin.png"));

            avatarBusy = false;
        }

        public void RefreshUI()
        {
            NavigationController.NavigationBar.TopItem.Title = viewModel.FirstName;
            NavigationController.Title = viewModel.FirstName;

            lblBeerCount.Text = viewModel.BeerCount;
            lblRatingCount.Text = viewModel.RatingsCount;
            lblPhotoCount.Text = viewModel.PhotoCount;
            lblName.Text = viewModel.FullName;

            var layout = new UICollectionViewFlowLayout ();   
            layout.SectionInset = new UIEdgeInsets (5,5,2.5f,2.5f);
            photoCollection.SetCollectionViewLayout(layout, false);

            if (viewModel.BeerPhotosUrls != null)
            {
                photoCollection.DataSource = new PhotoCollectionViewDataSource(viewModel.BeerPhotosUrls);
                photoCollection.ReloadData();   
            }
 
        }

        partial void btnAvatar_TouchUpInside(UIButton sender)
        {
        }


        class PhotoCollectionViewDataSource : UICollectionViewDataSource
        {
            List<string> imageUrls;
            public PhotoCollectionViewDataSource(List<string> imageUrls)
            {
                this.imageUrls = imageUrls;
            }

            public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
            {
                var cell = (PhotoCollectionViewCell)collectionView.DequeueReusableCell("photoCell", indexPath);

                DownloadImageAsync(imageUrls[indexPath.Row]).ContinueWith((task) => InvokeOnMainThread(() =>
                {
                    cell.ImageView.Image = task.Result.ToNative();
                    cell.LayoutSubviews();
                }));

                cell.BackgroundColor = UIColor.White;
                return cell;
            }

            public async Task<IBitmap> DownloadImageAsync(string imageUrl)
            {
                IBitmap image = null;

                try
                {
                    var bytes = await BlobCache.UserAccount.Get(imageUrl);
                    image = await BitmapLoader.Current.Load(new MemoryStream(bytes), null, null);
                }
                catch(KeyNotFoundException)
                {
                   //Nothing better than doing nothing with an exception
                }

                if (image == null)
                {
                    var client = new HttpClient();
                    var imageBase64 = await client.GetStringAsync(new Uri(imageUrl));
                    var imageByte = Convert.FromBase64String(imageBase64);
                    await BlobCache.UserAccount.Insert(imageUrl, imageByte);
                    image = await BitmapLoader.Current.Load(new MemoryStream(imageByte), null, null);
                }
                return image;
            }

            public override nint GetItemsCount(UICollectionView collectionView, nint section)
            {
                return (nint)imageUrls.Count;
            }
        }


    }
}