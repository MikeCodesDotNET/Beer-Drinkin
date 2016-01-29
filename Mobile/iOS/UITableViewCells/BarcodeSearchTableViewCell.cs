using Foundation;
using System;
using System.CodeDom.Compiler;
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

            btnClear.Layer.CornerRadius = 4;
            btnClear.Layer.MasksToBounds = true;
        }
	}
}
