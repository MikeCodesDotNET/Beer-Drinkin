// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
    public partial class InAppPurchaseSearchTableViewCell : UITableViewCell
    {
		public InAppPurchaseSearchTableViewCell(IntPtr handle)
			: base(handle)
		{
		}

		public InAppPurchaseSearchTableViewCell(NSString cellId)
			: base(UITableViewCellStyle.Default, cellId)
		{
		}



		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			btnSnapAPhoto.Layer.CornerRadius = 4;
			btnSnapAPhoto.Layer.MasksToBounds = true;
			
		}

        partial void BtnSnapAPhoto_TouchUpInside(UIButton sender)
        {
            SnapPhotoButtonTapped();
        }

        partial void BtnLearnMore_TouchUpInside(UIButton sender)
		{
			LearnMoreButtonClick();
		}

		public delegate void SnapPhotoButtonTappedHandler();
		public event SnapPhotoButtonTappedHandler SnapPhotoButtonTapped;
    }
}