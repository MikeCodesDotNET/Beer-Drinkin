using System;
using UIKit;
using System.ComponentModel;
using Foundation;
using CoreGraphics;

namespace BeerDrinkin.iOS.CustomControls
{
    [Register("TrendingBeerBackground"), DesignTimeVisible(true)]
    public class TrendingBeerBackground : UIButton
    {
        public TrendingBeerBackground()
        {
        }

        public TrendingBeerBackground(IntPtr p): base(p){}

        public override void Draw(CGRect rect)
        {
            DrawCanvas(rect);
        }

        void DrawCanvas(CGRect frame2)
        {
            //// General Declarations
            var context = UIGraphics.GetCurrentContext();

            //// Color Declarations
            var fillColor = UIColor.FromRGBA(1.000f, 1.000f, 1.000f, 1.000f);
            var strokeColor = UIColor.FromRGBA(0.807f, 0.807f, 0.807f, 1.000f);
            var strokeColor2 = UIColor.FromRGBA(0.851f, 0.851f, 0.851f, 1.000f);

            //// Frames
            CGRect frame = new CGRect(1.0f, 0.0f, 771.0f, 356.0f);

            //// Subframes
            CGRect group3 = new CGRect(frame.GetMinX(), frame.GetMinY(), frame.Width, frame.Height);
            CGRect group5 = new CGRect(frame.GetMinX() + 3.0f, frame.GetMinY() + 3.0f, frame.Width - 7.0f, frame.Height - 7.0f);


            //// Group 2
            {
                //// Group 3
                {
                    context.SaveState();
                    context.BeginTransparencyLayer();

                    //// Clip Clip 2
                    UIBezierPath clip2Path = new UIBezierPath();
                    clip2Path.MoveTo(new CGPoint(group3.GetMinX() + 0.00130f * group3.Width, group3.GetMinY() + 0.00000f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 1.00130f * group3.Width, group3.GetMinY() + 0.00000f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 1.00130f * group3.Width, group3.GetMinY() + 1.00000f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 0.00130f * group3.Width, group3.GetMinY() + 1.00000f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 0.00130f * group3.Width, group3.GetMinY() + 0.00000f * group3.Height));
                    clip2Path.ClosePath();
                    clip2Path.MoveTo(new CGPoint(group3.GetMinX() + 0.02853f * group3.Width, group3.GetMinY() + 0.06901f * group3.Height));
                    clip2Path.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.03307f * group3.Width, group3.GetMinY() + 0.05915f * group3.Height), new CGPoint(group3.GetMinX() + 0.02853f * group3.Width, group3.GetMinY() + 0.06356f * group3.Height), new CGPoint(group3.GetMinX() + 0.03056f * group3.Width, group3.GetMinY() + 0.05915f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 0.96953f * group3.Width, group3.GetMinY() + 0.05915f * group3.Height));
                    clip2Path.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.97406f * group3.Width, group3.GetMinY() + 0.06901f * group3.Height), new CGPoint(group3.GetMinX() + 0.97203f * group3.Width, group3.GetMinY() + 0.05915f * group3.Height), new CGPoint(group3.GetMinX() + 0.97406f * group3.Width, group3.GetMinY() + 0.06356f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 0.97406f * group3.Width, group3.GetMinY() + 0.93099f * group3.Height));
                    clip2Path.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.96953f * group3.Width, group3.GetMinY() + 0.94085f * group3.Height), new CGPoint(group3.GetMinX() + 0.97406f * group3.Width, group3.GetMinY() + 0.93644f * group3.Height), new CGPoint(group3.GetMinX() + 0.97204f * group3.Width, group3.GetMinY() + 0.94085f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 0.03307f * group3.Width, group3.GetMinY() + 0.94085f * group3.Height));
                    clip2Path.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.02853f * group3.Width, group3.GetMinY() + 0.93099f * group3.Height), new CGPoint(group3.GetMinX() + 0.03056f * group3.Width, group3.GetMinY() + 0.94085f * group3.Height), new CGPoint(group3.GetMinX() + 0.02853f * group3.Width, group3.GetMinY() + 0.93644f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 0.02853f * group3.Width, group3.GetMinY() + 0.06901f * group3.Height));
                    clip2Path.ClosePath();
                    clip2Path.MoveTo(new CGPoint(group3.GetMinX() + 0.02724f * group3.Width, group3.GetMinY() + 0.06901f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 0.02724f * group3.Width, group3.GetMinY() + 0.93099f * group3.Height));
                    clip2Path.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.03307f * group3.Width, group3.GetMinY() + 0.94366f * group3.Height), new CGPoint(group3.GetMinX() + 0.02724f * group3.Width, group3.GetMinY() + 0.93800f * group3.Height), new CGPoint(group3.GetMinX() + 0.02984f * group3.Width, group3.GetMinY() + 0.94366f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 0.96953f * group3.Width, group3.GetMinY() + 0.94366f * group3.Height));
                    clip2Path.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.97536f * group3.Width, group3.GetMinY() + 0.93099f * group3.Height), new CGPoint(group3.GetMinX() + 0.97275f * group3.Width, group3.GetMinY() + 0.94366f * group3.Height), new CGPoint(group3.GetMinX() + 0.97536f * group3.Width, group3.GetMinY() + 0.93799f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 0.97536f * group3.Width, group3.GetMinY() + 0.06901f * group3.Height));
                    clip2Path.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.96953f * group3.Width, group3.GetMinY() + 0.05634f * group3.Height), new CGPoint(group3.GetMinX() + 0.97536f * group3.Width, group3.GetMinY() + 0.06200f * group3.Height), new CGPoint(group3.GetMinX() + 0.97275f * group3.Width, group3.GetMinY() + 0.05634f * group3.Height));
                    clip2Path.AddLineTo(new CGPoint(group3.GetMinX() + 0.03307f * group3.Width, group3.GetMinY() + 0.05634f * group3.Height));
                    clip2Path.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.02724f * group3.Width, group3.GetMinY() + 0.06901f * group3.Height), new CGPoint(group3.GetMinX() + 0.02984f * group3.Width, group3.GetMinY() + 0.05634f * group3.Height), new CGPoint(group3.GetMinX() + 0.02724f * group3.Width, group3.GetMinY() + 0.06201f * group3.Height));
                    clip2Path.ClosePath();
                    clip2Path.UsesEvenOddFillRule = true;

                    clip2Path.AddClip();


                    //// Group 4
                    {
                        context.SaveState();
                        context.BeginTransparencyLayer();

                        //// Clip Clip
                        UIBezierPath clipPath = new UIBezierPath();
                        clipPath.MoveTo(new CGPoint(group3.GetMinX() + 0.00065f * group3.Width, group3.GetMinY() + 0.00425f * group3.Height));
                        clipPath.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.00583f * group3.Width, group3.GetMinY() + -0.00702f * group3.Height), new CGPoint(group3.GetMinX() + 0.00065f * group3.Width, group3.GetMinY() + -0.00198f * group3.Height), new CGPoint(group3.GetMinX() + 0.00296f * group3.Width, group3.GetMinY() + -0.00702f * group3.Height));
                        clipPath.AddLineTo(new CGPoint(group3.GetMinX() + 0.94229f * group3.Width, group3.GetMinY() + -0.00702f * group3.Height));
                        clipPath.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.94747f * group3.Width, group3.GetMinY() + 0.00425f * group3.Height), new CGPoint(group3.GetMinX() + 0.94515f * group3.Width, group3.GetMinY() + -0.00702f * group3.Height), new CGPoint(group3.GetMinX() + 0.94747f * group3.Width, group3.GetMinY() + -0.00199f * group3.Height));
                        clipPath.AddLineTo(new CGPoint(group3.GetMinX() + 0.94747f * group3.Width, group3.GetMinY() + 0.86654f * group3.Height));
                        clipPath.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.94229f * group3.Width, group3.GetMinY() + 0.87781f * group3.Height), new CGPoint(group3.GetMinX() + 0.94747f * group3.Width, group3.GetMinY() + 0.87276f * group3.Height), new CGPoint(group3.GetMinX() + 0.94516f * group3.Width, group3.GetMinY() + 0.87781f * group3.Height));
                        clipPath.AddLineTo(new CGPoint(group3.GetMinX() + 0.00583f * group3.Width, group3.GetMinY() + 0.87781f * group3.Height));
                        clipPath.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.00065f * group3.Width, group3.GetMinY() + 0.86654f * group3.Height), new CGPoint(group3.GetMinX() + 0.00297f * group3.Width, group3.GetMinY() + 0.87781f * group3.Height), new CGPoint(group3.GetMinX() + 0.00065f * group3.Width, group3.GetMinY() + 0.87278f * group3.Height));
                        clipPath.AddLineTo(new CGPoint(group3.GetMinX() + 0.00065f * group3.Width, group3.GetMinY() + 0.00425f * group3.Height));
                        clipPath.ClosePath();
                        clipPath.UsesEvenOddFillRule = true;

                        clipPath.AddClip();


                        //// Bezier Drawing
                        UIBezierPath bezierPath = new UIBezierPath();
                        bezierPath.MoveTo(new CGPoint(group3.GetMinX() + 0.00065f * group3.Width, group3.GetMinY() + 0.00425f * group3.Height));
                        bezierPath.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.00583f * group3.Width, group3.GetMinY() + -0.00702f * group3.Height), new CGPoint(group3.GetMinX() + 0.00065f * group3.Width, group3.GetMinY() + -0.00198f * group3.Height), new CGPoint(group3.GetMinX() + 0.00296f * group3.Width, group3.GetMinY() + -0.00702f * group3.Height));
                        bezierPath.AddLineTo(new CGPoint(group3.GetMinX() + 0.94229f * group3.Width, group3.GetMinY() + -0.00702f * group3.Height));
                        bezierPath.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.94747f * group3.Width, group3.GetMinY() + 0.00425f * group3.Height), new CGPoint(group3.GetMinX() + 0.94515f * group3.Width, group3.GetMinY() + -0.00702f * group3.Height), new CGPoint(group3.GetMinX() + 0.94747f * group3.Width, group3.GetMinY() + -0.00199f * group3.Height));
                        bezierPath.AddLineTo(new CGPoint(group3.GetMinX() + 0.94747f * group3.Width, group3.GetMinY() + 0.86654f * group3.Height));
                        bezierPath.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.94229f * group3.Width, group3.GetMinY() + 0.87781f * group3.Height), new CGPoint(group3.GetMinX() + 0.94747f * group3.Width, group3.GetMinY() + 0.87276f * group3.Height), new CGPoint(group3.GetMinX() + 0.94516f * group3.Width, group3.GetMinY() + 0.87781f * group3.Height));
                        bezierPath.AddLineTo(new CGPoint(group3.GetMinX() + 0.00583f * group3.Width, group3.GetMinY() + 0.87781f * group3.Height));
                        bezierPath.AddCurveToPoint(new CGPoint(group3.GetMinX() + 0.00065f * group3.Width, group3.GetMinY() + 0.86654f * group3.Height), new CGPoint(group3.GetMinX() + 0.00297f * group3.Width, group3.GetMinY() + 0.87781f * group3.Height), new CGPoint(group3.GetMinX() + 0.00065f * group3.Width, group3.GetMinY() + 0.87278f * group3.Height));
                        bezierPath.AddLineTo(new CGPoint(group3.GetMinX() + 0.00065f * group3.Width, group3.GetMinY() + 0.00425f * group3.Height));
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
                    clip3Path.MoveTo(new CGPoint(group5.GetMinX() + 0.00131f * group5.Width, group5.GetMinY() + 0.01273f * group5.Height));
                    clip3Path.AddCurveToPoint(new CGPoint(group5.GetMinX() + 0.00678f * group5.Width, group5.GetMinY() + 0.00000f * group5.Height), new CGPoint(group5.GetMinX() + 0.00131f * group5.Width, group5.GetMinY() + 0.00570f * group5.Height), new CGPoint(group5.GetMinX() + 0.00375f * group5.Width, group5.GetMinY() + 0.00000f * group5.Height));
                    clip3Path.AddLineTo(new CGPoint(group5.GetMinX() + 0.99584f * group5.Width, group5.GetMinY() + 0.00000f * group5.Height));
                    clip3Path.AddCurveToPoint(new CGPoint(group5.GetMinX() + 1.00131f * group5.Width, group5.GetMinY() + 0.01273f * group5.Height), new CGPoint(group5.GetMinX() + 0.99886f * group5.Width, group5.GetMinY() + 0.00000f * group5.Height), new CGPoint(group5.GetMinX() + 1.00131f * group5.Width, group5.GetMinY() + 0.00569f * group5.Height));
                    clip3Path.AddLineTo(new CGPoint(group5.GetMinX() + 1.00131f * group5.Width, group5.GetMinY() + 0.98727f * group5.Height));
                    clip3Path.AddCurveToPoint(new CGPoint(group5.GetMinX() + 0.99584f * group5.Width, group5.GetMinY() + 1.00000f * group5.Height), new CGPoint(group5.GetMinX() + 1.00131f * group5.Width, group5.GetMinY() + 0.99430f * group5.Height), new CGPoint(group5.GetMinX() + 0.99887f * group5.Width, group5.GetMinY() + 1.00000f * group5.Height));
                    clip3Path.AddLineTo(new CGPoint(group5.GetMinX() + 0.00678f * group5.Width, group5.GetMinY() + 1.00000f * group5.Height));
                    clip3Path.AddCurveToPoint(new CGPoint(group5.GetMinX() + 0.00131f * group5.Width, group5.GetMinY() + 0.98727f * group5.Height), new CGPoint(group5.GetMinX() + 0.00376f * group5.Width, group5.GetMinY() + 1.00000f * group5.Height), new CGPoint(group5.GetMinX() + 0.00131f * group5.Width, group5.GetMinY() + 0.99431f * group5.Height));
                    clip3Path.AddLineTo(new CGPoint(group5.GetMinX() + 0.00131f * group5.Width, group5.GetMinY() + 0.01273f * group5.Height));
                    clip3Path.ClosePath();
                    clip3Path.UsesEvenOddFillRule = true;

                    clip3Path.AddClip();


                    //// Bezier 4 Drawing
                    UIBezierPath bezier4Path = new UIBezierPath();
                    bezier4Path.MoveTo(new CGPoint(group5.GetMinX() + 0.00131f * group5.Width, group5.GetMinY() + 0.01273f * group5.Height));
                    bezier4Path.AddCurveToPoint(new CGPoint(group5.GetMinX() + 0.00678f * group5.Width, group5.GetMinY() + 0.00000f * group5.Height), new CGPoint(group5.GetMinX() + 0.00131f * group5.Width, group5.GetMinY() + 0.00570f * group5.Height), new CGPoint(group5.GetMinX() + 0.00375f * group5.Width, group5.GetMinY() + 0.00000f * group5.Height));
                    bezier4Path.AddLineTo(new CGPoint(group5.GetMinX() + 0.99584f * group5.Width, group5.GetMinY() + 0.00000f * group5.Height));
                    bezier4Path.AddCurveToPoint(new CGPoint(group5.GetMinX() + 1.00131f * group5.Width, group5.GetMinY() + 0.01273f * group5.Height), new CGPoint(group5.GetMinX() + 0.99886f * group5.Width, group5.GetMinY() + 0.00000f * group5.Height), new CGPoint(group5.GetMinX() + 1.00131f * group5.Width, group5.GetMinY() + 0.00569f * group5.Height));
                    bezier4Path.AddLineTo(new CGPoint(group5.GetMinX() + 1.00131f * group5.Width, group5.GetMinY() + 0.98727f * group5.Height));
                    bezier4Path.AddCurveToPoint(new CGPoint(group5.GetMinX() + 0.99584f * group5.Width, group5.GetMinY() + 1.00000f * group5.Height), new CGPoint(group5.GetMinX() + 1.00131f * group5.Width, group5.GetMinY() + 0.99430f * group5.Height), new CGPoint(group5.GetMinX() + 0.99887f * group5.Width, group5.GetMinY() + 1.00000f * group5.Height));
                    bezier4Path.AddLineTo(new CGPoint(group5.GetMinX() + 0.00678f * group5.Width, group5.GetMinY() + 1.00000f * group5.Height));
                    bezier4Path.AddCurveToPoint(new CGPoint(group5.GetMinX() + 0.00131f * group5.Width, group5.GetMinY() + 0.98727f * group5.Height), new CGPoint(group5.GetMinX() + 0.00376f * group5.Width, group5.GetMinY() + 1.00000f * group5.Height), new CGPoint(group5.GetMinX() + 0.00131f * group5.Width, group5.GetMinY() + 0.99431f * group5.Height));
                    bezier4Path.AddLineTo(new CGPoint(group5.GetMinX() + 0.00131f * group5.Width, group5.GetMinY() + 0.01273f * group5.Height));
                    bezier4Path.ClosePath();
                    strokeColor2.SetStroke();
                    bezier4Path.LineWidth = 2.0f;
                    bezier4Path.Stroke();


                    context.EndTransparencyLayer();
                    context.RestoreState();
                }


                //// Bezier 6 Drawing
                UIBezierPath bezier6Path = new UIBezierPath();
                bezier6Path.MoveTo(new CGPoint(frame.GetMinX() + 0.04789f * frame.Width, frame.GetMinY() + 0.43141f * frame.Height));
                bezier6Path.AddLineTo(new CGPoint(frame.GetMinX() + 0.90281f * frame.Width, frame.GetMinY() + 0.43141f * frame.Height));
                bezier6Path.LineCapStyle = CGLineCap.Square;

                strokeColor.SetStroke();
                bezier6Path.LineWidth = 1.0f;
                bezier6Path.Stroke();
            }

        }

    }
}

