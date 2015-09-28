using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

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
	}
}
