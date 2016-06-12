using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class AddBeerPhotosCell : UITableViewCell
	{
		public AddBeerPhotosCell (IntPtr handle) : base (handle)
		{
        }

        public AddBeerPhotosCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }
	}
}
