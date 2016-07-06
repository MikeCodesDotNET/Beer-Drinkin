using System;

using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.BeerDescription
{
    public partial class StarRatingTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("StarRatingTableViewCell");
        public static readonly UINib Nib;

        static StarRatingTableViewCell()
        {
            Nib = UINib.FromName("StarRatingTableViewCell", NSBundle.MainBundle);
        }

        protected StarRatingTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
