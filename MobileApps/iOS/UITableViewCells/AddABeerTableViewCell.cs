using System;
using UIKit;
using Foundation;

namespace BeerDrinkin.iOS
{
    public partial class AddABeerTableViewCell : UITableViewCell
    {
        public AddABeerTableViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public AddABeerTableViewCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }

    }
}