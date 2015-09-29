using System;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace SWTableViewCellSample
{
	partial class UMTableViewCell : SWTableViewCell.SWTableViewCell
	{
		public UMTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public UILabel Label
		{
			get { return label; }
		}
	}
}
