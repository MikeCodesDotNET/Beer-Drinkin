using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class BarCodeTableViewCell : UITableViewCell
	{
        public BarCodeTableViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public BarCodeTableViewCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
           
        }

        public string BarCodeNumber
        {
            get
            {
                return lblBarcodeNumber.Text;
            }
            set
            {
                lblBarcodeNumber.Text = value;
            }
        }

        partial void BtnAddBarcode_TouchUpInside(UIButton sender)
        {
            AddBarcode();
        }

        public delegate void AddBarcodeHandler();

        public event AddBarcodeHandler AddBarcode;
	}
}
