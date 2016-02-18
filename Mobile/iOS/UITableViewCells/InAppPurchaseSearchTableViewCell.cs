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

			btnLearnMore.Layer.CornerRadius = 4;
			btnLearnMore.Layer.MasksToBounds = true;

			btnLearnMore.TouchUpInside += delegate 
			{
				LearnMoreButtonClick();
			};
			
		}

		public delegate void LearnMoreButtonClickHandler();
		public event LearnMoreButtonClickHandler LearnMoreButtonClick;
    }
}