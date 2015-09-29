using PatridgeDev;

#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

using System.Drawing;
using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace PDRatingSample {
    public class TenTomatoesViewController : UIViewController {
        PDRatingView ratingView;
        string ratingStyle = "Tomatoes";

        public TenTomatoesViewController() {
            Title = ratingStyle;
            TabBarItem.Image = UIImage.FromBundle(ratingStyle + "/filled").Scale(new CGSize(30f, 30f));
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            View.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
            View.BackgroundColor = UIColor.White;

            var ratingConfig = new RatingConfig(emptyImage: UIImage.FromBundle(ratingStyle + "/empty"),
                                                filledImage: UIImage.FromBundle(ratingStyle + "/filled"),
                                                chosenImage: UIImage.FromBundle(ratingStyle + "/chosen"));
            ratingConfig.ScaleSize = 10;
            // [Optional] Put a little space between the rating items.
            ratingConfig.ItemPadding = 5f;
            var ratingFrame = new CGRect(CGPoint.Empty, new CGSize(View.Bounds.Width, 125f));;

            ratingView = new PDRatingView(ratingFrame, ratingConfig);

            // [Optional] Set the current rating to display.
            decimal rating = 3.58m;
            //decimal halfRoundedRating = Math.Round(rating * 2m, MidpointRounding.AwayFromZero) / 2m;
            //decimal wholeRoundedRating = Math.Round(rating, MidpointRounding.AwayFromZero);
            ratingView.AverageRating = rating;

            // [Optional] Make it read-only to keep the user from setting a rating.
            //StarRating.UserInteractionEnabled = false;

            // [Optional] Attach to the rating event to do something with the chosen value.
            ratingView.RatingChosen += (sender, e) => {
                (new UIAlertView("Rated!", e.Rating.ToString() + " " + ratingStyle, null, "Ok")).Show();
            };

            View.Add(ratingView);
        }
    }
}