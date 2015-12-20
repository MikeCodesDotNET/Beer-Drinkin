using System;

using CoreGraphics;
using UIKit;

using BeerDrinkin.Core.ViewModels;

using PatridgeDev;
using Splat;

namespace BeerDrinkin.iOS
{
    partial class SendFeedbackViewController : UIViewController
    {
        private readonly SendFeedbackViewModel viewModel = new SendFeedbackViewModel();

        #region Constructor
        public SendFeedbackViewController(IntPtr handle) : base(handle)
        {
        }

        #endregion

        partial void btnBack_Activated(UIBarButtonItem sender)
        {
            NavigationController.PopViewController(true);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

    
            btnSend.SetTitleTextAttributes(new UITextAttributes
                {
                    Font = UIFont.FromName("Avenir-Book", 14f),
                    TextColor = UIColor.White
                }, UIControlState.Normal);

            btnSend.Clicked += delegate { viewModel.SendFeedback(); };
            var ratingConfig = new RatingConfig(UIImage.FromBundle("emptyStar"), UIImage.FromBundle("filledStar"), UIImage.FromBundle("filledStar"));

            var uiRatingView = new PDRatingView(new CGRect(30, 10, userInterfaceRatingPlaceholder.Frame.Width - 60, userInterfaceRatingPlaceholder.Frame.Height - 20), ratingConfig);
            uiRatingView.RatingChosen += delegate { viewModel.UserInterfaceRating = (int) uiRatingView.ChosenRating; };

            userInterfaceRatingPlaceholder.Add(uiRatingView);
            var beerSelectionRatingView = new PDRatingView(new CGRect(30, 10, beerSelectionRatingPlaceholder.Frame.Width - 60, beerSelectionRatingPlaceholder.Frame.Height - 20), ratingConfig);
            beerSelectionRatingView.RatingChosen += delegate { viewModel.BeerSelectionRating = (int) beerSelectionRatingView.ChosenRating; };

            tbxFeedback.Changed += delegate { viewModel.Feedback = tbxFeedback.Text; };
            tbxFeedback.Started += delegate
            {
                var isDefault = tbxFeedback.Text.Contains("Write your feedback");
                if (isDefault)
                    tbxFeedback.Text = string.Empty;
            };
            beerSelectionRatingPlaceholder.Add(beerSelectionRatingView);
        }
    }
}