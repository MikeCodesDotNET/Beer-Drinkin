using Foundation;
using System;
using UIKit;

namespace BeerDrinkin.iOS
{
    public partial class StarRatingTableViewCell : UITableViewCell
    {
        public StarRatingTableViewCell(NSString cellId): base(UITableViewCellStyle.Default, cellId)
        { }

        public StarRatingTableViewCell (IntPtr handle) : base (handle)
        {
        }
    }
}