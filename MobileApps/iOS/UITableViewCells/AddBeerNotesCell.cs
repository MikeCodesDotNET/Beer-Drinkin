using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class AddBeerNotesCell : UITableViewCell
	{
		public AddBeerNotesCell (IntPtr handle) : base (handle)
		{
		}

        public AddBeerNotesCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }
	}
}
