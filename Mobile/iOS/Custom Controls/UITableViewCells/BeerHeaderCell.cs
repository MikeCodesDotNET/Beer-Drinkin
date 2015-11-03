using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace BeerDrinkin.iOS
{
    partial class BeerHeaderCell : UITableViewCell
    {
        public BeerHeaderCell(IntPtr handle)
            : base(handle)
        {
        }

        public BeerHeaderCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }

        public string Name
        {
            get { return lblName.Text; }
            set
            {
                lblName.Text = value;
                SetNeedsDisplay();
            }
        }

        public string Brewery
        {
            get { return lblBrewery.Text; }
            set
            {
                lblBrewery.Text = value;
                SetNeedsDisplay();
            }
        }

        public string Abv
        {
            get { return lblAbv.Text; }
            set
            {
                lblAbv.Text = value;
                SetNeedsDisplay();
            }
        }

        public string Consumed
        {
            get { return lblConsumed.Text; }
            set
            {
                lblConsumed.Text = value;
                SetNeedsDisplay();
            }
        }

        public string Rating
        {
            get { return lblRating.Text; }
            set
            {
                lblRating.Text = value;
                SetNeedsDisplay();
            }
        }

        public nfloat RatingAlpha
        {
            get { return lblRating.Alpha; }
            set
            {
                lblRating.Alpha = value;
                lblRatingTitle.Alpha = value;
                SetNeedsDisplay();
            }
        }

        public nfloat ConsumedAlpha
        {
            get { return lblConsumed.Alpha; }
            set
            {
                lblConsumed.Alpha = value;
                lblConsumedTitle.Alpha = value;
                SetNeedsDisplay();
            } 
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            Helpers.Animator.GrowDivider(divider, this);
        }
    }
}