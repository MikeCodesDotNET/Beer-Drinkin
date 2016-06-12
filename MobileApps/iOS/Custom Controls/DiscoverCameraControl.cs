using System;
using CoreGraphics;
using System.ComponentModel;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.CustomControls
{
    [Register("DiscoverCameraControl"), DesignTimeVisible(true)]
    public class DiscoverCameraControl : UIView
    {
        public DiscoverCameraControl()
        {
        }

        public DiscoverCameraControl(IntPtr p): base(p){ }

        public override void Draw(CGRect rect)
        {
            //// General Declarations
            var context = UIGraphics.GetCurrentContext();

            //// Color Declarations
            var fillColor = UIColor.FromRGBA(1.000f, 1.000f, 1.000f, 1.000f);
            var strokeColor = UIColor.FromRGBA(0.807f, 0.807f, 0.807f, 1.000f);
            var strokeColor2 = UIColor.FromRGBA(0.851f, 0.851f, 0.851f, 1.000f);

            //// Frames
            CGRect frame = new CGRect(0.0f, 0.0f, 772.0f, 356.0f);


            //// Group 2
            {
                //// Group 3
                {
                    context.SaveState();
                    context.BeginTransparencyLayer();

                    //// Clip Clip 2
                    UIBezierPath clip2Path = new UIBezierPath();
                    clip2Path.MoveTo(new CGPoint(frame.GetMinX() - 41.0f, frame.GetMinY() - 45.0f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() + 730.0f, frame.GetMinY() - 45.0f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() + 730.0f, frame.GetMinY() + 310.0f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() - 41.0f, frame.GetMinY() + 310.0f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() - 41.0f, frame.GetMinY() - 45.0f));
                    clip2Path.ClosePath();
                    clip2Path.MoveTo(new CGPoint(frame.GetMinX() - 20.0f, frame.GetMinY() - 20.5f));
                    clip2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() - 16.51f, frame.GetMinY() - 24.0f), new CGPoint(frame.GetMinX() - 20.0f, frame.GetMinY() - 22.44f), new CGPoint(frame.GetMinX() - 18.44f, frame.GetMinY() - 24.0f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() + 705.51f, frame.GetMinY() - 24.0f));
                    clip2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 709.0f, frame.GetMinY() - 20.5f), new CGPoint(frame.GetMinX() + 707.44f, frame.GetMinY() - 24.0f), new CGPoint(frame.GetMinX() + 709.0f, frame.GetMinY() - 22.44f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() + 709.0f, frame.GetMinY() + 285.5f));
                    clip2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 705.51f, frame.GetMinY() + 289.0f), new CGPoint(frame.GetMinX() + 709.0f, frame.GetMinY() + 287.44f), new CGPoint(frame.GetMinX() + 707.44f, frame.GetMinY() + 289.0f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() - 16.51f, frame.GetMinY() + 289.0f));
                    clip2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() - 20.0f, frame.GetMinY() + 285.5f), new CGPoint(frame.GetMinX() - 18.44f, frame.GetMinY() + 289.0f), new CGPoint(frame.GetMinX() - 20.0f, frame.GetMinY() + 287.44f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() - 20.0f, frame.GetMinY() - 20.5f));
                    clip2Path.ClosePath();
                    clip2Path.MoveTo(new CGPoint(frame.GetMinX() - 21.0f, frame.GetMinY() - 20.5f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() - 21.0f, frame.GetMinY() + 285.5f));
                    clip2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() - 16.51f, frame.GetMinY() + 290.0f), new CGPoint(frame.GetMinX() - 21.0f, frame.GetMinY() + 287.99f), new CGPoint(frame.GetMinX() - 18.99f, frame.GetMinY() + 290.0f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() + 705.51f, frame.GetMinY() + 290.0f));
                    clip2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 710.0f, frame.GetMinY() + 285.5f), new CGPoint(frame.GetMinX() + 707.99f, frame.GetMinY() + 290.0f), new CGPoint(frame.GetMinX() + 710.0f, frame.GetMinY() + 287.99f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() + 710.0f, frame.GetMinY() - 20.5f));
                    clip2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 705.51f, frame.GetMinY() - 25.0f), new CGPoint(frame.GetMinX() + 710.0f, frame.GetMinY() - 22.99f), new CGPoint(frame.GetMinX() + 707.99f, frame.GetMinY() - 25.0f));
                    clip2Path.AddLineTo(new CGPoint(frame.GetMinX() - 16.51f, frame.GetMinY() - 25.0f));
                    clip2Path.AddCurveToPoint(new CGPoint(frame.GetMinX() - 21.0f, frame.GetMinY() - 20.5f), new CGPoint(frame.GetMinX() - 18.99f, frame.GetMinY() - 25.0f), new CGPoint(frame.GetMinX() - 21.0f, frame.GetMinY() - 22.99f));
                    clip2Path.ClosePath();
                    clip2Path.UsesEvenOddFillRule = true;

                    clip2Path.AddClip();


                    //// Group 4
                    {
                        context.SaveState();
                        context.BeginTransparencyLayer();

                        //// Clip Clip
                        UIBezierPath clipPath = new UIBezierPath();
                        clipPath.MoveTo(new CGPoint(frame.GetMinX() - 20.5f, frame.GetMinY() - 20.5f));
                        clipPath.AddCurveToPoint(new CGPoint(frame.GetMinX() - 16.51f, frame.GetMinY() - 24.5f), new CGPoint(frame.GetMinX() - 20.5f, frame.GetMinY() - 22.71f), new CGPoint(frame.GetMinX() - 18.72f, frame.GetMinY() - 24.5f));
                        clipPath.AddLineTo(new CGPoint(frame.GetMinX() + 705.51f, frame.GetMinY() - 24.5f));
                        clipPath.AddCurveToPoint(new CGPoint(frame.GetMinX() + 709.5f, frame.GetMinY() - 20.5f), new CGPoint(frame.GetMinX() + 707.71f, frame.GetMinY() - 24.5f), new CGPoint(frame.GetMinX() + 709.5f, frame.GetMinY() - 22.71f));
                        clipPath.AddLineTo(new CGPoint(frame.GetMinX() + 709.5f, frame.GetMinY() + 285.5f));
                        clipPath.AddCurveToPoint(new CGPoint(frame.GetMinX() + 705.51f, frame.GetMinY() + 289.5f), new CGPoint(frame.GetMinX() + 709.5f, frame.GetMinY() + 287.71f), new CGPoint(frame.GetMinX() + 707.72f, frame.GetMinY() + 289.5f));
                        clipPath.AddLineTo(new CGPoint(frame.GetMinX() - 16.51f, frame.GetMinY() + 289.5f));
                        clipPath.AddCurveToPoint(new CGPoint(frame.GetMinX() - 20.5f, frame.GetMinY() + 285.5f), new CGPoint(frame.GetMinX() - 18.71f, frame.GetMinY() + 289.5f), new CGPoint(frame.GetMinX() - 20.5f, frame.GetMinY() + 287.71f));
                        clipPath.AddLineTo(new CGPoint(frame.GetMinX() - 20.5f, frame.GetMinY() - 20.5f));
                        clipPath.ClosePath();
                        clipPath.UsesEvenOddFillRule = true;

                        clipPath.AddClip();


                        //// Bezier Drawing
                        UIBezierPath bezierPath = new UIBezierPath();
                        bezierPath.MoveTo(new CGPoint(frame.GetMinX() - 20.5f, frame.GetMinY() - 20.5f));
                        bezierPath.AddCurveToPoint(new CGPoint(frame.GetMinX() - 16.51f, frame.GetMinY() - 24.5f), new CGPoint(frame.GetMinX() - 20.5f, frame.GetMinY() - 22.71f), new CGPoint(frame.GetMinX() - 18.72f, frame.GetMinY() - 24.5f));
                        bezierPath.AddLineTo(new CGPoint(frame.GetMinX() + 705.51f, frame.GetMinY() - 24.5f));
                        bezierPath.AddCurveToPoint(new CGPoint(frame.GetMinX() + 709.5f, frame.GetMinY() - 20.5f), new CGPoint(frame.GetMinX() + 707.71f, frame.GetMinY() - 24.5f), new CGPoint(frame.GetMinX() + 709.5f, frame.GetMinY() - 22.71f));
                        bezierPath.AddLineTo(new CGPoint(frame.GetMinX() + 709.5f, frame.GetMinY() + 285.5f));
                        bezierPath.AddCurveToPoint(new CGPoint(frame.GetMinX() + 705.51f, frame.GetMinY() + 289.5f), new CGPoint(frame.GetMinX() + 709.5f, frame.GetMinY() + 287.71f), new CGPoint(frame.GetMinX() + 707.72f, frame.GetMinY() + 289.5f));
                        bezierPath.AddLineTo(new CGPoint(frame.GetMinX() - 16.51f, frame.GetMinY() + 289.5f));
                        bezierPath.AddCurveToPoint(new CGPoint(frame.GetMinX() - 20.5f, frame.GetMinY() + 285.5f), new CGPoint(frame.GetMinX() - 18.71f, frame.GetMinY() + 289.5f), new CGPoint(frame.GetMinX() - 20.5f, frame.GetMinY() + 287.71f));
                        bezierPath.AddLineTo(new CGPoint(frame.GetMinX() - 20.5f, frame.GetMinY() - 20.5f));
                        bezierPath.ClosePath();
                        fillColor.SetFill();
                        bezierPath.Fill();


                        context.EndTransparencyLayer();
                        context.RestoreState();
                    }


                    context.EndTransparencyLayer();
                    context.RestoreState();
                }


                //// Group 5
                {
                    context.SaveState();
                    context.BeginTransparencyLayer();

                    //// Clip Clip 3
                    UIBezierPath clip3Path = new UIBezierPath();
                    clip3Path.MoveTo(new CGPoint(frame.GetMinX() - 13.5f, frame.GetMinY() - 11.14f));
                    clip3Path.AddCurveToPoint(new CGPoint(frame.GetMinX() - 9.35f, frame.GetMinY() - 15.5f), new CGPoint(frame.GetMinX() - 13.5f, frame.GetMinY() - 13.55f), new CGPoint(frame.GetMinX() - 11.65f, frame.GetMinY() - 15.5f));
                    clip3Path.AddLineTo(new CGPoint(frame.GetMinX() + 740.35f, frame.GetMinY() - 15.5f));
                    clip3Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 744.5f, frame.GetMinY() - 11.14f), new CGPoint(frame.GetMinX() + 742.64f, frame.GetMinY() - 15.5f), new CGPoint(frame.GetMinX() + 744.5f, frame.GetMinY() - 13.56f));
                    clip3Path.AddLineTo(new CGPoint(frame.GetMinX() + 744.5f, frame.GetMinY() + 322.14f));
                    clip3Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 740.35f, frame.GetMinY() + 326.5f), new CGPoint(frame.GetMinX() + 744.5f, frame.GetMinY() + 324.55f), new CGPoint(frame.GetMinX() + 742.65f, frame.GetMinY() + 326.5f));
                    clip3Path.AddLineTo(new CGPoint(frame.GetMinX() - 9.35f, frame.GetMinY() + 326.5f));
                    clip3Path.AddCurveToPoint(new CGPoint(frame.GetMinX() - 13.5f, frame.GetMinY() + 322.14f), new CGPoint(frame.GetMinX() - 11.64f, frame.GetMinY() + 326.5f), new CGPoint(frame.GetMinX() - 13.5f, frame.GetMinY() + 324.56f));
                    clip3Path.AddLineTo(new CGPoint(frame.GetMinX() - 13.5f, frame.GetMinY() - 11.14f));
                    clip3Path.ClosePath();
                    clip3Path.UsesEvenOddFillRule = true;

                    clip3Path.AddClip();


                    //// Bezier 4 Drawing
                    UIBezierPath bezier4Path = new UIBezierPath();
                    bezier4Path.MoveTo(new CGPoint(frame.GetMinX() - 13.5f, frame.GetMinY() - 11.14f));
                    bezier4Path.AddCurveToPoint(new CGPoint(frame.GetMinX() - 9.35f, frame.GetMinY() - 15.5f), new CGPoint(frame.GetMinX() - 13.5f, frame.GetMinY() - 13.55f), new CGPoint(frame.GetMinX() - 11.65f, frame.GetMinY() - 15.5f));
                    bezier4Path.AddLineTo(new CGPoint(frame.GetMinX() + 740.35f, frame.GetMinY() - 15.5f));
                    bezier4Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 744.5f, frame.GetMinY() - 11.14f), new CGPoint(frame.GetMinX() + 742.64f, frame.GetMinY() - 15.5f), new CGPoint(frame.GetMinX() + 744.5f, frame.GetMinY() - 13.56f));
                    bezier4Path.AddLineTo(new CGPoint(frame.GetMinX() + 744.5f, frame.GetMinY() + 322.14f));
                    bezier4Path.AddCurveToPoint(new CGPoint(frame.GetMinX() + 740.35f, frame.GetMinY() + 326.5f), new CGPoint(frame.GetMinX() + 744.5f, frame.GetMinY() + 324.55f), new CGPoint(frame.GetMinX() + 742.65f, frame.GetMinY() + 326.5f));
                    bezier4Path.AddLineTo(new CGPoint(frame.GetMinX() - 9.35f, frame.GetMinY() + 326.5f));
                    bezier4Path.AddCurveToPoint(new CGPoint(frame.GetMinX() - 13.5f, frame.GetMinY() + 322.14f), new CGPoint(frame.GetMinX() - 11.64f, frame.GetMinY() + 326.5f), new CGPoint(frame.GetMinX() - 13.5f, frame.GetMinY() + 324.56f));
                    bezier4Path.AddLineTo(new CGPoint(frame.GetMinX() - 13.5f, frame.GetMinY() - 11.14f));
                    bezier4Path.ClosePath();
                    strokeColor2.SetStroke();
                    bezier4Path.LineWidth = 2.0f;
                    bezier4Path.Stroke();


                    context.EndTransparencyLayer();
                    context.RestoreState();
                }


                //// Bezier 6 Drawing
                UIBezierPath bezier6Path = new UIBezierPath();
                bezier6Path.MoveTo(new CGPoint(frame.GetMinX() + 36.0f, frame.GetMinY() + 155.6f));
                bezier6Path.AddLineTo(new CGPoint(frame.GetMinX() + 696.0f, frame.GetMinY() + 155.6f));
                bezier6Path.LineCapStyle = CGLineCap.Square;

                strokeColor.SetStroke();
                bezier6Path.LineWidth = 1.0f;
                bezier6Path.Stroke();
            }

        }

    
    }
}

