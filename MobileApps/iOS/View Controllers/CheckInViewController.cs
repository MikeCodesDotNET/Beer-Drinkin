using Foundation;
using System;
using UIKit;
using PatridgeDev;
using BeerDrinkin.Core.Abstractions.ViewModels;
using BeerDrinkin.Utils;
using BeerDrinkin.Services.Abstractions;

namespace BeerDrinkin.iOS
{
    public partial class CheckInViewController : UIViewController
    {
        ICheckInViewModel viewModel;
        IAppInsights logger;
        int rating;

        public CheckInViewController (IntPtr handle) : base (handle)
        {
        }

        DataObjects.Beer beer;

        public DataObjects.Beer Beer
        {
            get
            {
                return beer;
            }
            set
            {
                beer = value;
            }
        }

        public override void ViewDidLoad()
        {
            viewModel = ServiceLocator.Instance.Resolve<ICheckInViewModel>();
            logger = ServiceLocator.Instance.Resolve<IAppInsights>();

            lblBeerName.Text = beer.Name;
            lblDate.Text = DateTime.Now.ToString("M");

            starView.BackgroundColor = ratingView.BackgroundColor;

            RatingConfig ratingConfig = new RatingConfig(UIImage.FromFile("star_blue_empty.png"),UIImage.FromFile("star_blue_filled.png"), UIImage.FromFile("star_blue_filled.png"));
            decimal averageRating = 3;

            var starsView = new PDRatingView(starView.Bounds, ratingConfig, averageRating);
            starsView.Center = new CoreGraphics.CGPoint(View.Center.X -10, starView.Frame.Y +10);

            starsView.RatingChosen += (sender, e) =>
            {
                rating = e.Rating;
            };
            starView.Add(starsView);
            starView.LayoutSubviews();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            UITapGestureRecognizer scanBarcodeTapped = new UITapGestureRecognizer();
            scanBarcodeTapped.AddTarget(async() =>
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();

                Console.WriteLine(result.Text);
            });

            scanBarcodeView.AddGestureRecognizer(scanBarcodeTapped);
        }

        async partial void BtnCheckIn_TouchUpInside(UIButton sender)
        {
            try
            {
                await viewModel.CheckInBeer(beer, rating);
                Acr.UserDialogs.UserDialogs.Instance.ShowSuccess("Saved!");
                await DismissViewControllerAsync(true);
            }
            catch (Exception ex)
            {
                logger.Report(ex);
                Acr.UserDialogs.UserDialogs.Instance.ShowError(ex.Message);
            }
        }

        async partial void BtnClose_TouchUpInside(UIButton sender)
        {
            await DismissViewControllerAsync(true);
        }
    }
}