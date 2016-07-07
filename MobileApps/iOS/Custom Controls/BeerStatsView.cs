using System;
using UIKit;
using System.ComponentModel;
using Foundation;
using CoreGraphics;

namespace BeerDrinkin.iOS.CustomControls
{
    [Register("BeerStatsView"), DesignTimeVisible(true)]
    public class BeerStatsView : UIView
    {
        public BeerStatsView()
        {
        }

        public BeerStatsView(IntPtr handle) : base (handle)
        {
        }

        string _name;
        [Export("Name"), Browsable(true)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                SetNeedsDisplay();
            }
        }

        string _country;
        [Export("Country"), Browsable(true)]
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                SetNeedsDisplay();
            }
        }

        string _abv;
        [Export("ABV"), Browsable(true)]
        public string ABV
        {
            get
            {
                return _abv;
            }
            set
            {
                _abv = $"{value}%"; ;
                SetNeedsDisplay();
            }
        }

        string _ibu;
        [Export("IBU"), Browsable(true)]
        public string IBU
        {
            get
            {
                return _ibu;
            }
            set
            {
                _ibu = $"{value}%"; ;
                SetNeedsDisplay();
            }
        }

        string _srm;
        [Export("SRM"), Browsable(true)]
        public string SRM
        {
            get
            {
                return _srm;
            }
            set
            {
                _srm = $"{value}%";
                SetNeedsDisplay();
            }
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            BackgroundColor = UIColor.Clear;

            if (string.IsNullOrEmpty(_name))
                _name = "Beer Drinkin";
            if (string.IsNullOrEmpty(_country))
                _country = "United Kingdom";
            if (string.IsNullOrEmpty(_abv))
                _abv = "N/A ";
            if (string.IsNullOrEmpty(_ibu))
                _ibu = "N/A ";
            if (string.IsNullOrEmpty(_srm))
                _srm = "N/A ";

            DrawControl(rect, _name, _country, _abv, _ibu, _srm);
        }

        void DrawControl(CGRect frame, string name, string country, string abv, string ibu, string srm)
        {
            BackgroundColor = UIColor.Clear;
            Layer.BackgroundColor = UIColor.Clear.CGColor;

            //// General Declarations
            var context = UIGraphics.GetCurrentContext();

            //// Color Declarations
            var fillColor = UIColor.FromRGBA(0.110f, 0.122f, 0.153f, 1.000f);
            var textForeground = UIColor.FromRGBA(1.000f, 1.000f, 1.000f, 1.000f);
            var fillColor2 = UIColor.FromRGBA(0.773f, 0.816f, 0.871f, 1.000f);
            var textForeground2 = UIColor.FromRGBA(0.773f, 0.816f, 0.871f, 1.000f);
            var fillColor3 = UIColor.FromRGBA(0.169f, 0.188f, 0.231f, 1.000f);

            //// Bezier Drawing
            UIBezierPath bezierPath = new UIBezierPath();
            bezierPath.MoveTo(new CGPoint(frame.GetMinX() + 0.00145f * frame.Width, frame.GetMinY() + 0.04170f * frame.Height));
            bezierPath.AddCurveToPoint(new CGPoint(frame.GetMinX() + 0.01299f * frame.Width, frame.GetMinY() + 0.00467f * frame.Height), new CGPoint(frame.GetMinX() + 0.00145f * frame.Width, frame.GetMinY() + 0.02125f * frame.Height), new CGPoint(frame.GetMinX() + 0.00664f * frame.Width, frame.GetMinY() + 0.00467f * frame.Height));
            bezierPath.AddLineTo(new CGPoint(frame.GetMinX() + 0.98701f * frame.Width, frame.GetMinY() + 0.00467f * frame.Height));
            bezierPath.AddCurveToPoint(new CGPoint(frame.GetMinX() + 0.99855f * frame.Width, frame.GetMinY() + 0.04170f * frame.Height), new CGPoint(frame.GetMinX() + 0.99338f * frame.Width, frame.GetMinY() + 0.00467f * frame.Height), new CGPoint(frame.GetMinX() + 0.99855f * frame.Width, frame.GetMinY() + 0.02125f * frame.Height));
            bezierPath.AddLineTo(new CGPoint(frame.GetMinX() + 0.99855f * frame.Width, frame.GetMinY() + 0.95830f * frame.Height));
            bezierPath.AddCurveToPoint(new CGPoint(frame.GetMinX() + 0.98701f * frame.Width, frame.GetMinY() + 0.99533f * frame.Height), new CGPoint(frame.GetMinX() + 0.99855f * frame.Width, frame.GetMinY() + 0.97875f * frame.Height), new CGPoint(frame.GetMinX() + 0.99336f * frame.Width, frame.GetMinY() + 0.99533f * frame.Height));
            bezierPath.AddLineTo(new CGPoint(frame.GetMinX() + 0.01299f * frame.Width, frame.GetMinY() + 0.99533f * frame.Height));
            bezierPath.AddCurveToPoint(new CGPoint(frame.GetMinX() + 0.00145f * frame.Width, frame.GetMinY() + 0.95830f * frame.Height), new CGPoint(frame.GetMinX() + 0.00662f * frame.Width, frame.GetMinY() + 0.99533f * frame.Height), new CGPoint(frame.GetMinX() + 0.00145f * frame.Width, frame.GetMinY() + 0.97875f * frame.Height));
            bezierPath.AddLineTo(new CGPoint(frame.GetMinX() + 0.00145f * frame.Width, frame.GetMinY() + 0.04170f * frame.Height));
            bezierPath.ClosePath();
            bezierPath.LineJoinStyle = CGLineJoin.Round;

            bezierPath.UsesEvenOddFillRule = true;

            fillColor.SetFill();
            bezierPath.Fill();
            fillColor3.SetStroke();
            bezierPath.LineWidth = 0.5f;
            bezierPath.Stroke();


            //// lblName Drawing
            CGRect lblNameRect = new CGRect(frame.GetMinX() + 13.25f, frame.GetMinY() + 9.45f, frame.Width - 23.25f, NMath.Floor((frame.Height - 9.45f) * 0.31777f + 9.39f) - 8.89f);
            textForeground.SetFill();
            var lblNameStyle = new NSMutableParagraphStyle();
            lblNameStyle.Alignment = UITextAlignment.Left;

            var lblNameFontAttributes = new UIStringAttributes() { Font = UIFont.FromName("Avenir-Heavy", 18.0f), ForegroundColor = textForeground, ParagraphStyle = lblNameStyle };
            var lblNameTextHeight = new NSString(name).GetBoundingRect(new CGSize(lblNameRect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, lblNameFontAttributes, null).Height;
            context.SaveState();
            context.ClipToRect(lblNameRect);
            new NSString(name).DrawString(new CGRect(lblNameRect.GetMinX(), lblNameRect.GetMinY() + (lblNameRect.Height - lblNameTextHeight) / 2.0f, lblNameRect.Width, lblNameTextHeight), UIFont.FromName("Avenir-Heavy", 18.0f), UILineBreakMode.WordWrap, UITextAlignment.Left);
            context.RestoreState();


            //// Bezier 2 Drawing
            UIBezierPath bezier2Path = new UIBezierPath();
            bezier2Path.MoveTo(new CGPoint(frame.GetMinX() + 18.25f, frame.GetMinY() + 39.0f));
            bezier2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 15.0f, frame.GetMinY() + 42.08f), new CGPoint(frame.GetMinX() + 16.46f, frame.GetMinY() + 39.0f), new CGPoint(frame.GetMinX() + 15.0f, frame.GetMinY() + 40.38f));
            bezier2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 18.26f, frame.GetMinY() + 46.96f), new CGPoint(frame.GetMinX() + 15.0f, frame.GetMinY() + 44.42f), new CGPoint(frame.GetMinX() + 17.63f, frame.GetMinY() + 46.96f));
            bezier2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 21.5f, frame.GetMinY() + 42.08f), new CGPoint(frame.GetMinX() + 18.89f, frame.GetMinY() + 46.96f), new CGPoint(frame.GetMinX() + 21.5f, frame.GetMinY() + 44.42f));
            bezier2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 18.25f, frame.GetMinY() + 39.0f), new CGPoint(frame.GetMinX() + 21.5f, frame.GetMinY() + 40.38f), new CGPoint(frame.GetMinX() + 20.05f, frame.GetMinY() + 39.0f));
            bezier2Path.ClosePath();
            bezier2Path.MoveTo(new CGPoint(frame.GetMinX() + 18.25f, frame.GetMinY() + 43.98f));
            bezier2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 20.0f, frame.GetMinY() + 42.23f), new CGPoint(frame.GetMinX() + 19.22f, frame.GetMinY() + 43.98f), new CGPoint(frame.GetMinX() + 20.0f, frame.GetMinY() + 43.2f));
            bezier2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 18.25f, frame.GetMinY() + 40.49f), new CGPoint(frame.GetMinX() + 20.0f, frame.GetMinY() + 41.27f), new CGPoint(frame.GetMinX() + 19.22f, frame.GetMinY() + 40.49f));
            bezier2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 16.5f, frame.GetMinY() + 42.23f), new CGPoint(frame.GetMinX() + 17.28f, frame.GetMinY() + 40.49f), new CGPoint(frame.GetMinX() + 16.5f, frame.GetMinY() + 41.27f));
            bezier2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 18.25f, frame.GetMinY() + 43.98f), new CGPoint(frame.GetMinX() + 16.5f, frame.GetMinY() + 43.2f), new CGPoint(frame.GetMinX() + 17.28f, frame.GetMinY() + 43.98f));
            bezier2Path.ClosePath();
            bezier2Path.UsesEvenOddFillRule = true;

            fillColor2.SetFill();
            bezier2Path.Fill();


            //// lblCountry Drawing
            CGRect lblCountryRect = new CGRect(frame.GetMinX() + 24.0f, frame.GetMinY() + 31.0f, frame.Width - 34.0f, NMath.Floor((frame.Height - 31.0f) * 0.30263f + 0.5f));
            textForeground2.SetFill();
            var lblCountryStyle = new NSMutableParagraphStyle();
            lblCountryStyle.Alignment = UITextAlignment.Left;

            var lblCountryFontAttributes = new UIStringAttributes() { Font = UIFont.FromName("Avenir-Medium", 13.0f), ForegroundColor = textForeground2, ParagraphStyle = lblCountryStyle };
            var lblCountryTextHeight = new NSString(country).GetBoundingRect(new CGSize(lblCountryRect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, lblCountryFontAttributes, null).Height;
            context.SaveState();
            context.ClipToRect(lblCountryRect);
            new NSString(country).DrawString(new CGRect(lblCountryRect.GetMinX(), lblCountryRect.GetMinY() + (lblCountryRect.Height - lblCountryTextHeight) / 2.0f, lblCountryRect.Width, lblCountryTextHeight), UIFont.FromName("Avenir-Medium", 13.0f), UILineBreakMode.WordWrap, UITextAlignment.Left);
            context.RestoreState();


            //// Rectangle 3 Drawing
            var rectangle3Path = UIBezierPath.FromRect(new CGRect(frame.GetMinX(), frame.GetMinY() + NMath.Floor((frame.Height - 40.0f) * 0.98507f + 0.5f), frame.Width, frame.Height - 40.0f - NMath.Floor((frame.Height - 40.0f) * 0.98507f + 0.5f)));
            fillColor3.SetFill();
            rectangle3Path.Fill();


            //// Rectangle 4 Drawing
            var rectangle4Path = UIBezierPath.FromRect(new CGRect(frame.GetMinX() + 114.3f, frame.GetMinY() + NMath.Floor((frame.Height) * 0.62804f + 0.5f), NMath.Floor((frame.Width - 114.3f) * 0.00433f + 0.5f), frame.Height - NMath.Floor((frame.Height) * 0.62804f + 0.5f)));
            fillColor3.SetFill();
            rectangle4Path.Fill();


            //// Rectangle 5 Drawing
            var rectangle5Path = UIBezierPath.FromRect(new CGRect(frame.GetMinX() + NMath.Floor((frame.Width - 114.25f) * 0.99567f - 0.25f) + 0.75f, frame.GetMinY() + NMath.Floor((frame.Height) * 0.62804f + 0.5f), frame.Width - 115.0f - NMath.Floor((frame.Width - 114.25f) * 0.99567f - 0.25f), frame.Height - NMath.Floor((frame.Height) * 0.62804f + 0.5f)));
            fillColor3.SetFill();
            rectangle5Path.Fill();


            //// lblAbv Drawing
            CGRect lblAbvRect = new CGRect(frame.GetMinX() + NMath.Floor(frame.Width * -0.00000f - 0.5f) + 1.0f, frame.GetMinY() + NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f) + 0.81f, NMath.Floor(frame.Width * 0.16812f - 0.5f) - NMath.Floor(frame.Width * -0.00000f - 0.5f), frame.Height - 12.63f - NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f));
            textForeground2.SetFill();
            var lblAbvStyle = new NSMutableParagraphStyle();
            lblAbvStyle.Alignment = UITextAlignment.Right;

            var lblAbvFontAttributes = new UIStringAttributes() { Font = UIFont.FromName("Avenir-Heavy", 12.0f), ForegroundColor = textForeground2, ParagraphStyle = lblAbvStyle };
            var lblAbvTextHeight = new NSString(abv).GetBoundingRect(new CGSize(lblAbvRect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, lblAbvFontAttributes, null).Height;
            context.SaveState();
            context.ClipToRect(lblAbvRect);
            new NSString(abv).DrawString(new CGRect(lblAbvRect.GetMinX(), lblAbvRect.GetMinY() + (lblAbvRect.Height - lblAbvTextHeight) / 2.0f, lblAbvRect.Width, lblAbvTextHeight), UIFont.FromName("Avenir-Heavy", 12.0f), UILineBreakMode.WordWrap, UITextAlignment.Right);
            context.RestoreState();


            //// Label 4 Drawing
            CGRect label4Rect = new CGRect(frame.GetMinX() + NMath.Floor((frame.Width - 231.0f) * 0.52961f + 0.12f) + 0.38f, frame.GetMinY() + NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f) + 0.81f, frame.Width - 231.38f - NMath.Floor((frame.Width - 231.0f) * 0.52961f + 0.12f), frame.Height - 12.63f - NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f));
            {
                var textContent = "ABV";
                textForeground.SetFill();
                var label4Style = new NSMutableParagraphStyle();
                label4Style.Alignment = UITextAlignment.Left;

                var label4FontAttributes = new UIStringAttributes() { Font = UIFont.FromName("Avenir-Heavy", 12.0f), ForegroundColor = textForeground, ParagraphStyle = label4Style };
                var label4TextHeight = new NSString(textContent).GetBoundingRect(new CGSize(label4Rect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, label4FontAttributes, null).Height;
                context.SaveState();
                context.ClipToRect(label4Rect);
                new NSString(textContent).DrawString(new CGRect(label4Rect.GetMinX(), label4Rect.GetMinY() + (label4Rect.Height - label4TextHeight) / 2.0f, label4Rect.Width, label4TextHeight), UIFont.FromName("Avenir-Heavy", 12.0f), UILineBreakMode.WordWrap, UITextAlignment.Left);
                context.RestoreState();
            }


            //// lblIbu Drawing
            CGRect lblIbuRect = new CGRect(frame.GetMinX() + NMath.Floor(frame.Width * 0.33623f + 0.5f), frame.GetMinY() + NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f) + 0.81f, NMath.Floor(frame.Width * 0.49855f + 0.5f) - NMath.Floor(frame.Width * 0.33623f + 0.5f), frame.Height - 12.63f - NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f));
            textForeground2.SetFill();
            var lblIbuStyle = new NSMutableParagraphStyle();
            lblIbuStyle.Alignment = UITextAlignment.Right;

            var lblIbuFontAttributes = new UIStringAttributes() { Font = UIFont.FromName("Avenir-Heavy", 12.0f), ForegroundColor = textForeground2, ParagraphStyle = lblIbuStyle };
            var lblIbuTextHeight = new NSString(ibu).GetBoundingRect(new CGSize(lblIbuRect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, lblIbuFontAttributes, null).Height;
            context.SaveState();
            context.ClipToRect(lblIbuRect);
            new NSString(ibu).DrawString(new CGRect(lblIbuRect.GetMinX(), lblIbuRect.GetMinY() + (lblIbuRect.Height - lblIbuTextHeight) / 2.0f, lblIbuRect.Width, lblIbuTextHeight), UIFont.FromName("Avenir-Heavy", 12.0f), UILineBreakMode.WordWrap, UITextAlignment.Right);
            context.RestoreState();


            //// Label 6 Drawing
            CGRect label6Rect = new CGRect(frame.GetMinX() + NMath.Floor(frame.Width * 0.50435f + 0.5f), frame.GetMinY() + NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f) + 0.81f, NMath.Floor(frame.Width * 0.66667f + 0.5f) - NMath.Floor(frame.Width * 0.50435f + 0.5f), frame.Height - 12.63f - NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f));
            {
                var textContent = "IBU";
                textForeground.SetFill();
                var label6Style = new NSMutableParagraphStyle();
                label6Style.Alignment = UITextAlignment.Left;

                var label6FontAttributes = new UIStringAttributes() { Font = UIFont.FromName("Avenir-Heavy", 12.0f), ForegroundColor = textForeground, ParagraphStyle = label6Style };
                var label6TextHeight = new NSString(textContent).GetBoundingRect(new CGSize(label6Rect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, label6FontAttributes, null).Height;
                context.SaveState();
                context.ClipToRect(label6Rect);
                new NSString(textContent).DrawString(new CGRect(label6Rect.GetMinX(), label6Rect.GetMinY() + (label6Rect.Height - label6TextHeight) / 2.0f, label6Rect.Width, label6TextHeight), UIFont.FromName("Avenir-Heavy", 12.0f), UILineBreakMode.WordWrap, UITextAlignment.Left);
                context.RestoreState();
            }


            //// lblSrm Drawing
            CGRect lblSrmRect = new CGRect(frame.GetMinX() + NMath.Floor(frame.Width * 0.66957f + 0.5f), frame.GetMinY() + NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f) + 0.81f, NMath.Floor(frame.Width * 0.83478f + 0.5f) - NMath.Floor(frame.Width * 0.66957f + 0.5f), frame.Height - 12.63f - NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f));
            textForeground2.SetFill();
            var lblSrmStyle = new NSMutableParagraphStyle();
            lblSrmStyle.Alignment = UITextAlignment.Right;

            var lblSrmFontAttributes = new UIStringAttributes() { Font = UIFont.FromName("Avenir-Heavy", 12.0f), ForegroundColor = textForeground2, ParagraphStyle = lblSrmStyle };
            var lblSrmTextHeight = new NSString(srm).GetBoundingRect(new CGSize(lblSrmRect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, lblSrmFontAttributes, null).Height;
            context.SaveState();
            context.ClipToRect(lblSrmRect);
            new NSString(srm).DrawString(new CGRect(lblSrmRect.GetMinX(), lblSrmRect.GetMinY() + (lblSrmRect.Height - lblSrmTextHeight) / 2.0f, lblSrmRect.Width, lblSrmTextHeight), UIFont.FromName("Avenir-Heavy", 12.0f), UILineBreakMode.WordWrap, UITextAlignment.Right);
            context.RestoreState();


            //// Label 8 Drawing
            CGRect label8Rect = new CGRect(frame.GetMinX() + NMath.Floor(frame.Width * 0.83460f - 0.44f) + 0.94f, frame.GetMinY() + NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f) + 0.81f, NMath.Floor(frame.Width * 1.00000f - 0.5f) - NMath.Floor(frame.Width * 0.83460f - 0.44f) + 0.06f, frame.Height - 12.63f - NMath.Floor((frame.Height - 11.81f) * 0.78989f - 0.31f));
            {
                var textContent = "SRM";
                textForeground.SetFill();
                var label8Style = new NSMutableParagraphStyle();
                label8Style.Alignment = UITextAlignment.Left;

                var label8FontAttributes = new UIStringAttributes() { Font = UIFont.FromName("Avenir-Heavy", 12.0f), ForegroundColor = textForeground, ParagraphStyle = label8Style };
                var label8TextHeight = new NSString(textContent).GetBoundingRect(new CGSize(label8Rect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, label8FontAttributes, null).Height;
                context.SaveState();
                context.ClipToRect(label8Rect);
                new NSString(textContent).DrawString(new CGRect(label8Rect.GetMinX(), label8Rect.GetMinY() + (label8Rect.Height - label8TextHeight) / 2.0f, label8Rect.Width, label8TextHeight), UIFont.FromName("Avenir-Heavy", 12.0f), UILineBreakMode.WordWrap, UITextAlignment.Left);
                context.RestoreState();
            }
        }

    }
}

