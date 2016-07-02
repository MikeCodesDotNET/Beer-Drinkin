using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.CustomControls
{
    [Register("CheckInBackground")]
    public class CheckInBackground : UIView
    {
        public CheckInBackground()
        {
        }

        public CheckInBackground(IntPtr handle) : base (handle)
        {
        }

        public override void Draw(CGRect rect)
        {   
            //// General Declarations
            var context = UIGraphics.GetCurrentContext();

            //// Color Declarations
            var fillColor = UIColor.FromRGBA(1.000f, 1.000f, 1.000f, 1.000f);
            var strokeColor3 = UIColor.FromRGBA(0.716f, 0.716f, 0.716f, 1.000f);
            var shadowTint2 = UIColor.FromRGBA(0.000f, 0.000f, 0.000f, 1.000f);
            var strokeColor4 = UIColor.FromRGBA(0.807f, 0.807f, 0.807f, 1.000f);
            var fillColor4 = UIColor.FromRGBA(0.969f, 0.969f, 0.969f, 1.000f);
            var fillColor6 = UIColor.FromRGBA(0.314f, 0.824f, 0.761f, 1.000f);
            var strokeColor5 = UIColor.FromRGBA(0.855f, 0.855f, 0.855f, 1.000f);

            //// Shadow Declarations
            var shadow3 = new NSShadow();
            shadow3.ShadowColor = shadowTint2.ColorWithAlpha(shadowTint2.CGColor.Alpha * 0.13f);
            shadow3.ShadowOffset = new CGSize(1450.1f, 2.1f);
            shadow3.ShadowBlurRadius = 4.0f;

            //// Group 5
            {
                context.SaveState();
                context.BeginTransparencyLayer();

                //// Clip Clip 5
                var clip5Path = UIBezierPath.FromRect(new CGRect(rect.GetMinX() + 4.0f, rect.GetMinY() + 248.55f, 686.9f, 265.6f));
                clip5Path.AddClip();


                //// Rectangle 6 Drawing
                var rectangle6Path = UIBezierPath.FromRect(new CGRect(rect.GetMinX() + 4.0f, rect.GetMinY() + 248.55f, 686.9f, 265.6f));
                strokeColor4.SetStroke();
                rectangle6Path.LineWidth = 2.0f;
                rectangle6Path.Stroke();


                context.EndTransparencyLayer();
                context.RestoreState();
            }


            //// Bezier Drawing
            UIBezierPath bezierPath = new UIBezierPath();
            bezierPath.MoveTo(new CGPoint(rect.GetMinX() + 687.41f, rect.GetMinY() + 349.29f));
            bezierPath.AddLineTo(new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 353.29f));
            bezierPath.LineCapStyle = CGLineCap.Square;

            strokeColor3.SetStroke();
            bezierPath.LineWidth = 1.0f;
            bezierPath.Stroke();


            //// Group
            {
                context.SaveState();
                context.BeginTransparencyLayer();

                //// Clip Clip
                var clipPath = UIBezierPath.FromRect(new CGRect(rect.GetMinX() - 13.0f, rect.GetMinY() - 17.0f, 725.0f, 556.0f));
                clipPath.AddClip();


                //// Bezier 2 Drawing
                UIBezierPath bezier2Path = new UIBezierPath();
                bezier2Path.MoveTo(new CGPoint(rect.GetMinX() - 1448.0f, rect.GetMinY() + 2.0f));
                bezier2Path.AddCurveToPoint(new CGPoint(rect.GetMinX() - 1444.0f, rect.GetMinY() - 2.0f), new CGPoint(rect.GetMinX() - 1448.0f, rect.GetMinY() - 0.21f), new CGPoint(rect.GetMinX() - 1446.2f, rect.GetMinY() - 2.0f));
                bezier2Path.AddLineTo(new CGPoint(rect.GetMinX() - 765.08f, rect.GetMinY() - 2.0f));
                bezier2Path.AddCurveToPoint(new CGPoint(rect.GetMinX() - 761.09f, rect.GetMinY() + 2.0f), new CGPoint(rect.GetMinX() - 762.87f, rect.GetMinY() - 2.0f), new CGPoint(rect.GetMinX() - 761.09f, rect.GetMinY() - 0.21f));
                bezier2Path.AddLineTo(new CGPoint(rect.GetMinX() - 761.09f, rect.GetMinY() + 509.16f));
                bezier2Path.AddCurveToPoint(new CGPoint(rect.GetMinX() - 765.08f, rect.GetMinY() + 513.16f), new CGPoint(rect.GetMinX() - 761.09f, rect.GetMinY() + 511.37f), new CGPoint(rect.GetMinX() - 762.88f, rect.GetMinY() + 513.16f));
                bezier2Path.AddLineTo(new CGPoint(rect.GetMinX() - 1444.0f, rect.GetMinY() + 513.16f));
                bezier2Path.AddCurveToPoint(new CGPoint(rect.GetMinX() - 1448.0f, rect.GetMinY() + 509.16f), new CGPoint(rect.GetMinX() - 1446.21f, rect.GetMinY() + 513.16f), new CGPoint(rect.GetMinX() - 1448.0f, rect.GetMinY() + 511.37f));
                bezier2Path.AddLineTo(new CGPoint(rect.GetMinX() - 1448.0f, rect.GetMinY() + 2.0f));
                bezier2Path.ClosePath();
                bezier2Path.UsesEvenOddFillRule = true;

                context.SaveState();
                context.SetShadow(shadow3.ShadowOffset, shadow3.ShadowBlurRadius, shadow3.ShadowColor.CGColor);
                fillColor.SetFill();
                bezier2Path.Fill();
                context.RestoreState();



                context.EndTransparencyLayer();
                context.RestoreState();
            }


            //// Group 2
            {
                context.SaveState();
                context.BeginTransparencyLayer();

                //// Clip Clip 3
                UIBezierPath clip3Path = new UIBezierPath();
                clip3Path.MoveTo(new CGPoint(rect.GetMinX() - 15.49f, rect.GetMinY() - 22.5f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() + 712.41f, rect.GetMinY() - 22.5f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() + 712.41f, rect.GetMinY() + 533.66f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() - 15.49f, rect.GetMinY() + 533.66f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() - 15.49f, rect.GetMinY() - 22.5f));
                clip3Path.ClosePath();
                clip3Path.MoveTo(new CGPoint(rect.GetMinX() + 5.51f, rect.GetMinY() + 2.0f));
                clip3Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 9.0f, rect.GetMinY() - 1.5f), new CGPoint(rect.GetMinX() + 5.51f, rect.GetMinY() + 0.07f), new CGPoint(rect.GetMinX() + 7.07f, rect.GetMinY() - 1.5f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() + 687.92f, rect.GetMinY() - 1.5f));
                clip3Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 691.41f, rect.GetMinY() + 2.0f), new CGPoint(rect.GetMinX() + 689.85f, rect.GetMinY() - 1.5f), new CGPoint(rect.GetMinX() + 691.41f, rect.GetMinY() + 0.07f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() + 691.41f, rect.GetMinY() + 509.16f));
                clip3Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 687.92f, rect.GetMinY() + 512.66f), new CGPoint(rect.GetMinX() + 691.41f, rect.GetMinY() + 511.09f), new CGPoint(rect.GetMinX() + 689.85f, rect.GetMinY() + 512.66f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() + 9.0f, rect.GetMinY() + 512.66f));
                clip3Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 5.51f, rect.GetMinY() + 509.16f), new CGPoint(rect.GetMinX() + 7.07f, rect.GetMinY() + 512.66f), new CGPoint(rect.GetMinX() + 5.51f, rect.GetMinY() + 511.09f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() + 5.51f, rect.GetMinY() + 2.0f));
                clip3Path.ClosePath();
                clip3Path.MoveTo(new CGPoint(rect.GetMinX() + 4.51f, rect.GetMinY() + 2.0f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() + 4.51f, rect.GetMinY() + 509.16f));
                clip3Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 9.0f, rect.GetMinY() + 513.66f), new CGPoint(rect.GetMinX() + 4.51f, rect.GetMinY() + 511.65f), new CGPoint(rect.GetMinX() + 6.52f, rect.GetMinY() + 513.66f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() + 687.92f, rect.GetMinY() + 513.66f));
                clip3Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 692.41f, rect.GetMinY() + 509.16f), new CGPoint(rect.GetMinX() + 690.4f, rect.GetMinY() + 513.66f), new CGPoint(rect.GetMinX() + 692.41f, rect.GetMinY() + 511.64f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() + 692.41f, rect.GetMinY() + 2.0f));
                clip3Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 687.92f, rect.GetMinY() - 2.5f), new CGPoint(rect.GetMinX() + 692.41f, rect.GetMinY() - 0.49f), new CGPoint(rect.GetMinX() + 690.4f, rect.GetMinY() - 2.5f));
                clip3Path.AddLineTo(new CGPoint(rect.GetMinX() + 9.0f, rect.GetMinY() - 2.5f));
                clip3Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 4.51f, rect.GetMinY() + 2.0f), new CGPoint(rect.GetMinX() + 6.52f, rect.GetMinY() - 2.5f), new CGPoint(rect.GetMinX() + 4.51f, rect.GetMinY() - 0.48f));
                clip3Path.ClosePath();
                clip3Path.UsesEvenOddFillRule = true;

                clip3Path.AddClip();


                //// Group 3
                {
                    context.SaveState();
                    context.BeginTransparencyLayer();

                    //// Clip Clip 2
                    var clip2Path = UIBezierPath.FromRoundedRect(new CGRect(rect.GetMinX() + 5.0f, rect.GetMinY() - 1.98f, 686.9f, 515.15f), 4.0f);
                    clip2Path.AddClip();


                    //// Rectangle 2 Drawing
                    var rectangle2Path = UIBezierPath.FromRoundedRect(new CGRect(rect.GetMinX() + 5.0f, rect.GetMinY() - 1.98f, 686.9f, 515.15f), 4.0f);
                    fillColor.SetFill();
                    rectangle2Path.Fill();


                    context.EndTransparencyLayer();
                    context.RestoreState();
                }


                context.EndTransparencyLayer();
                context.RestoreState();
            }


            //// Group 4
            {
                context.SaveState();
                context.BeginTransparencyLayer();

                //// Clip Clip 4
                var clip4Path = UIBezierPath.FromRoundedRect(new CGRect(rect.GetMinX() + 4.0f, rect.GetMinY() + 3.02f, 686.9f, 515.15f), 4.0f);
                clip4Path.AddClip();


                //// Rectangle 4 Drawing
                var rectangle4Path = UIBezierPath.FromRoundedRect(new CGRect(rect.GetMinX() + 4.0f, rect.GetMinY() + 3.02f, 686.9f, 515.15f), 4.0f);
                strokeColor4.SetStroke();
                rectangle4Path.LineWidth = 2.0f;
                rectangle4Path.Stroke();


                context.EndTransparencyLayer();
                context.RestoreState();
            }


            //// Bezier 4 Drawing
            UIBezierPath bezier4Path = new UIBezierPath();
            bezier4Path.MoveTo(new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 248.57f));
            bezier4Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 690.01f, rect.GetMinY() + 249.06f), new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 248.56f), new CGPoint(rect.GetMinX() + 690.01f, rect.GetMinY() + 249.06f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 249.06f));
            bezier4Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 248.56f), new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 248.73f), new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 248.56f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 248.57f));
            bezier4Path.ClosePath();
            bezier4Path.MoveTo(new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 248.57f));
            bezier4Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 249.06f), new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 248.56f), new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 248.73f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 249.06f));
            bezier4Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 513.66f), new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 261.48f), new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 501.24f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 690.01f, rect.GetMinY() + 513.66f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 514.16f));
            bezier4Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 513.66f), new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 514.16f), new CGPoint(rect.GetMinX() + 689.51f, rect.GetMinY() + 513.99f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 513.66f));
            bezier4Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 249.06f), new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 501.24f), new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 261.48f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 5.01f, rect.GetMinY() + 249.06f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 248.56f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 248.57f));
            bezier4Path.ClosePath();
            bezier4Path.MoveTo(new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 513.66f));
            bezier4Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 514.16f), new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 513.99f), new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 514.16f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 5.01f, rect.GetMinY() + 513.66f));
            bezier4Path.AddLineTo(new CGPoint(rect.GetMinX() + 5.5f, rect.GetMinY() + 513.66f));
            bezier4Path.ClosePath();
            fillColor4.SetFill();
            bezier4Path.Fill();


            //// Bezier 5 Drawing
            UIBezierPath bezier5Path = new UIBezierPath();
            bezier5Path.MoveTo(new CGPoint(rect.GetMinX() + 4.01f, rect.GetMinY() + 513.16f));
            bezier5Path.AddLineTo(new CGPoint(rect.GetMinX() + 690.91f, rect.GetMinY() + 513.16f));
            bezier5Path.AddLineTo(new CGPoint(rect.GetMinX() + 690.91f, rect.GetMinY() + 589.34f));
            bezier5Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 686.91f, rect.GetMinY() + 593.34f), new CGPoint(rect.GetMinX() + 690.91f, rect.GetMinY() + 591.55f), new CGPoint(rect.GetMinX() + 689.13f, rect.GetMinY() + 593.34f));
            bezier5Path.AddLineTo(new CGPoint(rect.GetMinX() + 350.63f, rect.GetMinY() + 593.34f));
            bezier5Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 342.63f, rect.GetMinY() + 593.34f), new CGPoint(rect.GetMinX() + 348.42f, rect.GetMinY() + 593.34f), new CGPoint(rect.GetMinX() + 344.84f, rect.GetMinY() + 593.34f));
            bezier5Path.AddLineTo(new CGPoint(rect.GetMinX() + 8.01f, rect.GetMinY() + 593.34f));
            bezier5Path.AddCurveToPoint(new CGPoint(rect.GetMinX() + 4.01f, rect.GetMinY() + 589.34f), new CGPoint(rect.GetMinX() + 5.8f, rect.GetMinY() + 593.34f), new CGPoint(rect.GetMinX() + 4.01f, rect.GetMinY() + 591.55f));
            bezier5Path.AddLineTo(new CGPoint(rect.GetMinX() + 4.01f, rect.GetMinY() + 513.16f));
            bezier5Path.ClosePath();
            bezier5Path.UsesEvenOddFillRule = true;

            fillColor6.SetFill();
            bezier5Path.Fill();


            //// Bezier 6 Drawing
            UIBezierPath bezier6Path = new UIBezierPath();
            bezier6Path.MoveTo(new CGPoint(rect.GetMinX() + 345.0f, rect.GetMinY() + 110.0f));
            bezier6Path.AddLineTo(new CGPoint(rect.GetMinX() + 345.46f, rect.GetMinY() + 4.0f));
            bezier6Path.LineCapStyle = CGLineCap.Square;

            strokeColor5.SetStroke();
            bezier6Path.LineWidth = 2.0f;
            bezier6Path.Stroke();


            //// Bezier 7 Drawing
            UIBezierPath bezier7Path = new UIBezierPath();
            bezier7Path.MoveTo(new CGPoint(rect.GetMinX() + 689.01f, rect.GetMinY() + 399.9f));
            bezier7Path.AddLineTo(new CGPoint(rect.GetMinX() + 5.01f, rect.GetMinY() + 399.9f));
            bezier7Path.LineCapStyle = CGLineCap.Square;

            strokeColor5.SetStroke();
            bezier7Path.LineWidth = 2.0f;
            bezier7Path.Stroke();


            //// Bezier 8 Drawing
            UIBezierPath bezier8Path = new UIBezierPath();
            bezier8Path.MoveTo(new CGPoint(rect.GetMinX() + 688.91f, rect.GetMinY() + 110.25f));
            bezier8Path.AddLineTo(new CGPoint(rect.GetMinX() + 6.01f, rect.GetMinY() + 110.25f));
            bezier8Path.LineCapStyle = CGLineCap.Square;

            strokeColor5.SetStroke();
            bezier8Path.LineWidth = 2.0f;
            bezier8Path.Stroke();
        }

    }

}

