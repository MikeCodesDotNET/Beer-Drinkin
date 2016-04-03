using Foundation;
using System;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class BarcodeSearchTableViewCell : UITableViewCell
	{
		public BarcodeSearchTableViewCell (IntPtr handle) : base (handle)
		{
		}

        public BarcodeSearchTableViewCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            btnScan.Layer.CornerRadius = 4;
            btnScan.Layer.MasksToBounds = true; 
            
        }

		partial void BtnScan_TouchUpInside(UIButton sender)
		{
			ScanBeer();
		}

		public delegate void ScanBeerHandler();
		public event ScanBeerHandler ScanBeer;
	}
}
