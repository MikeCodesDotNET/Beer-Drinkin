using System;
using Foundation;
using UIKit;
using Splat;
using Color = BeerDrinkin.Helpers.Colours;


namespace BeerDrinkin.iOS
{
    partial class SearchBeerTableViewCell : SWTableViewCell.SWTableViewCell
    {
        private bool checkedIn;

        public SearchBeerTableViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public SearchBeerTableViewCell(NSString cellId)
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
                sideColor.Alpha = !value ? 0f : 1f;
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
            
            imgLabel.Layer.CornerRadius = imgLabel.Frame.Width / 2;
            imgLabel.Layer.BorderColor = Color.Gray.ToNative().CGColor;
            imgLabel.Layer.BorderWidth = 1.5f;
            imgLabel.Layer.MasksToBounds = true;

            sideColor.Alpha = 0f;
            ShowRightUtilityButtons(false);
        }
    }
}