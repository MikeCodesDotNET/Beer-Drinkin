using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	partial class BeerDescriptionCheckInCell : UITableViewCell
	{
        public BeerDescriptionCheckInCell(IntPtr handle)
            : base(handle)
        {                
        }

        public BeerDescriptionCheckInCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {  
        } 
    }
}
