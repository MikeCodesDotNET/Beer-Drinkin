using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using BeerDrinkin.iOS.CustomControls;

namespace BeerDrinkin.iOS
{
	partial class NoRecentSearchesViewCell : UITableViewCell
	{
        public NoRecentSearchesViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public NoRecentSearchesViewCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }

		public string Text
		{
			get
			{
				return lblTitle.Text;
			}
			set
			{
				lblTitle.Text = value;
			}
		}

		public SearchTableViewCellBackground Background
		{
			get
			{
				return background;
			}
			set
			{
				background = value;
			}
		}

	}
}
