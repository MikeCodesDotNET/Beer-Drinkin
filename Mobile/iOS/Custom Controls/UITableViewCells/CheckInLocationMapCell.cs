using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
    partial class CheckInLocationMapCell : UITableViewCell
    {
        public CheckInLocationMapCell(IntPtr handle)
            : base(handle)
        {
        }

        public CheckInLocationMapCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
            if (mapView == null)
            {
                mapView = new MapKit.MKMapView(new CoreGraphics.CGRect(0, 0, Frame.Width, 200));
                Add(mapView);
            }
        }

        public MapKit.MKMapView MapView
        {
            get
            {
                return this.mapView;
            }
            set
            {
                this.mapView = value;
                SetNeedsDisplay();
            }
        }
    }
}
