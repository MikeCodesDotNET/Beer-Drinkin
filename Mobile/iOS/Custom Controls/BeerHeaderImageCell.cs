using System;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS
{
    partial class BeerHeaderImageCell : UITableViewCell
    {
        public BeerHeaderImageCell(IntPtr handle)
            : base(handle)
        {
        }

        public BeerHeaderImageCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }

        public UIImageView LogoImageView
        {
            get { return imgLogo; }
            set
            {
                imgLogo = value;
                SetNeedsDisplay();
            }
        }

        public UIScrollView ScrollView
        {
            get { return scrollView; }
            set
            {
                scrollView = value;
                SetNeedsDisplay();
            }
        }
    }
}