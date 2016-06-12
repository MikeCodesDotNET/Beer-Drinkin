using System;
using System.Linq;
using UIKit;

namespace CameraViewController.Views
{
	public class CropOverlay : UIView
	{

		UIView outerLines;
		UIView horizontalLines;
		UIView verticalLines;

		UIView topLeftCornerLines;
		UIView topRightCornerLines;
		UIView bottomLeftCornerLines;
		UIView bottomRightCornerLines;

		float cornerDepth = 3f;
		float cornerWidth = 20f;
		float lineWidth = 1;

		public CropOverlay()
		{
			CreateLines();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			CreateLines();
		}

		void CreateLines()
		{
			var size = Bounds.Size;
			UIView[] outerLines = new UIView[3];
			var i = 0;
			while(i != outerLines.Count())
			{
				var line = outerLines[i];
				CoreGraphics.CGRect lineFrame;
				switch (i)
				{
					case 0:
					lineFrame = new CoreGraphics.CGRect(0, 0, size.Width, lineWidth);
					break;
					case 1:
						lineFrame = new CoreGraphics.CGRect(size.Width - lineWidth, 0, lineWidth, size.Height);
					break;
					case 2:
						lineFrame = new CoreGraphics.CGRect(0, size.Height - lineWidth, size.Width, lineWidth);
					break;
					case 3:
						lineFrame = new CoreGraphics.CGRect(0, 0, lineWidth, size.Height);
					break;
					default:
						lineFrame = CoreGraphics.CGRect.Empty;
						break;
				}
				line.Frame = lineFrame;
				this.AddSubview(line);
				i++;
			}

			i = 0;

			UIView[] corners = new UIView[3];
			while(i != outerLines.Count())
			{
				var corner = corners[i];
				CoreGraphics.CGRect horizontalFrame = CoreGraphics.CGRect.Empty;
				CoreGraphics.CGRect verticalFrame = CoreGraphics.CGRect.Empty;

				switch (i)
				{
					case 0:
						verticalFrame = new CoreGraphics.CGRect(-cornerDepth, -cornerDepth, cornerDepth, cornerWidth);
						horizontalFrame = new CoreGraphics.CGRect(size.Width + cornerDepth - cornerWidth, -cornerDepth, cornerWidth, cornerDepth);
					break;
					case 1:
						verticalFrame = new CoreGraphics.CGRect(size.Width, -cornerDepth, cornerDepth, cornerWidth);
						horizontalFrame = new CoreGraphics.CGRect(size.Width + cornerDepth- cornerWidth, -cornerDepth, cornerWidth, cornerDepth);
						break;
					case 2:
						verticalFrame = new CoreGraphics.CGRect(-cornerDepth, size.Height + cornerDepth - cornerWidth, cornerDepth, cornerWidth);
						horizontalFrame = new CoreGraphics.CGRect(-cornerDepth, size.Height, cornerWidth, cornerDepth);
					break;
					case 3:
						verticalFrame = new CoreGraphics.CGRect(size.Width, size.Height + cornerDepth - cornerWidth, cornerDepth, cornerWidth);
						horizontalFrame = new CoreGraphics.CGRect(size.Width + cornerDepth - cornerWidth, size.Height, cornerWidth, cornerDepth);
					break;
					defaut:
						verticalFrame = CoreGraphics.CGRect.Empty;
						horizontalFrame = CoreGraphics.CGRect.Empty;
						break;
						
				}

				corners[0].Frame = verticalFrame;
				corners[1].Frame = horizontalFrame;
				i++;
			}

			var lineThickness = lineWidth / UIScreen.MainScreen.Scale;


		}	
	}
}

