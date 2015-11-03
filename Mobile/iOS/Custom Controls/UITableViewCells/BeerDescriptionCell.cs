using System;
using CoreGraphics;
using Foundation;
using UIKit;
using CoreAnimation;

namespace BeerDrinkin.iOS
{
    partial class BeerDescriptionCell : UITableViewCell
    {
        public BeerDescriptionCell(IntPtr handle)
            : base(handle)
        {
        }

        public BeerDescriptionCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
            tbxDescription.ScrollEnabled = false;
            tbxDescription.AlwaysBounceVertical = false;
        }

        public string Text
        {
            get { return tbxDescription.Text; }
            set { tbxDescription.Text = value; }
        }

        public nfloat PreferredHeight
        {
            get { return tbxDescription.SizeThatFits(new CGSize(tbxDescription.Frame.Width, float.MaxValue)).Height; }
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            Helpers.Animator.GrowDivider(divider, this);
        }
    }
}