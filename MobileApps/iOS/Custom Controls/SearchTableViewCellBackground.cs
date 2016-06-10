using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Drawing;

namespace BeerDrinkin.iOS.CustomControls
{
	[Register("SearchTableViewCellBackground"), DesignTimeVisible(true)]
    public class SearchTableViewCellBackground : UIView
    {
        public SearchTableViewCellBackground()
        {
        }

		public SearchTableViewCellBackground(IntPtr p) : base(p)
		{
		}

        void Init()
        {
            backgroundType = SearchCellBackgroundType.Header;
        }

		SearchCellBackgroundType backgroundType;

		[Export("Header"), Browsable(true)]
        public bool Header
		{
			get 
            { 
                if(backgroundType == SearchCellBackgroundType.Header)
                    return true;

                return false;
            }
			set
			{
				backgroundType = SearchCellBackgroundType.Header;
				SetNeedsDisplay();
			}
		}

        [Export("Default"), Browsable(true)]
        public bool Default
        {
            get 
            { 
                if(backgroundType == SearchCellBackgroundType.Default)
                    return true;

                return false;
            }
            set
            {
                backgroundType = SearchCellBackgroundType.Default;
                SetNeedsDisplay();
            }
        }

        [Export("Footer"), Browsable(true)]
        public bool Footer
        {
            get 
            { 
                if(backgroundType == SearchCellBackgroundType.Footer)
                    return true;

                return false;
            }
            set
            {
                backgroundType = SearchCellBackgroundType.Footer;
                SetNeedsDisplay();
            }
        }



		public override void Draw(CGRect frame)
		{
            this.BackgroundColor = UIColor.Clear;

			var borderColor = UIColor.FromRGBA(0.808f, 0.808f, 0.808f, 1.000f);
			if (backgroundType == SearchCellBackgroundType.Header)
			{
                
                var rectanglePath = UIBezierPath.FromRoundedRect(new CGRect(frame.GetMinX() + 0.5f, frame.GetMinY() + 0.5f, frame.Width - 1.0f, frame.Height), UIRectCorner.TopLeft | UIRectCorner.TopRight, new SizeF(4.0f, 4.0f));
                rectanglePath.ClosePath();
                UIColor.White.SetFill();
                rectanglePath.Fill();
                borderColor.SetStroke();
                rectanglePath.LineWidth = 1.0f;
                rectanglePath.Stroke();

                var rectangle2Path = UIBezierPath.FromRect(new CGRect(frame.GetMinX() + 1.5f, frame.GetMinY() + NMath.Floor((frame.Height - 0.5f) * 0.76471f) + 0.5f, frame.Width - 3.0f, frame.Height - 1.0f - NMath.Floor((frame.Height - 0.5f) * 0.76471f)));
                UIColor.White.SetFill();
                rectangle2Path.Fill();
                UIColor.White.SetStroke();
                rectangle2Path.LineWidth = 1.0f;
                rectangle2Path.Stroke();
			}

			if (backgroundType == SearchCellBackgroundType.Default)
			{
                var rectanglePath = UIBezierPath.FromRect(new CGRect(frame.GetMinX() + 0.5f, frame.GetMinY() + 0.5f, frame.Width - 1.0f, frame.Height));
                UIColor.White.SetFill();
                rectanglePath.Fill();
                borderColor.SetStroke();
                rectanglePath.LineWidth = 1.0f;
                rectanglePath.Stroke();

                var rectangle2Path = UIBezierPath.FromRect(new CGRect(frame.GetMinX() + 1.5f, frame.GetMinY() + NMath.Floor((frame.Height - 0.5f) * 0.76471f) + 0.5f, frame.Width - 3.0f, frame.Height - 1.0f - NMath.Floor((frame.Height - 0.5f) * 0.76471f)));
                UIColor.White.SetFill();
                rectangle2Path.Fill();
                UIColor.White.SetStroke();
                rectangle2Path.LineWidth = 1.0f;
                rectangle2Path.Stroke();
			}		

			if (backgroundType == SearchCellBackgroundType.Footer)
            {
                var rectanglePath = UIBezierPath.FromRoundedRect(new CGRect(frame.GetMinX() + 0.5f, frame.GetMinY() + 0.5f, frame.Width - 1.0f, frame.Height - 1.0f), UIRectCorner.BottomLeft | UIRectCorner.BottomRight, new SizeF(4.0f, 4.0f));
                rectanglePath.ClosePath();
                UIColor.White.SetFill();
                rectanglePath.Fill();
                borderColor.SetStroke();
                rectanglePath.LineWidth = 1.0f;
                rectanglePath.Stroke();
			}
		}
    }

	public enum SearchCellBackgroundType
	{
		Header,
		Default,
		Footer
	}
}

