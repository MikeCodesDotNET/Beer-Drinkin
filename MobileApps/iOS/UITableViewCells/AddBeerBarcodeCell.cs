using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class AddBeerBarcodeCell : UITableViewCell
	{
		public AddBeerBarcodeCell (IntPtr handle) : base (handle)
		{
		}

        public AddBeerBarcodeCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }
	}
}
