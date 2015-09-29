PDRatingView lets you display an average rating and, optionally, receive a user's rating submission.

* Custom rating images.
* Custom rating scale.
* Transparent background for composing.

##Usage

In any `UIView` or `UIViewController`, you add a `PDRatingView` to the displayed view just like any other view.

    using PatridgeDev;
    ...
    
    PDRatingView ratingView;
    public override void ViewDidLoad() {
        
        // Gather up the images to be used.
        RatingConfig ratingConfig = new RatingConfig() {
            EmptyStarImage = UIImage.FromBundle("empty"),
            FilledStarImage = UIImage.FromBundle("filled"),
            ChosenStarImage = UIImage.FromBundle("chosen"),
        };
        
        // Create the view.
        decimal averageRating = 3.25m;
        ratingView = new PDRatingView(new RectangleF(0f, 0f, View.Bounds.Width, 125f), ratingConfig, averageRating);
        
        // [Optional] Do something when the user selects a rating.
        ratingView.RatingChosen += (sender, e) => {
            (new UIAlertView("Rated!", e.Rating.ToString() + " stars", null, "Ok")).Show();
        };
        
        // [Required] Add the view to the 
        View.Add(StarRating);
    }
   