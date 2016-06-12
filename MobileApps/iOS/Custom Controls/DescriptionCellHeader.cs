using System;
using UIKit;
using Foundation;
using System.ComponentModel;
using CoreGraphics;
using System.Drawing;

namespace BeerDrinkin.iOS.CustomControls
{
    [Register("DescriptionCellHeader"), DesignTimeVisible(true)]
    public class DescriptionCellHeader : UIView
    {
        public DescriptionCellHeader(IntPtr p)
            : base(p)
        {
            Initialize();
        }

        public DescriptionCellHeader()
        {
            Initialize();
        }

        void Initialize()
        {          
            header = "description";
        }


        string header;

        [Export("Header"), Browsable(true)]
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
                SetNeedsDisplay();
            }
        }

        public override void Draw(CGRect frame)
        {
            //// General Declarations
            var context = UIGraphics.GetCurrentContext();

            //// Rectangle Drawing
            var rectanglePath = UIBezierPath.FromRoundedRect(new CGRect(frame.GetMinX() + 14.0f, frame.GetMinY() + 2.0f, NMath.Floor((frame.Width - 14.0f) * 0.20776f + 0.5f), 21.0f), UIRectCorner.TopLeft | UIRectCorner.TopRight, new SizeF(4.0f, 4.0f));
            rectanglePath.ClosePath();
            Helpers.Colours.Green.SetFill();
            rectanglePath.Fill();


            //// Rectangle 2 Drawing
            var rectangle2Path = UIBezierPath.FromRect(new CGRect(frame.GetMinX(), frame.GetMinY() + 23.0f, 375.0f, 1.0f));
            Helpers.Colours.Green.SetFill();
            rectangle2Path.Fill();


            //// Text Drawing
            CGRect textRect = new CGRect(frame.GetMinX() + NMath.Floor(frame.Width * 0.03733f + 0.5f), frame.GetMinY() + 3.0f, NMath.Floor(frame.Width * 0.23733f + 0.5f) - NMath.Floor(frame.Width * 0.03733f + 0.5f), 21.0f);
            UIColor.White.SetFill();
            var textStyle = new NSMutableParagraphStyle();
            textStyle.Alignment = UITextAlignment.Center;

            var textFontAttributes = new UIStringAttributes() { Font = UIFont.FromName("Avenir-Medium", UIFont.SmallSystemFontSize), ForegroundColor = UIColor.White, ParagraphStyle = textStyle };
            var textTextHeight = new NSString(header).GetBoundingRect(new CGSize(textRect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, textFontAttributes, null).Height;
            context.SaveState();
            context.ClipToRect(textRect);
            new NSString(header).DrawString(new CGRect(textRect.GetMinX(), textRect.GetMinY() + (textRect.Height - textTextHeight) / 2.0f, textRect.Width, textTextHeight), UIFont.FromName("Avenir-Medium", UIFont.SmallSystemFontSize), UILineBreakMode.WordWrap, UITextAlignment.Center);
            context.RestoreState();

        }
    }
}

