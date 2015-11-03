using System;
using Foundation;
using UIKit;
using BeerDrinkin.iOS.Helpers;
using CoreGraphics;

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

            imgLogo.ContentMode = UIViewContentMode.ScaleAspectFill;

        }

        public void UpdateOffset (nfloat offsetY)
        {
            var over = offsetY <= nfloat.Epsilon;

            ClipsToBounds = !over;

            ImageView.ClipsToBounds = over;

            var x = over ? offsetY : 0;
            var y = over ? offsetY : offsetY / 2.5f;
            var w = over ? Frame.Width + (NMath.Abs(offsetY) * 2) : Frame.Width;
            var h = over ? Frame.Height + NMath.Abs(offsetY) : Frame.Height;

            imgLogo.Frame = new CGRect (x, y, w, h);
        }
    }
}