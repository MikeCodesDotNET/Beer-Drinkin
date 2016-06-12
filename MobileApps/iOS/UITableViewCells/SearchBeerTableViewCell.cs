using System;
using Foundation;
using UIKit;
using Splat;


namespace BeerDrinkin.iOS
{
    partial class SearchBeerTableViewCell : UITableViewCell
    {
        private bool checkedIn;

        public SearchBeerTableViewCell(IntPtr handle) : base(handle) { }
        public SearchBeerTableViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId) { }

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

        public string Style
        {
            get { return lblStyle.Text; }
            set { lblStyle.Text = value; }
        }

        public bool isCheckedIn
        {
            get { return checkedIn; }
            set
            {
                checkedIn = value;
            }
        }

        public UIImageView Image
        {
            get { return imgLabel; }
            set { imgLabel = value; }
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            
            imgLabel.Layer.CornerRadius = 5;
            imgLabel.Layer.BorderColor = UIColor.White.CGColor;
            imgLabel.Layer.BorderWidth = 0.8f;
            imgLabel.Layer.MasksToBounds = true;

            //ShowRightUtilityButtons(false);
        }
    }
}