using System;
using UIKit;
using System.ComponentModel;
using Foundation;
using CoreGraphics;

namespace BeerDrinkin.iOS.CustomControls
{
    [Register("DiscoverCameraButton"), DesignTimeVisible(true)]
    public class DiscoverCameraButton : UIButton
    {
        public DiscoverCameraButton()
        {
        }

        public DiscoverCameraButton(IntPtr p): base(p){}

        public override void Draw(CGRect rect)
        {
            DrawCanvas(rect);
        }

        void DrawCanvas(CGRect frame)
        {
            //// General Declarations
            var context = UIGraphics.GetCurrentContext();

            //// Color Declarations
            var color = UIColor.FromRGBA(0.851f, 0.851f, 0.851f, 1.000f);
            var fillColor3 = UIColor.FromRGBA(0.333f, 0.333f, 0.333f, 1.000f);
            var fillColor4 = UIColor.FromRGBA(0.000f, 0.000f, 0.000f, 1.000f);
            var fillColor5 = UIColor.FromRGBA(0.867f, 0.867f, 0.863f, 1.000f);
            var fillColor6 = UIColor.FromRGBA(0.671f, 0.671f, 0.671f, 1.000f);
            var fillColor7 = UIColor.FromRGBA(0.467f, 0.467f, 0.467f, 1.000f);
            var fillColor8 = UIColor.FromRGBA(0.918f, 0.478f, 0.149f, 1.000f);
            var fillColor9 = UIColor.FromRGBA(0.529f, 0.529f, 0.529f, 1.000f);
            var fillColor10 = UIColor.FromRGBA(0.271f, 0.271f, 0.271f, 1.000f);
            var color2 = UIColor.FromRGBA(0.941f, 0.941f, 0.941f, 1.000f);
            var color5 = UIColor.FromRGBA(0.275f, 0.275f, 0.275f, 1.000f);

            //// Rectangle Drawing
            var rectanglePath = UIBezierPath.FromRoundedRect(new CGRect(frame.GetMinX(), frame.GetMinY() + NMath.Floor((frame.Height) * 0.00000f + 0.5f), frame.Width - 0.5f, frame.Height - NMath.Floor((frame.Height) * 0.00000f + 0.5f)), 4.0f);
            color2.SetFill();
            rectanglePath.Fill();
            color.SetStroke();
            rectanglePath.LineWidth = 1.0f;
            rectanglePath.Stroke();


            //// Group 2
            {
                context.SaveState();
                context.TranslateCTM(frame.GetMinX() + 0.43716f * frame.Width, frame.GetMinY() + 0.12195f * frame.Height);
                context.ScaleCTM(0.4f, 0.4f);



                //// Rectangle 2 Drawing
                var rectangle2Path = UIBezierPath.FromRect(new CGRect(0.0f, 36.0f, 112.0f, 36.0f));
                fillColor3.SetFill();
                rectangle2Path.Fill();


                //// Rectangle 3 Drawing
                var rectangle3Path = UIBezierPath.FromRect(new CGRect(0.0f, 72.0f, 112.0f, 8.0f));
                fillColor4.SetFill();
                rectangle3Path.Fill();


                //// Bezier Drawing
                UIBezierPath bezierPath = new UIBezierPath();
                bezierPath.MoveTo(new CGPoint(0.0f, 80.0f));
                bezierPath.AddCurveToPoint(new CGPoint(8.0f, 88.0f), new CGPoint(0.0f, 84.42f), new CGPoint(3.58f, 88.0f));
                bezierPath.AddLineTo(new CGPoint(104.0f, 88.0f));
                bezierPath.AddCurveToPoint(new CGPoint(112.0f, 80.0f), new CGPoint(108.42f, 88.0f), new CGPoint(112.0f, 84.42f));
                bezierPath.AddLineTo(new CGPoint(0.0f, 80.0f));
                bezierPath.AddLineTo(new CGPoint(0.0f, 80.0f));
                bezierPath.ClosePath();
                bezierPath.UsesEvenOddFillRule = true;

                fillColor5.SetFill();
                bezierPath.Fill();


                //// Bezier 2 Drawing
                UIBezierPath bezier2Path = new UIBezierPath();
                bezier2Path.MoveTo(new CGPoint(56.3f, 88.0f));
                bezier2Path.AddLineTo(new CGPoint(104.0f, 88.0f));
                bezier2Path.AddCurveToPoint(new CGPoint(112.0f, 80.0f), new CGPoint(108.42f, 88.0f), new CGPoint(112.0f, 84.42f));
                bezier2Path.AddLineTo(new CGPoint(48.3f, 80.0f));
                bezier2Path.AddLineTo(new CGPoint(56.3f, 88.0f));
                bezier2Path.AddLineTo(new CGPoint(56.3f, 88.0f));
                bezier2Path.ClosePath();
                bezier2Path.UsesEvenOddFillRule = true;

                fillColor6.SetFill();
                bezier2Path.Fill();


                //// Rectangle 4 Drawing
                var rectangle4Path = UIBezierPath.FromRect(new CGRect(0.0f, 28.0f, 112.0f, 8.0f));
                fillColor4.SetFill();
                rectangle4Path.Fill();


                //// Bezier 3 Drawing
                UIBezierPath bezier3Path = new UIBezierPath();
                bezier3Path.MoveTo(new CGPoint(104.0f, 8.0f));
                bezier3Path.AddLineTo(new CGPoint(76.0f, 8.0f));
                bezier3Path.AddLineTo(new CGPoint(68.0f, 0.0f));
                bezier3Path.AddLineTo(new CGPoint(44.0f, 0.0f));
                bezier3Path.AddLineTo(new CGPoint(36.0f, 8.0f));
                bezier3Path.AddLineTo(new CGPoint(8.0f, 8.0f));
                bezier3Path.AddCurveToPoint(new CGPoint(0.0f, 16.0f), new CGPoint(3.6f, 8.0f), new CGPoint(0.0f, 11.6f));
                bezier3Path.AddLineTo(new CGPoint(0.0f, 28.0f));
                bezier3Path.AddLineTo(new CGPoint(112.0f, 28.0f));
                bezier3Path.AddLineTo(new CGPoint(112.0f, 16.0f));
                bezier3Path.AddCurveToPoint(new CGPoint(104.0f, 8.0f), new CGPoint(112.0f, 11.58f), new CGPoint(108.42f, 8.0f));
                bezier3Path.AddLineTo(new CGPoint(104.0f, 8.0f));
                bezier3Path.ClosePath();
                bezier3Path.UsesEvenOddFillRule = true;

                fillColor5.SetFill();
                bezier3Path.Fill();


                //// Oval Drawing
                var ovalPath = UIBezierPath.FromOval(new CGRect(28.0f, 20.0f, 56.0f, 56.0f));
                fillColor7.SetFill();
                ovalPath.Fill();


                //// Oval 2 Drawing
                var oval2Path = UIBezierPath.FromOval(new CGRect(32.0f, 24.0f, 48.0f, 48.0f));
                fillColor4.SetFill();
                oval2Path.Fill();


                //// Oval 3 Drawing
                var oval3Path = UIBezierPath.FromOval(new CGRect(8.0f, 16.0f, 8.0f, 8.0f));
                fillColor8.SetFill();
                oval3Path.Fill();


                //// Group 3
                {
                    context.SaveState();
                    context.SetAlpha(0.4f);
                    context.BeginTransparencyLayer();


                    //// Bezier 4 Drawing
                    UIBezierPath bezier4Path = new UIBezierPath();
                    bezier4Path.MoveTo(new CGPoint(104.0f, 24.0f));
                    bezier4Path.AddLineTo(new CGPoint(96.0f, 24.0f));
                    bezier4Path.AddLineTo(new CGPoint(104.0f, 16.0f));
                    bezier4Path.AddLineTo(new CGPoint(104.0f, 24.0f));
                    bezier4Path.ClosePath();
                    bezier4Path.UsesEvenOddFillRule = true;

                    fillColor3.SetFill();
                    bezier4Path.Fill();


                    context.EndTransparencyLayer();
                    context.RestoreState();
                }


                //// Bezier 5 Drawing
                UIBezierPath bezier5Path = new UIBezierPath();
                bezier5Path.MoveTo(new CGPoint(96.0f, 24.0f));
                bezier5Path.AddLineTo(new CGPoint(96.0f, 16.0f));
                bezier5Path.AddLineTo(new CGPoint(104.0f, 16.0f));
                bezier5Path.AddLineTo(new CGPoint(96.0f, 24.0f));
                bezier5Path.ClosePath();
                bezier5Path.UsesEvenOddFillRule = true;

                fillColor9.SetFill();
                bezier5Path.Fill();


                //// Oval 4 Drawing
                var oval4Path = UIBezierPath.FromOval(new CGRect(40.0f, 32.0f, 32.0f, 32.0f));
                fillColor3.SetFill();
                oval4Path.Fill();


                //// Bezier 6 Drawing
                UIBezierPath bezier6Path = new UIBezierPath();
                bezier6Path.MoveTo(new CGPoint(60.0f, 36.0f));
                bezier6Path.AddCurveToPoint(new CGPoint(44.0f, 52.0f), new CGPoint(51.16f, 36.0f), new CGPoint(44.0f, 43.16f));
                bezier6Path.AddCurveToPoint(new CGPoint(46.88f, 61.12f), new CGPoint(44.0f, 55.4f), new CGPoint(45.07f, 58.53f));
                bezier6Path.AddCurveToPoint(new CGPoint(56.0f, 64.0f), new CGPoint(49.47f, 62.93f), new CGPoint(52.6f, 64.0f));
                bezier6Path.AddCurveToPoint(new CGPoint(72.0f, 48.0f), new CGPoint(64.84f, 64.0f), new CGPoint(72.0f, 56.84f));
                bezier6Path.AddCurveToPoint(new CGPoint(69.12f, 38.88f), new CGPoint(72.0f, 44.6f), new CGPoint(70.93f, 41.47f));
                bezier6Path.AddCurveToPoint(new CGPoint(60.0f, 36.0f), new CGPoint(66.53f, 37.07f), new CGPoint(63.4f, 36.0f));
                bezier6Path.AddLineTo(new CGPoint(60.0f, 36.0f));
                bezier6Path.ClosePath();
                bezier6Path.UsesEvenOddFillRule = true;

                fillColor7.SetFill();
                bezier6Path.Fill();


                //// Oval 5 Drawing
                var oval5Path = UIBezierPath.FromOval(new CGRect(48.0f, 40.0f, 12.0f, 12.0f));
                fillColor6.SetFill();
                oval5Path.Fill();


                //// Oval 6 Drawing
                var oval6Path = UIBezierPath.FromOval(new CGRect(60.0f, 48.0f, 8.0f, 8.0f));
                fillColor5.SetFill();
                oval6Path.Fill();


                //// Group 4
                {
                    context.SaveState();
                    context.SetAlpha(0.4f);
                    context.BeginTransparencyLayer();


                    //// Bezier 7 Drawing
                    UIBezierPath bezier7Path = new UIBezierPath();
                    bezier7Path.MoveTo(new CGPoint(41.65f, 72.0f));
                    bezier7Path.AddCurveToPoint(new CGPoint(35.96f, 67.54f), new CGPoint(39.57f, 70.75f), new CGPoint(37.65f, 69.26f));
                    bezier7Path.AddLineTo(new CGPoint(35.9f, 67.6f));
                    bezier7Path.AddLineTo(new CGPoint(40.3f, 72.0f));
                    bezier7Path.AddLineTo(new CGPoint(41.65f, 72.0f));
                    bezier7Path.AddLineTo(new CGPoint(41.65f, 72.0f));
                    bezier7Path.ClosePath();
                    bezier7Path.UsesEvenOddFillRule = true;

                    fillColor3.SetFill();
                    bezier7Path.Fill();


                    context.EndTransparencyLayer();
                    context.RestoreState();
                }


                //// Bezier 8 Drawing
                UIBezierPath bezier8Path = new UIBezierPath();
                bezier8Path.MoveTo(new CGPoint(81.26f, 36.0f));
                bezier8Path.AddCurveToPoint(new CGPoint(84.0f, 48.0f), new CGPoint(83.0f, 39.64f), new CGPoint(84.0f, 43.7f));
                bezier8Path.AddCurveToPoint(new CGPoint(70.36f, 72.0f), new CGPoint(84.0f, 58.2f), new CGPoint(78.52f, 67.1f));
                bezier8Path.AddLineTo(new CGPoint(112.0f, 72.0f));
                bezier8Path.AddLineTo(new CGPoint(112.0f, 64.5f));
                bezier8Path.AddLineTo(new CGPoint(83.5f, 36.0f));
                bezier8Path.AddLineTo(new CGPoint(81.26f, 36.0f));
                bezier8Path.AddLineTo(new CGPoint(81.26f, 36.0f));
                bezier8Path.ClosePath();
                bezier8Path.UsesEvenOddFillRule = true;

                fillColor10.SetFill();
                bezier8Path.Fill();



                context.RestoreState();
            }


            //// Text Drawing
            CGRect textRect = new CGRect(frame.GetMinX() + 7.0f, frame.GetMinY() + NMath.Floor((frame.Height - 8.0f) * 0.67568f + 0.5f), frame.Width - 14.0f, frame.Height - 8.0f - NMath.Floor((frame.Height - 8.0f) * 0.67568f + 0.5f));
            {
                var textContent = "Picture Search";
                color5.SetFill();
                var textStyle = new NSMutableParagraphStyle();
                textStyle.Alignment = UITextAlignment.Center;

                var textFontAttributes = new UIStringAttributes() { Font = UIFont.FromName("Avenir-Medium", UIFont.ButtonFontSize), ForegroundColor = color5, ParagraphStyle = textStyle };
                var textTextHeight = new NSString(textContent).GetBoundingRect(new CGSize(textRect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, textFontAttributes, null).Height;
                context.SaveState();
                context.ClipToRect(textRect);
                new NSString(textContent).DrawString(new CGRect(textRect.GetMinX(), textRect.GetMinY() + (textRect.Height - textTextHeight) / 2.0f, textRect.Width, textTextHeight), UIFont.FromName("Avenir-Medium", UIFont.ButtonFontSize), UILineBreakMode.WordWrap, UITextAlignment.Center);
                context.RestoreState();
            }
        }

    }
}

