using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.CustomControls
{
    [Register("TinderBox"), DesignTimeVisible(true)]
    public class TinderBox : UIView
    {
        public TinderBox(IntPtr p, string title )
            : base(p)
        {
            Title = title;
            Initialize();
        }

        string title;
        public string Title
            {
                get
                {
                    return title;
                }
                set
                {
                    title = value;                    
                }
            }

        private void Initialize()
        {
        }

        public override void Draw(CGRect frame)
        {
            DrawCanvas(frame, Title);
        }

        private void DrawCanvas(CGRect frame, string beerName)
        {
            //// General Declarations
            var context = UIGraphics.GetCurrentContext();

            //// Color Declarations
            var fillColor = UIColor.FromRGBA(0.500f, 0.500f, 0.500f, 1.000f);
            var shadowTint = UIColor.FromRGBA(0.000f, 0.000f, 0.000f, 1.000f);
            var fillColor2 = UIColor.FromRGBA(1.000f, 1.000f, 1.000f, 1.000f);
            var strokeColor = UIColor.FromRGBA(0.531f, 0.531f, 0.531f, 1.000f);
            var textForeground2 = UIColor.FromRGBA(0.408f, 0.408f, 0.408f, 1.000f);

            //// Shadow Declarations
            var shadow2 = new NSShadow();
            shadow2.ShadowColor = shadowTint.ColorWithAlpha(shadowTint.CGColor.Alpha * 0.3f);
            shadow2.ShadowOffset = new CGSize(930.1f, -0.1f);
            shadow2.ShadowBlurRadius = 10.0f;

            //// Rectangle Drawing
            var rectanglePath = UIBezierPath.FromRoundedRect(new CGRect(-921.0f, 9.0f, 395.0f, 418.0f), 8.0f);
            context.SaveState();
            context.SetShadow(shadow2.ShadowOffset, shadow2.ShadowBlurRadius, shadow2.ShadowColor.CGColor);
            fillColor.SetFill();
            rectanglePath.Fill();
            context.RestoreState();



            //// Group
            {
                context.SaveState();
                context.BeginTransparencyLayer();

                //// Clip Clip 2
                UIBezierPath clip2Path = new UIBezierPath();
                clip2Path.MoveTo(new CGPoint(-11.5f, -11.5f));
                clip2Path.AddLineTo(new CGPoint(424.5f, -11.5f));
                clip2Path.AddLineTo(new CGPoint(424.5f, 447.5f));
                clip2Path.AddLineTo(new CGPoint(-11.5f, 447.5f));
                clip2Path.AddLineTo(new CGPoint(-11.5f, -11.5f));
                clip2Path.ClosePath();
                clip2Path.MoveTo(new CGPoint(9.5f, 17.0f));
                clip2Path.AddCurveToPoint(new CGPoint(17.0f, 9.5f), new CGPoint(9.5f, 12.86f), new CGPoint(12.86f, 9.5f));
                clip2Path.AddLineTo(new CGPoint(396.0f, 9.5f));
                clip2Path.AddCurveToPoint(new CGPoint(403.5f, 17.0f), new CGPoint(400.14f, 9.5f), new CGPoint(403.5f, 12.86f));
                clip2Path.AddLineTo(new CGPoint(403.5f, 419.0f));
                clip2Path.AddCurveToPoint(new CGPoint(396.0f, 426.5f), new CGPoint(403.5f, 423.14f), new CGPoint(400.14f, 426.5f));
                clip2Path.AddLineTo(new CGPoint(17.0f, 426.5f));
                clip2Path.AddCurveToPoint(new CGPoint(9.5f, 419.0f), new CGPoint(12.86f, 426.5f), new CGPoint(9.5f, 423.14f));
                clip2Path.AddLineTo(new CGPoint(9.5f, 17.0f));
                clip2Path.ClosePath();
                clip2Path.MoveTo(new CGPoint(8.5f, 17.0f));
                clip2Path.AddLineTo(new CGPoint(8.5f, 419.0f));
                clip2Path.AddCurveToPoint(new CGPoint(17.0f, 427.5f), new CGPoint(8.5f, 423.69f), new CGPoint(12.31f, 427.5f));
                clip2Path.AddLineTo(new CGPoint(396.0f, 427.5f));
                clip2Path.AddCurveToPoint(new CGPoint(404.5f, 419.0f), new CGPoint(400.69f, 427.5f), new CGPoint(404.5f, 423.69f));
                clip2Path.AddLineTo(new CGPoint(404.5f, 17.0f));
                clip2Path.AddCurveToPoint(new CGPoint(396.0f, 8.5f), new CGPoint(404.5f, 12.31f), new CGPoint(400.69f, 8.5f));
                clip2Path.AddLineTo(new CGPoint(17.0f, 8.5f));
                clip2Path.AddCurveToPoint(new CGPoint(8.5f, 17.0f), new CGPoint(12.31f, 8.5f), new CGPoint(8.5f, 12.31f));
                clip2Path.ClosePath();
                clip2Path.UsesEvenOddFillRule = true;

                clip2Path.AddClip();


                //// Group 2
                {
                    context.SaveState();
                    context.BeginTransparencyLayer();

                    //// Clip Clip
                    var clipPath = UIBezierPath.FromRoundedRect(new CGRect(9.0f, 9.0f, 395.0f, 418.0f), 8.0f);
                    clipPath.AddClip();


                    //// Rectangle 2 Drawing
                    var rectangle2Path = UIBezierPath.FromRoundedRect(new CGRect(9.0f, 9.0f, 395.0f, 418.0f), 8.0f);
                    fillColor2.SetFill();
                    rectangle2Path.Fill();


                    context.EndTransparencyLayer();
                    context.RestoreState();
                }


                context.EndTransparencyLayer();
                context.RestoreState();
            }


            //// background
            {
                context.SaveState();
                context.BeginTransparencyLayer();

                //// Clip Clip 3
                var clip3Path = UIBezierPath.FromRoundedRect(new CGRect(frame.GetMinX(), frame.GetMinY() + 9.0f, 395.0f, 418.0f), 8.0f);
                clip3Path.AddClip();


                //// Rectangle 4 Drawing
                var rectangle4Path = UIBezierPath.FromRoundedRect(new CGRect(frame.GetMinX(), frame.GetMinY() + 9.0f, 395.0f, 418.0f), 8.0f);
                strokeColor.SetStroke();
                rectangle4Path.LineWidth = 2.0f;
                rectangle4Path.Stroke();


                context.EndTransparencyLayer();
                context.RestoreState();
            }


            //// title Drawing
            CGRect titleRect = new CGRect(frame.GetMinX() + 0.38f, frame.GetMinY() + 19.0f, 394.62f, 41.0f);
            textForeground2.SetFill();
            var titleStyle = new NSMutableParagraphStyle ();
            titleStyle.Alignment = UITextAlignment.Center;

            var titleFontAttributes = new UIStringAttributes () {Font = UIFont.FromName("Avenir-Medium", 24.0f), ForegroundColor = textForeground2, ParagraphStyle = titleStyle};
            var titleTextHeight = new NSString(beerName).GetBoundingRect(new CGSize(titleRect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, titleFontAttributes, null).Height;
            context.SaveState();
            context.ClipToRect(titleRect);
            new NSString(beerName).DrawString(new CGRect(titleRect.GetMinX(), titleRect.GetMinY() + (titleRect.Height - titleTextHeight) / 2.0f, titleRect.Width, titleTextHeight), UIFont.FromName("Avenir-Medium", 24.0f), UILineBreakMode.WordWrap, UITextAlignment.Center);
            context.RestoreState();
        }

    }
}