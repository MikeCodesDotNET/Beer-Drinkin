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
            set { lblName.Text = value; }
        }

        public string Brewery
        {
            get { return lblBrewery.Text; }
            set { lblBrewery.Text = value; }
        }

        public string NumberOfServings
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

            imgLabel.Layer.CornerRadius = imgLabel.Frame.Width / 2;
            imgLabel.Layer.MasksToBounds = true;

            sideColor.Alpha = 0f;
        }
    }
}