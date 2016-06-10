using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using BeerDrinkin.iOS.CustomControls;

namespace BeerDrinkin.iOS
{
	partial class SearchHeaderViewCell : UITableViewCell
	{
        public SearchHeaderViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public SearchHeaderViewCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }

        public string Title 
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

        public BeerDrinkin.iOS.CustomControls.SearchCellBackgroundType BackgroundType
        {
            get
            {
                return BackgroundType;
            }
            set
            {
                BackgroundType = value;
            }
        }
	}
}
