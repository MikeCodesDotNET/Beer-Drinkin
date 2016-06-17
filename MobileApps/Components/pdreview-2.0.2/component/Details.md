PDRatingView lets you display an average rating and, optionally, collect a user's rating submission on items in your Xamarin.iOS application.

* Custom rating images.
* Custom rating scale.
* Transparent background for composing.

##Examples

You can use whatever images you want and whatever scale size you need. Many people use five stars.

![Five star rating scale](http://www.patridgedev.com/cdn/pdrating/screenshots/five-stars-scale.png)

Others have something else entirely. Perhaps you want a 10-tomato rating.

![Ten tomato rating scale](http://www.patridgedev.com/cdn/pdrating/screenshots/ten-tomatoes-scale.png)

Whatever you need, you give it a rectangle to it into and it will resize things accordingly.

![Six moustaches rating scale](http://www.patridgedev.com/cdn/pdrating/screenshots/six-moustaches-scale.png)

Ratings displays are kept minimal. If you need to compose your ratings view into something else, it will overlay it just fine.

![Star rating on a custom background](http://www.patridgedev.com/cdn/pdrating/screenshots/custom-background.png)

##Other Configurations Options

###Between-item whitespace

Need some space between your rating items? Just set the `ItemPadding` in the `RatingConfig` object used to build the `PDRatingView`.

    // Put a little space between the rating items.
    ratingConfig.ItemPadding = 5f;

###Read-only (no user rating input)

If you are showing a rating without any intention of collecting a rating from the user, you can keep the rating view from taking any user input with the default iOS setting. As a result, this will keep it from ever triggering a `RatingChosen` event.

    // Only display the rating; don't allow user rating.
    ratingView.UserInteractionEnabled = false;
    
###Different rating scale size

Say you need users to rate things on a scale to ten. That can be changed in the `RatingConfig` object used to build the `PDRatingView`. The default is a 5-item scale of ratings.

    // Allow rating on a scale of 1 to 10.
    ratingConfig.ScaleSize = 10;
    
###Rounding of ratings to whole or half stars

If you want average ratings to display in half- or whole-star increments, that isn't currently built in to the `PDRatingView` system directly, but you can very easily use .NET to round appropriately before setting the view's `AverageRating` to reproduce the same result.

    decimal rating = 3.58m;
    decimal halfRoundedRating = Math.Round(rating * 2m, MidpointRounding.AwayFromZero) / 2m;
    decimal wholeRoundedRating = Math.Round(rating, MidpointRounding.AwayFromZero);
    StarRating.AverageRating = wholeRoundedRating;