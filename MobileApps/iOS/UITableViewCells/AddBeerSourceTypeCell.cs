using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class AddBeerSourceTypeCell : UITableViewCell
	{
		public AddBeerSourceTypeCell (IntPtr handle) : base (handle)
		{
		}

        public AddBeerSourceTypeCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }
	}
}
