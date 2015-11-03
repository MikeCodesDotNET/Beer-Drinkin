using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;

namespace BeerDrinkin.iOS
{
	partial class ParallaxTableHeader : UIImageView
	{
		public ParallaxTableHeader (IntPtr handle) : base (handle)
		{
		}

        public UIImageView ImageView;

        public UIImage Image {
            set { ImageView.Image = value; }
        }


        public ParallaxTableHeader (CGRect tableViewFrame, nfloat maxHeight)
        {
            Frame = new CGRect (0, 0, tableViewFrame.Width, maxHeight);

            ImageView = new UIImageView (new CGRect (0, maxHeight / 2, tableViewFrame.Width, maxHeight));
            ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;

            Add(ImageView);
        }


        public void UpdateOffset (nfloat offsetY)
        {
            var over = offsetY <= nfloat.Epsilon;

            ClipsToBounds = !over;

            ImageView.ClipsToBounds = over;

            var x = over ? offsetY : 0;
            var y = over ? offsetY : offsetY / 2.5f;
            var w = over ? Frame.Width + (NMath.Abs(offsetY) * 2) : Frame.Width;
            var h = over ? Frame.Height + NMath.Abs(offsetY) : Frame.Height;

            ImageView.Frame = new CGRect (x, y, w, h);
            }

	}
}
