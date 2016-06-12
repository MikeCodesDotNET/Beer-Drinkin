using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class AddBeerRatingCell : UITableViewCell
	{
		public AddBeerRatingCell (IntPtr handle) : base (handle)
		{
		}

        public AddBeerRatingCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }
	}
}
