using System;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS
{
    partial class MyBeersTableViewCell : SWTableViewCell.SWTableViewCell
    {
        public MyBeersTableViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public MyBeersTableViewCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }


        public string Name
        {
            get { return lblName.Text; }
            set 
            { 
                lblName.Text = value; 
                lblName.SizeToFit();
                this.LayoutIfNeeded();
            }
        }

        public string Brewery
        {
            get { return lblBrewery.Text; }
            set 
            { 
                lblBrewery.Text = value; 
                lblBrewery.SizeToFit();
                this.LayoutIfNeeded();
            }
        }
        public string BeerCount
        {
            get { return lblNumberOfServings.Text; }
            set { lblNumberOfServings.Text = value; }
        }

        public UIImageView Image
        {
            get { return imgLabel; }
            set { imgLabel = value; }
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            sideColor.Alpha = 0f;   

            imgLabel.Layer.CornerRadius = 5;
            imgLabel.Layer.BorderColor = Color.OffWhite.ToNative().CGColor;
            imgLabel.Layer.BorderWidth = 0.8f;
            imgLabel.Layer.MasksToBounds = true;

        }
    }
}