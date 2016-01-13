using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class RecentSearchesTableViewCell : UITableViewCell
	{
        public RecentSearchesTableViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public RecentSearchesTableViewCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }
	}
}
