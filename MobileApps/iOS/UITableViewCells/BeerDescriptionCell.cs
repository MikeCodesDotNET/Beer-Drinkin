using System;
using CoreGraphics;
using Foundation;
using UIKit;
using CoreAnimation;

using MikeCodesDotNET.iOS;

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
            tbxDescription.Alpha = 0;
        }

        public bool IsTextVisible
        {
            get
            {
                if (tbxDescription.Alpha == 0)
                    return false;
                else
                    return true;
            }
            set
            {
                if(value == false)
                {
                   tbxDescription.FadeSubviewsOut(0.5, 0);
                }
                else
                {
                    tbxDescription.FadeSubviewsIn(0.5, 0);
                }
            }
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

    }
}