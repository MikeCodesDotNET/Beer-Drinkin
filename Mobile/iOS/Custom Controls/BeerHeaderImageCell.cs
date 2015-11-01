using System;
using Foundation;
using UIKit;
using BeerDrinkin.iOS.Helpers;

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

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            imgLogo.Alpha = 0;
            imgLogo.FadeIn(0.6, 0.2f);
        }
    }
}