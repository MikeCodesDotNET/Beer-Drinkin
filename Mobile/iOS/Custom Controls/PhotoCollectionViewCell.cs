using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Color = BeerDrinkin.Helpers.Colours;
using Splat;


namespace BeerDrinkin.iOS
{
	partial class PhotoCollectionViewCell : UICollectionViewCell
	{
		public PhotoCollectionViewCell (IntPtr handle) : base (handle)
		{
		}

        public UIImageView ImageView
        {
            get
            {
                return imgPhoto;
            }
            set
            {
                imgPhoto = value;
            }
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.BackgroundColor = UIColor.Clear;

            ImageView.BackgroundColor = UIColor.Clear;

            ImageView.Layer.CornerRadius = 5;
            ImageView.Layer.BorderColor = Color.OffWhite.ToNative().CGColor;
            ImageView.Layer.BorderWidth = 0.8f;
            ImageView.Layer.MasksToBounds = true;
        }
	}
}
