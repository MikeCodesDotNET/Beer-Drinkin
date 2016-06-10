using System;
using UIKit;
using CoreGraphics;
using System.ComponentModel;
using Foundation;

namespace BeerDrinkin.iOS.CustomControls
{
    public class BeerLoadingView : UIView
    {
        public BeerLoadingView (IntPtr handle) : base (handle)
        {
        }

        UIColor Green = UIColor.FromRGBA(0.292f, 0.788f, 0.709f, 1.000f);
        UIColor OffWhite = UIColor.FromRGBA(0.973f, 0.973f, 0.973f, 1.000f);
        UIColor SimpleWhite = UIColor.FromRGBA(1.000f, 1.000f, 1.000f, 1.000f);


        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            DrawBeerLoader(rect, Percentage);
        }

        int percentage;
        public int Percentage
        {
            get
            {
                return percentage;
            }
            set
            {
                percentage = value;
                SetNeedsDisplay();
            }
        }

        void DrawBeerLoader(CGRect frame, float percentage)
        {
            var fillColor4 = UIColor.FromRGBA(0.963f, 0.836f, 0.300f, 1.000f);
            var fillColor9 = UIColor.FromRGBA(0.833f, 0.723f, 0.260f, 1.000f);

            var expression = 450.0f - 360.0f / 100.0f * percentage;
            var expression2 = 180.0f - 360.0f / 100.0f * percentage;


            CGRect background = new CGRect(frame.GetMinX() + NMath.Floor(frame.Width * 0.00017f + 0.41f) + 0.09f, frame.GetMinY() + NMath.Floor(frame.Height * 0.00016f + 0.23f) + 0.27f, NMath.Floor(frame.Width * 0.99950f - 0.24f) - NMath.Floor(frame.Width * 0.00017f + 0.41f) + 0.65f, NMath.Floor(frame.Height * 0.98998f - 0.42f) - NMath.Floor(frame.Height * 0.00016f + 0.23f) + 0.65f);
            CGRect beer = new CGRect(frame.GetMinX() + NMath.Floor(frame.Width * 0.33565f - 0.05f) + 0.55f, frame.GetMinY() + NMath.Floor(frame.Height * 0.22329f + 0.0f) + 0.5f, NMath.Floor(frame.Width * 0.71844f - 0.4f) - NMath.Floor(frame.Width * 0.33565f - 0.05f) + 0.35f, NMath.Floor(frame.Height * 0.72339f - 0.05f) - NMath.Floor(frame.Height * 0.22329f + 0.0f) + 0.05f);

            {
                UIBezierPath bezierPath = new UIBezierPath();
                bezierPath.MoveTo(new CGPoint(background.GetMinX() + 0.94794f * background.Width, background.GetMinY() + 0.58913f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.96205f * background.Width, background.GetMinY() + 0.69140f * background.Height), new CGPoint(background.GetMinX() + 0.94178f * background.Width, background.GetMinY() + 0.62023f * background.Height), new CGPoint(background.GetMinX() + 0.97392f * background.Width, background.GetMinY() + 0.66278f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.87973f * background.Width, background.GetMinY() + 0.75370f * background.Height), new CGPoint(background.GetMinX() + 0.94998f * background.Width, background.GetMinY() + 0.72052f * background.Height), new CGPoint(background.GetMinX() + 0.89706f * background.Width, background.GetMinY() + 0.72781f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.85355f * background.Width, background.GetMinY() + 0.85355f * background.Height), new CGPoint(background.GetMinX() + 0.86227f * background.Width, background.GetMinY() + 0.77977f * background.Height), new CGPoint(background.GetMinX() + 0.87567f * background.Width, background.GetMinY() + 0.83144f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.75369f * background.Width, background.GetMinY() + 0.87973f * background.Height), new CGPoint(background.GetMinX() + 0.83144f * background.Width, background.GetMinY() + 0.87567f * background.Height), new CGPoint(background.GetMinX() + 0.77977f * background.Width, background.GetMinY() + 0.86227f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.69139f * background.Width, background.GetMinY() + 0.96205f * background.Height), new CGPoint(background.GetMinX() + 0.72781f * background.Width, background.GetMinY() + 0.89706f * background.Height), new CGPoint(background.GetMinX() + 0.72051f * background.Width, background.GetMinY() + 0.94998f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.63742f * background.Width, background.GetMinY() + 0.95593f * background.Height), new CGPoint(background.GetMinX() + 0.67609f * background.Width, background.GetMinY() + 0.96840f * background.Height), new CGPoint(background.GetMinX() + 0.65681f * background.Width, background.GetMinY() + 0.96216f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.58913f * background.Width, background.GetMinY() + 0.94793f * background.Height), new CGPoint(background.GetMinX() + 0.62055f * background.Width, background.GetMinY() + 0.95050f * background.Height), new CGPoint(background.GetMinX() + 0.60360f * background.Width, background.GetMinY() + 0.94507f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.50000f * background.Width, background.GetMinY() + 1.00000f * background.Height), new CGPoint(background.GetMinX() + 0.55894f * background.Width, background.GetMinY() + 0.95391f * background.Height), new CGPoint(background.GetMinX() + 0.53194f * background.Width, background.GetMinY() + 1.00000f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.41087f * background.Width, background.GetMinY() + 0.94793f * background.Height), new CGPoint(background.GetMinX() + 0.46806f * background.Width, background.GetMinY() + 1.00000f * background.Height), new CGPoint(background.GetMinX() + 0.44106f * background.Width, background.GetMinY() + 0.95391f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.36258f * background.Width, background.GetMinY() + 0.95593f * background.Height), new CGPoint(background.GetMinX() + 0.39640f * background.Width, background.GetMinY() + 0.94507f * background.Height), new CGPoint(background.GetMinX() + 0.37945f * background.Width, background.GetMinY() + 0.95050f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.30861f * background.Width, background.GetMinY() + 0.96205f * background.Height), new CGPoint(background.GetMinX() + 0.34319f * background.Width, background.GetMinY() + 0.96216f * background.Height), new CGPoint(background.GetMinX() + 0.32391f * background.Width, background.GetMinY() + 0.96840f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.24631f * background.Width, background.GetMinY() + 0.87973f * background.Height), new CGPoint(background.GetMinX() + 0.27949f * background.Width, background.GetMinY() + 0.94998f * background.Height), new CGPoint(background.GetMinX() + 0.27219f * background.Width, background.GetMinY() + 0.89705f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.14645f * background.Width, background.GetMinY() + 0.85355f * background.Height), new CGPoint(background.GetMinX() + 0.22023f * background.Width, background.GetMinY() + 0.86227f * background.Height), new CGPoint(background.GetMinX() + 0.16856f * background.Width, background.GetMinY() + 0.87567f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.12027f * background.Width, background.GetMinY() + 0.75369f * background.Height), new CGPoint(background.GetMinX() + 0.12433f * background.Width, background.GetMinY() + 0.83144f * background.Height), new CGPoint(background.GetMinX() + 0.13773f * background.Width, background.GetMinY() + 0.77977f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.03795f * background.Width, background.GetMinY() + 0.69139f * background.Height), new CGPoint(background.GetMinX() + 0.10294f * background.Width, background.GetMinY() + 0.72781f * background.Height), new CGPoint(background.GetMinX() + 0.05002f * background.Width, background.GetMinY() + 0.72051f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.05207f * background.Width, background.GetMinY() + 0.58913f * background.Height), new CGPoint(background.GetMinX() + 0.02608f * background.Width, background.GetMinY() + 0.66277f * background.Height), new CGPoint(background.GetMinX() + 0.05822f * background.Width, background.GetMinY() + 0.62023f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.00000f * background.Width, background.GetMinY() + 0.50000f * background.Height), new CGPoint(background.GetMinX() + 0.04609f * background.Width, background.GetMinY() + 0.55894f * background.Height), new CGPoint(background.GetMinX() + 0.00000f * background.Width, background.GetMinY() + 0.53194f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.05207f * background.Width, background.GetMinY() + 0.41087f * background.Height), new CGPoint(background.GetMinX() + 0.00000f * background.Width, background.GetMinY() + 0.46806f * background.Height), new CGPoint(background.GetMinX() + 0.04609f * background.Width, background.GetMinY() + 0.44106f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.03795f * background.Width, background.GetMinY() + 0.30861f * background.Height), new CGPoint(background.GetMinX() + 0.05822f * background.Width, background.GetMinY() + 0.37976f * background.Height), new CGPoint(background.GetMinX() + 0.02608f * background.Width, background.GetMinY() + 0.33723f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.12027f * background.Width, background.GetMinY() + 0.24631f * background.Height), new CGPoint(background.GetMinX() + 0.05002f * background.Width, background.GetMinY() + 0.27949f * background.Height), new CGPoint(background.GetMinX() + 0.10294f * background.Width, background.GetMinY() + 0.27219f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.14645f * background.Width, background.GetMinY() + 0.14644f * background.Height), new CGPoint(background.GetMinX() + 0.13773f * background.Width, background.GetMinY() + 0.22023f * background.Height), new CGPoint(background.GetMinX() + 0.12433f * background.Width, background.GetMinY() + 0.16856f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.24631f * background.Width, background.GetMinY() + 0.12027f * background.Height), new CGPoint(background.GetMinX() + 0.16856f * background.Width, background.GetMinY() + 0.12433f * background.Height), new CGPoint(background.GetMinX() + 0.22023f * background.Width, background.GetMinY() + 0.13773f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.30861f * background.Width, background.GetMinY() + 0.03795f * background.Height), new CGPoint(background.GetMinX() + 0.27219f * background.Width, background.GetMinY() + 0.10294f * background.Height), new CGPoint(background.GetMinX() + 0.27949f * background.Width, background.GetMinY() + 0.05002f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.36258f * background.Width, background.GetMinY() + 0.04407f * background.Height), new CGPoint(background.GetMinX() + 0.32391f * background.Width, background.GetMinY() + 0.03160f * background.Height), new CGPoint(background.GetMinX() + 0.34319f * background.Width, background.GetMinY() + 0.03784f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.41087f * background.Width, background.GetMinY() + 0.05206f * background.Height), new CGPoint(background.GetMinX() + 0.37945f * background.Width, background.GetMinY() + 0.04950f * background.Height), new CGPoint(background.GetMinX() + 0.39640f * background.Width, background.GetMinY() + 0.05493f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.50000f * background.Width, background.GetMinY() + 0.00000f * background.Height), new CGPoint(background.GetMinX() + 0.44106f * background.Width, background.GetMinY() + 0.04609f * background.Height), new CGPoint(background.GetMinX() + 0.46806f * background.Width, background.GetMinY() + 0.00000f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.58913f * background.Width, background.GetMinY() + 0.05206f * background.Height), new CGPoint(background.GetMinX() + 0.53194f * background.Width, background.GetMinY() + 0.00000f * background.Height), new CGPoint(background.GetMinX() + 0.55894f * background.Width, background.GetMinY() + 0.04609f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.63742f * background.Width, background.GetMinY() + 0.04407f * background.Height), new CGPoint(background.GetMinX() + 0.60360f * background.Width, background.GetMinY() + 0.05493f * background.Height), new CGPoint(background.GetMinX() + 0.62055f * background.Width, background.GetMinY() + 0.04950f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.69140f * background.Width, background.GetMinY() + 0.03795f * background.Height), new CGPoint(background.GetMinX() + 0.65681f * background.Width, background.GetMinY() + 0.03784f * background.Height), new CGPoint(background.GetMinX() + 0.67609f * background.Width, background.GetMinY() + 0.03160f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.75369f * background.Width, background.GetMinY() + 0.12027f * background.Height), new CGPoint(background.GetMinX() + 0.72051f * background.Width, background.GetMinY() + 0.05002f * background.Height), new CGPoint(background.GetMinX() + 0.72781f * background.Width, background.GetMinY() + 0.10294f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.85356f * background.Width, background.GetMinY() + 0.14645f * background.Height), new CGPoint(background.GetMinX() + 0.77977f * background.Width, background.GetMinY() + 0.13773f * background.Height), new CGPoint(background.GetMinX() + 0.83144f * background.Width, background.GetMinY() + 0.12433f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.87973f * background.Width, background.GetMinY() + 0.24631f * background.Height), new CGPoint(background.GetMinX() + 0.87567f * background.Width, background.GetMinY() + 0.16856f * background.Height), new CGPoint(background.GetMinX() + 0.86227f * background.Width, background.GetMinY() + 0.22023f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.96206f * background.Width, background.GetMinY() + 0.30861f * background.Height), new CGPoint(background.GetMinX() + 0.89706f * background.Width, background.GetMinY() + 0.27219f * background.Height), new CGPoint(background.GetMinX() + 0.94998f * background.Width, background.GetMinY() + 0.27949f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.94794f * background.Width, background.GetMinY() + 0.41087f * background.Height), new CGPoint(background.GetMinX() + 0.97392f * background.Width, background.GetMinY() + 0.33723f * background.Height), new CGPoint(background.GetMinX() + 0.94178f * background.Width, background.GetMinY() + 0.37976f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 1.00000f * background.Width, background.GetMinY() + 0.50000f * background.Height), new CGPoint(background.GetMinX() + 0.95391f * background.Width, background.GetMinY() + 0.44106f * background.Height), new CGPoint(background.GetMinX() + 1.00000f * background.Width, background.GetMinY() + 0.46806f * background.Height));
                bezierPath.AddCurveToPoint(new CGPoint(background.GetMinX() + 0.94794f * background.Width, background.GetMinY() + 0.58913f * background.Height), new CGPoint(background.GetMinX() + 1.00000f * background.Width, background.GetMinY() + 0.53194f * background.Height), new CGPoint(background.GetMinX() + 0.95391f * background.Width, background.GetMinY() + 0.55894f * background.Height));
                bezierPath.ClosePath();
                bezierPath.UsesEvenOddFillRule = true;

                this.Green.SetFill();
                bezierPath.Fill();


                var whitePath = UIBezierPath.FromOval(new CGRect(background.GetMinX() + NMath.Floor(background.Width * 0.09115f - 0.41f) + 0.91f, background.GetMinY() + NMath.Floor(background.Height * 0.09203f + 0.47f) + 0.03f, NMath.Floor(background.Width * 0.91052f - 0.11f) - NMath.Floor(background.Width * 0.09115f - 0.41f) - 0.3f, NMath.Floor(background.Height * 0.90967f - 0.23f) - NMath.Floor(background.Height * 0.09203f + 0.47f) + 0.7f));
                this.SimpleWhite.SetFill();
                whitePath.Fill();

                var white2Rect = new CGRect(background.GetMinX() + NMath.Floor(background.Width * 0.08925f - 0.41f) + 0.91f, background.GetMinY() + NMath.Floor(background.Height * 0.09011f + 0.47f) + 0.03f, NMath.Floor(background.Width * 0.91052f - 0.11f) - NMath.Floor(background.Width * 0.08925f - 0.41f) - 0.3f, NMath.Floor(background.Height * 0.90967f - 0.23f) - NMath.Floor(background.Height * 0.09011f + 0.47f) + 0.7f);
                var white2Path = new UIBezierPath();
                white2Path.AddArc(new CGPoint(0.0f, 0.0f), white2Rect.Width / 2.0f, (nfloat)(-expression * NMath.PI/180), (nfloat)(-expression2 * NMath.PI/180.0f), true);
                white2Path.AddLineTo(new CGPoint(0.0f, 0.0f));
                white2Path.ClosePath();

                var white2Transform = CGAffineTransform.MakeScale(1.0f, white2Rect.Height / white2Rect.Width);
                white2Transform.Translate(white2Rect.GetMidX(), white2Rect.GetMidY());
                white2Path.ApplyTransform(white2Transform);

                this.Green.SetFill();
                white2Path.Fill();

                var greenFillerPath = UIBezierPath.FromOval(new CGRect(background.GetMinX() + NMath.Floor(background.Width * 0.09686f - 0.41f) + 0.91f, background.GetMinY() + NMath.Floor(background.Height * 0.09780f - 0.23f) + 0.73f, NMath.Floor(background.Width * 0.90348f - 0.41f) - NMath.Floor(background.Width * 0.09686f - 0.41f), NMath.Floor(background.Height * 0.90257f - 0.23f) - NMath.Floor(background.Height * 0.09780f - 0.23f)));
                this.Green.SetFill();
                greenFillerPath.Fill();
            }


            {
                var ovalPath = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.07499f + 0.4f) + 0.1f, beer.GetMinY() + NMath.Floor(beer.Height * 0.06273f + 0.45f) + 0.05f, NMath.Floor(beer.Width * 0.26124f - 0.1f) - NMath.Floor(beer.Width * 0.07499f + 0.4f) + 0.5f, NMath.Floor(beer.Height * 0.20908f - 0.05f) - NMath.Floor(beer.Height * 0.06273f + 0.45f) + 0.5f));
                OffWhite.SetFill();
                ovalPath.Fill();

                var oval2Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.00000f + 0.5f), beer.GetMinY() + NMath.Floor(beer.Height * 0.15263f + 0.1f) + 0.4f, NMath.Floor(beer.Width * 0.18624f) - NMath.Floor(beer.Width * 0.00000f + 0.5f) + 0.5f, NMath.Floor(beer.Height * 0.29899f - 0.4f) - NMath.Floor(beer.Height * 0.15263f + 0.1f) + 0.5f));
                OffWhite.SetFill();
                oval2Path.Fill();

                var oval3Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.00000f + 0.5f), beer.GetMinY() + NMath.Floor(beer.Height * 0.24881f + 0.5f) + 0.0f, NMath.Floor(beer.Width * 0.13211f - 0.1f) - NMath.Floor(beer.Width * 0.00000f + 0.5f) + 0.6f, NMath.Floor(beer.Height * 0.35373f - 0.1f) - NMath.Floor(beer.Height * 0.24881f + 0.5f) + 0.6f));
                OffWhite.SetFill();
                oval3Path.Fill();

                var oval4Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.00000f + 0.5f), beer.GetMinY() + NMath.Floor(beer.Height * 0.32541f - 0.35f) + 0.85f, NMath.Floor(beer.Width * 0.13211f - 0.1f) - NMath.Floor(beer.Width * 0.00000f + 0.5f) + 0.6f, NMath.Floor(beer.Height * 0.43033f + 0.05f) - NMath.Floor(beer.Height * 0.32541f - 0.35f) - 0.4f));
                OffWhite.SetFill();
                oval4Path.Fill();

                var oval5Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.03526f + 0.4f) + 0.1f, beer.GetMinY() + NMath.Floor(beer.Height * 0.40068f + 0.45f) + 0.05f, NMath.Floor(beer.Width * 0.16737f - 0.2f) - NMath.Floor(beer.Width * 0.03526f + 0.4f) + 0.6f, NMath.Floor(beer.Height * 0.50560f - 0.15f) - NMath.Floor(beer.Height * 0.40068f + 0.45f) + 0.6f));
                OffWhite.SetFill();
                oval5Path.Fill();

                UIBezierPath bezier2Path = new UIBezierPath();
                bezier2Path.MoveTo(new CGPoint(beer.GetMinX() + 0.71340f * beer.Width, beer.GetMinY() + 0.27402f * beer.Height));
                bezier2Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.75623f * beer.Width, beer.GetMinY() + 0.31182f * beer.Height), new CGPoint(beer.GetMinX() + 0.71340f * beer.Width, beer.GetMinY() + 0.27402f * beer.Height), new CGPoint(beer.GetMinX() + 0.72564f * beer.Width, beer.GetMinY() + 0.30342f * beer.Height));
                bezier2Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.91991f * beer.Width, beer.GetMinY() + 0.33162f * beer.Height), new CGPoint(beer.GetMinX() + 0.78618f * beer.Width, beer.GetMinY() + 0.32004f * beer.Height), new CGPoint(beer.GetMinX() + 0.85931f * beer.Width, beer.GetMinY() + 0.30847f * beer.Height));
                bezier2Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.99028f * beer.Width, beer.GetMinY() + 0.67241f * beer.Height), new CGPoint(beer.GetMinX() + 0.97956f * beer.Width, beer.GetMinY() + 0.35442f * beer.Height), new CGPoint(beer.GetMinX() + 1.01934f * beer.Width, beer.GetMinY() + 0.58000f * beer.Height));
                bezier2Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.74374f * beer.Width, beer.GetMinY() + 0.90110f * beer.Height), new CGPoint(beer.GetMinX() + 0.96121f * beer.Width, beer.GetMinY() + 0.76480f * beer.Height), new CGPoint(beer.GetMinX() + 0.71157f * beer.Width, beer.GetMinY() + 0.83870f * beer.Height));
                bezier2Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.70703f * beer.Width, beer.GetMinY() + 0.67071f * beer.Height), new CGPoint(beer.GetMinX() + 0.71927f * beer.Width, beer.GetMinY() + 0.95149f * beer.Height), new CGPoint(beer.GetMinX() + 0.68742f * beer.Width, beer.GetMinY() + 0.70678f * beer.Height));
                bezier2Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.86866f * beer.Width, beer.GetMinY() + 0.70181f * beer.Height), new CGPoint(beer.GetMinX() + 0.72080f * beer.Width, beer.GetMinY() + 0.74270f * beer.Height), new CGPoint(beer.GetMinX() + 0.83654f * beer.Width, beer.GetMinY() + 0.72700f * beer.Height));
                bezier2Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.91685f * beer.Width, beer.GetMinY() + 0.55481f * beer.Height), new CGPoint(beer.GetMinX() + 0.90079f * beer.Width, beer.GetMinY() + 0.67660f * beer.Height), new CGPoint(beer.GetMinX() + 0.93284f * beer.Width, beer.GetMinY() + 0.65992f * beer.Height));
                bezier2Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.87095f * beer.Width, beer.GetMinY() + 0.38322f * beer.Height), new CGPoint(beer.GetMinX() + 0.90085f * beer.Width, beer.GetMinY() + 0.44970f * beer.Height), new CGPoint(beer.GetMinX() + 0.90002f * beer.Width, beer.GetMinY() + 0.39521f * beer.Height));
                bezier2Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.76540f * beer.Width, beer.GetMinY() + 0.38082f * beer.Height), new CGPoint(beer.GetMinX() + 0.84188f * beer.Width, beer.GetMinY() + 0.37122f * beer.Height), new CGPoint(beer.GetMinX() + 0.78988f * beer.Width, beer.GetMinY() + 0.37602f * beer.Height));
                bezier2Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.70116f * beer.Width, beer.GetMinY() + 0.43331f * beer.Height), new CGPoint(beer.GetMinX() + 0.74093f * beer.Width, beer.GetMinY() + 0.38562f * beer.Height), new CGPoint(beer.GetMinX() + 0.70116f * beer.Width, beer.GetMinY() + 0.43331f * beer.Height));
                bezier2Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.71340f * beer.Width, beer.GetMinY() + 0.27402f * beer.Height));
                bezier2Path.ClosePath();
                bezier2Path.UsesEvenOddFillRule = true;

                SimpleWhite.SetFill();
                bezier2Path.Fill();

                UIBezierPath bezier3Path = new UIBezierPath();
                bezier3Path.MoveTo(new CGPoint(beer.GetMinX() + 0.08316f * beer.Width, beer.GetMinY() + 0.83800f * beer.Height));
                bezier3Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.05563f * beer.Width, beer.GetMinY() + 0.95199f * beer.Height));
                bezier3Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.40975f * beer.Width, beer.GetMinY() + 0.98741f * beer.Height), new CGPoint(beer.GetMinX() + 0.05563f * beer.Width, beer.GetMinY() + 0.95199f * beer.Height), new CGPoint(beer.GetMinX() + 0.10382f * beer.Width, beer.GetMinY() + 0.98741f * beer.Height));
                bezier3Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.75623f * beer.Width, beer.GetMinY() + 0.95199f * beer.Height), new CGPoint(beer.GetMinX() + 0.71569f * beer.Width, beer.GetMinY() + 0.98741f * beer.Height), new CGPoint(beer.GetMinX() + 0.75623f * beer.Width, beer.GetMinY() + 0.95199f * beer.Height));
                bezier3Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.73787f * beer.Width, beer.GetMinY() + 0.83800f * beer.Height));
                bezier3Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.41893f * beer.Width, beer.GetMinY() + 0.86680f * beer.Height), new CGPoint(beer.GetMinX() + 0.73787f * beer.Width, beer.GetMinY() + 0.83800f * beer.Height), new CGPoint(beer.GetMinX() + 0.68510f * beer.Width, beer.GetMinY() + 0.86680f * beer.Height));
                bezier3Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.08316f * beer.Width, beer.GetMinY() + 0.83800f * beer.Height), new CGPoint(beer.GetMinX() + 0.15277f * beer.Width, beer.GetMinY() + 0.86680f * beer.Height), new CGPoint(beer.GetMinX() + 0.08316f * beer.Width, beer.GetMinY() + 0.83800f * beer.Height));
                bezier3Path.ClosePath();
                bezier3Path.UsesEvenOddFillRule = true;

                SimpleWhite.SetFill();
                bezier3Path.Fill();

                UIBezierPath bezier4Path = new UIBezierPath();
                bezier4Path.MoveTo(new CGPoint(beer.GetMinX() + 0.08189f * beer.Width, beer.GetMinY() + 0.84290f * beer.Height));
                bezier4Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.11024f * beer.Width, beer.GetMinY() + 0.26059f * beer.Height), new CGPoint(beer.GetMinX() + 0.08189f * beer.Width, beer.GetMinY() + 0.84290f * beer.Height), new CGPoint(beer.GetMinX() + 0.11789f * beer.Width, beer.GetMinY() + 0.37817f * beer.Height));
                bezier4Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.72869f * beer.Width, beer.GetMinY() + 0.28120f * beer.Height), new CGPoint(beer.GetMinX() + 0.56915f * beer.Width, beer.GetMinY() + 0.27150f * beer.Height), new CGPoint(beer.GetMinX() + 0.72869f * beer.Width, beer.GetMinY() + 0.28120f * beer.Height));
                bezier4Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.71951f * beer.Width, beer.GetMinY() + 0.56362f * beer.Height), new CGPoint(beer.GetMinX() + 0.72869f * beer.Width, beer.GetMinY() + 0.28120f * beer.Height), new CGPoint(beer.GetMinX() + 0.71951f * beer.Width, beer.GetMinY() + 0.43635f * beer.Height));
                bezier4Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.73787f * beer.Width, beer.GetMinY() + 0.83756f * beer.Height), new CGPoint(beer.GetMinX() + 0.71951f * beer.Width, beer.GetMinY() + 0.69090f * beer.Height), new CGPoint(beer.GetMinX() + 0.73787f * beer.Width, beer.GetMinY() + 0.83756f * beer.Height));
                bezier4Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.40593f * beer.Width, beer.GetMinY() + 0.88119f * beer.Height), new CGPoint(beer.GetMinX() + 0.73787f * beer.Width, beer.GetMinY() + 0.83756f * beer.Height), new CGPoint(beer.GetMinX() + 0.63538f * beer.Width, beer.GetMinY() + 0.88726f * beer.Height));
                bezier4Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.08189f * beer.Width, beer.GetMinY() + 0.84290f * beer.Height), new CGPoint(beer.GetMinX() + 0.17648f * beer.Width, beer.GetMinY() + 0.87513f * beer.Height), new CGPoint(beer.GetMinX() + 0.08189f * beer.Width, beer.GetMinY() + 0.84290f * beer.Height));
                bezier4Path.ClosePath();
                bezier4Path.UsesEvenOddFillRule = true;

                fillColor4.SetFill();
                bezier4Path.Fill();

                UIBezierPath bezier5Path = new UIBezierPath();
                bezier5Path.MoveTo(new CGPoint(beer.GetMinX() + 0.72835f * beer.Width, beer.GetMinY() + 0.29331f * beer.Height));
                bezier5Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.72835f * beer.Width, beer.GetMinY() + 0.19362f * beer.Height));
                bezier5Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.11621f * beer.Width, beer.GetMinY() + 0.19110f * beer.Height));
                bezier5Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.11073f * beer.Width, beer.GetMinY() + 0.28260f * beer.Height));
                bezier5Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.72835f * beer.Width, beer.GetMinY() + 0.29331f * beer.Height));
                bezier5Path.ClosePath();
                bezier5Path.UsesEvenOddFillRule = true;

                SimpleWhite.SetFill();
                bezier5Path.Fill();

                UIBezierPath bezier6Path = new UIBezierPath();
                bezier6Path.MoveTo(new CGPoint(beer.GetMinX() + 0.07471f * beer.Width, beer.GetMinY() + 0.94603f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.40975f * beer.Width, beer.GetMinY() + 0.97479f * beer.Height), new CGPoint(beer.GetMinX() + 0.09876f * beer.Width, beer.GetMinY() + 0.95447f * beer.Height), new CGPoint(beer.GetMinX() + 0.18051f * beer.Width, beer.GetMinY() + 0.97479f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.73863f * beer.Width, beer.GetMinY() + 0.94607f * beer.Height), new CGPoint(beer.GetMinX() + 0.64454f * beer.Width, beer.GetMinY() + 0.97479f * beer.Height), new CGPoint(beer.GetMinX() + 0.71869f * beer.Width, beer.GetMinY() + 0.95411f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.72181f * beer.Width, beer.GetMinY() + 0.83863f * beer.Height), new CGPoint(beer.GetMinX() + 0.73399f * beer.Width, beer.GetMinY() + 0.92454f * beer.Height), new CGPoint(beer.GetMinX() + 0.72199f * beer.Width, beer.GetMinY() + 0.86626f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.70346f * beer.Width, beer.GetMinY() + 0.56681f * beer.Height), new CGPoint(beer.GetMinX() + 0.72051f * beer.Width, beer.GetMinY() + 0.82816f * beer.Height), new CGPoint(beer.GetMinX() + 0.70346f * beer.Width, beer.GetMinY() + 0.68784f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.70999f * beer.Width, beer.GetMinY() + 0.21141f * beer.Height), new CGPoint(beer.GetMinX() + 0.70346f * beer.Width, beer.GetMinY() + 0.45862f * beer.Height), new CGPoint(beer.GetMinX() + 0.70858f * beer.Width, beer.GetMinY() + 0.26290f * beer.Height));
                bezier6Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.13157f * beer.Width, beer.GetMinY() + 0.20390f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.09795f * beer.Width, beer.GetMinY() + 0.84329f * beer.Height), new CGPoint(beer.GetMinX() + 0.12671f * beer.Width, beer.GetMinY() + 0.29022f * beer.Height), new CGPoint(beer.GetMinX() + 0.09795f * beer.Width, beer.GetMinY() + 0.80316f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.07471f * beer.Width, beer.GetMinY() + 0.94603f * beer.Height), new CGPoint(beer.GetMinX() + 0.09795f * beer.Width, beer.GetMinY() + 0.87907f * beer.Height), new CGPoint(beer.GetMinX() + 0.08216f * beer.Width, beer.GetMinY() + 0.92590f * beer.Height));
                bezier6Path.ClosePath();
                bezier6Path.MoveTo(new CGPoint(beer.GetMinX() + 0.40975f * beer.Width, beer.GetMinY() + 1.00000f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.04465f * beer.Width, beer.GetMinY() + 0.96119f * beer.Height), new CGPoint(beer.GetMinX() + 0.10624f * beer.Width, beer.GetMinY() + 1.00000f * beer.Height), new CGPoint(beer.GetMinX() + 0.05006f * beer.Width, beer.GetMinY() + 0.96517f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.04033f * beer.Width, beer.GetMinY() + 0.94815f * beer.Height), new CGPoint(beer.GetMinX() + 0.04013f * beer.Width, beer.GetMinY() + 0.95786f * beer.Height), new CGPoint(beer.GetMinX() + 0.03844f * beer.Width, beer.GetMinY() + 0.95279f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.06583f * beer.Width, beer.GetMinY() + 0.84329f * beer.Height), new CGPoint(beer.GetMinX() + 0.04059f * beer.Width, beer.GetMinY() + 0.94752f * beer.Height), new CGPoint(beer.GetMinX() + 0.06583f * beer.Width, beer.GetMinY() + 0.88517f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.10017f * beer.Width, beer.GetMinY() + 0.19054f * beer.Height), new CGPoint(beer.GetMinX() + 0.06583f * beer.Width, beer.GetMinY() + 0.79913f * beer.Height), new CGPoint(beer.GetMinX() + 0.09876f * beer.Width, beer.GetMinY() + 0.21537f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.11648f * beer.Width, beer.GetMinY() + 0.17850f * beer.Height), new CGPoint(beer.GetMinX() + 0.10055f * beer.Width, beer.GetMinY() + 0.18373f * beer.Height), new CGPoint(beer.GetMinX() + 0.10770f * beer.Width, beer.GetMinY() + 0.17845f * beer.Height));
                bezier6Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.72667f * beer.Width, beer.GetMinY() + 0.18643f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.73798f * beer.Width, beer.GetMinY() + 0.19029f * beer.Height), new CGPoint(beer.GetMinX() + 0.73094f * beer.Width, beer.GetMinY() + 0.18648f * beer.Height), new CGPoint(beer.GetMinX() + 0.73501f * beer.Width, beer.GetMinY() + 0.18787f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.74246f * beer.Width, beer.GetMinY() + 0.19931f * beer.Height), new CGPoint(beer.GetMinX() + 0.74094f * beer.Width, beer.GetMinY() + 0.19271f * beer.Height), new CGPoint(beer.GetMinX() + 0.74255f * beer.Width, beer.GetMinY() + 0.19595f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.73559f * beer.Width, beer.GetMinY() + 0.56681f * beer.Height), new CGPoint(beer.GetMinX() + 0.74239f * beer.Width, beer.GetMinY() + 0.20172f * beer.Height), new CGPoint(beer.GetMinX() + 0.73559f * beer.Width, beer.GetMinY() + 0.44240f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.75155f * beer.Width, beer.GetMinY() + 0.81696f * beer.Height), new CGPoint(beer.GetMinX() + 0.73559f * beer.Width, beer.GetMinY() + 0.66362f * beer.Height), new CGPoint(beer.GetMinX() + 0.74661f * beer.Width, beer.GetMinY() + 0.77302f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.75393f * beer.Width, beer.GetMinY() + 0.82358f * beer.Height), new CGPoint(beer.GetMinX() + 0.75305f * beer.Width, beer.GetMinY() + 0.81888f * beer.Height), new CGPoint(beer.GetMinX() + 0.75393f * beer.Width, beer.GetMinY() + 0.82115f * beer.Height));
                bezier6Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.75393f * beer.Width, beer.GetMinY() + 0.83800f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.77205f * beer.Width, beer.GetMinY() + 0.94980f * beer.Height), new CGPoint(beer.GetMinX() + 0.75393f * beer.Width, beer.GetMinY() + 0.86897f * beer.Height), new CGPoint(beer.GetMinX() + 0.77186f * beer.Width, beer.GetMinY() + 0.94900f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.76818f * beer.Width, beer.GetMinY() + 0.96041f * beer.Height), new CGPoint(beer.GetMinX() + 0.77291f * beer.Width, beer.GetMinY() + 0.95363f * beer.Height), new CGPoint(beer.GetMinX() + 0.77148f * beer.Width, beer.GetMinY() + 0.95754f * beer.Height));
                bezier6Path.AddCurveToPoint(new CGPoint(beer.GetMinX() + 0.40975f * beer.Width, beer.GetMinY() + 1.00000f * beer.Height), new CGPoint(beer.GetMinX() + 0.76061f * beer.Width, beer.GetMinY() + 0.96702f * beer.Height), new CGPoint(beer.GetMinX() + 0.70776f * beer.Width, beer.GetMinY() + 1.00000f * beer.Height));
                bezier6Path.ClosePath();
                bezier6Path.UsesEvenOddFillRule = true;

                SimpleWhite.SetFill();
                bezier6Path.Fill();

                UIBezierPath bezier7Path = new UIBezierPath();
                bezier7Path.MoveTo(new CGPoint(beer.GetMinX() + 0.70988f * beer.Width, beer.GetMinY() + 0.21792f * beer.Height));
                bezier7Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.13068f * beer.Width, beer.GetMinY() + 0.21792f * beer.Height));
                bezier7Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.13068f * beer.Width, beer.GetMinY() + 0.16404f * beer.Height));
                bezier7Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.70988f * beer.Width, beer.GetMinY() + 0.17446f * beer.Height));
                bezier7Path.AddLineTo(new CGPoint(beer.GetMinX() + 0.70988f * beer.Width, beer.GetMinY() + 0.21792f * beer.Height));
                bezier7Path.ClosePath();
                bezier7Path.UsesEvenOddFillRule = true;

                SimpleWhite.SetFill();
                bezier7Path.Fill();

                var oval6Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.42910f + 0.1f) + 0.4f, beer.GetMinY() + NMath.Floor(beer.Height * 0.65196f - 0.45f) + 0.95f, NMath.Floor(beer.Width * 0.48175f + 0.5f) - NMath.Floor(beer.Width * 0.42910f + 0.1f) - 0.4f, NMath.Floor(beer.Height * 0.69226f - 0.05f) - NMath.Floor(beer.Height * 0.65196f - 0.45f) - 0.4f));
                fillColor9.SetFill();
                oval6Path.Fill();

                var oval7Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.34542f - 0.05f) + 0.55f, beer.GetMinY() + NMath.Floor(beer.Height * 0.55521f - 0.3f) + 0.8f, NMath.Floor(beer.Width * 0.42091f - 0.25f) - NMath.Floor(beer.Width * 0.34542f - 0.05f) + 0.2f, NMath.Floor(beer.Height * 0.61300f + 0.5f) - NMath.Floor(beer.Height * 0.55521f - 0.3f) - 0.8f));
                fillColor9.SetFill();
                oval7Path.Fill();

                var oval8Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.14651f) + 0.5f, beer.GetMinY() + NMath.Floor(beer.Height * 0.76810f - 0.4f) + 0.9f, NMath.Floor(beer.Width * 0.23144f - 0.1f) - NMath.Floor(beer.Width * 0.14651f) + 0.1f, NMath.Floor(beer.Height * 0.83311f + 0.5f) - NMath.Floor(beer.Height * 0.76810f - 0.4f) - 0.9f));
                fillColor9.SetFill();
                oval8Path.Fill();

                var oval9Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.61162f + 0.35f) + 0.15f, beer.GetMinY() + NMath.Floor(beer.Height * 0.74700f + 0.05f) + 0.45f, NMath.Floor(beer.Width * 0.66725f + 0.15f) - NMath.Floor(beer.Width * 0.61162f + 0.35f) + 0.2f, NMath.Floor(beer.Height * 0.78920f - 0.05f) - NMath.Floor(beer.Height * 0.74700f + 0.05f) + 0.1f));
                fillColor9.SetFill();
                oval9Path.Fill();

                var oval10Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.56891f - 0.05f) + 0.55f, beer.GetMinY() + NMath.Floor(beer.Height * 0.62250f + 0.2f) + 0.3f, NMath.Floor(beer.Width * 0.63348f - 0.05f) - NMath.Floor(beer.Width * 0.56891f - 0.05f), NMath.Floor(beer.Height * 0.67192f + 0.2f) - NMath.Floor(beer.Height * 0.62250f + 0.2f)));
                fillColor9.SetFill();
                oval10Path.Fill();

                var oval11Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.34393f + 0.25f) + 0.25f, beer.GetMinY() + NMath.Floor(beer.Height * 0.75631f + 0.2f) + 0.3f, NMath.Floor(beer.Width * 0.42240f + 0.45f) - NMath.Floor(beer.Width * 0.34393f + 0.25f) - 0.2f, NMath.Floor(beer.Height * 0.81638f + 0.4f) - NMath.Floor(beer.Height * 0.75631f + 0.2f) - 0.2f));
                fillColor9.SetFill();
                oval11Path.Fill();

                var oval12Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.61162f + 0.35f) + 0.15f, beer.GetMinY() + NMath.Floor(beer.Height * 0.43661f + 0.5f) + 0.0f, NMath.Floor(beer.Width * 0.64242f + 0.15f) - NMath.Floor(beer.Width * 0.61162f + 0.35f) + 0.2f, NMath.Floor(beer.Height * 0.46018f + 0.3f) - NMath.Floor(beer.Height * 0.43661f + 0.5f) + 0.2f));
                fillColor9.SetFill();
                oval12Path.Fill();

                var oval13Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.22821f - 0.45f) + 0.95f, beer.GetMinY() + NMath.Floor(beer.Height * 0.42482f + 0.4f) + 0.1f, NMath.Floor(beer.Width * 0.25900f + 0.35f) - NMath.Floor(beer.Width * 0.22821f - 0.45f) - 0.8f, NMath.Floor(beer.Height * 0.44839f + 0.2f) - NMath.Floor(beer.Height * 0.42482f + 0.4f) + 0.2f));
                fillColor9.SetFill();
                oval13Path.Fill();

                var oval14Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.43705f + 0.5f), beer.GetMinY() + NMath.Floor(beer.Height * 0.44820f - 0.45f) + 0.95f, NMath.Floor(beer.Width * 0.46784f + 0.3f) - NMath.Floor(beer.Width * 0.43705f + 0.5f) + 0.2f, NMath.Floor(beer.Height * 0.47177f + 0.35f) - NMath.Floor(beer.Height * 0.44820f - 0.45f) - 0.8f));
                fillColor9.SetFill();
                oval14Path.Fill();

                var oval15Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.15818f - 0.35f) + 0.85f, beer.GetMinY() + NMath.Floor(beer.Height * 0.50940f - 0.35f) + 0.85f, NMath.Floor(beer.Width * 0.18897f + 0.45f) - NMath.Floor(beer.Width * 0.15818f - 0.35f) - 0.8f, NMath.Floor(beer.Height * 0.53297f + 0.45f) - NMath.Floor(beer.Height * 0.50940f - 0.35f) - 0.8f));
                fillColor9.SetFill();
                oval15Path.Fill();

                var oval16Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.52794f + 0.2f) + 0.3f, beer.GetMinY() + NMath.Floor(beer.Height * 0.52803f - 0.45f) + 0.95f, NMath.Floor(beer.Width * 0.55873f) - NMath.Floor(beer.Width * 0.52794f + 0.2f) + 0.2f, NMath.Floor(beer.Height * 0.55160f + 0.35f) - NMath.Floor(beer.Height * 0.52803f - 0.45f) - 0.8f));
                fillColor9.SetFill();
                oval16Path.Fill();

                var oval17Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.25875f + 0.4f) + 0.1f, beer.GetMinY() + NMath.Floor(beer.Height * 0.69207f - 0.3f) + 0.8f, NMath.Floor(beer.Width * 0.28955f + 0.2f) - NMath.Floor(beer.Width * 0.25875f + 0.4f) + 0.2f, NMath.Floor(beer.Height * 0.71564f + 0.5f) - NMath.Floor(beer.Height * 0.69207f - 0.3f) - 0.8f));
                fillColor9.SetFill();
                oval17Path.Fill();

                var oval18Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.50013f - 0.2f) + 0.7f, beer.GetMinY() + NMath.Floor(beer.Height * 0.81638f - 0.1f) + 0.6f, NMath.Floor(beer.Width * 0.54333f + 0.1f) - NMath.Floor(beer.Width * 0.50013f - 0.2f) - 0.3f, NMath.Floor(beer.Height * 0.84945f + 0.2f) - NMath.Floor(beer.Height * 0.81638f - 0.1f) - 0.3f));
                fillColor9.SetFill();
                oval18Path.Fill();

                var oval19Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.20512f + 0.2f) + 0.3f, beer.GetMinY() + NMath.Floor(beer.Height * 0.55863f - 0.0f) + 0.5f, NMath.Floor(beer.Width * 0.25776f - 0.4f) - NMath.Floor(beer.Width * 0.20512f + 0.2f) + 0.6f, NMath.Floor(beer.Height * 0.59893f + 0.4f) - NMath.Floor(beer.Height * 0.55863f - 0.0f) - 0.4f));
                fillColor9.SetFill();
                oval19Path.Fill();

                var oval20Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.55004f - 0.25f) + 0.75f, beer.GetMinY() + NMath.Floor(beer.Height * 0.07318f + 0.2f) + 0.3f, NMath.Floor(beer.Width * 0.73628f + 0.25f) - NMath.Floor(beer.Width * 0.55004f - 0.25f) - 0.5f, NMath.Floor(beer.Height * 0.21954f - 0.3f) - NMath.Floor(beer.Height * 0.07318f + 0.2f) + 0.5f));
                OffWhite.SetFill();
                oval20Path.Fill();

                var oval21Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.52148f + 0.5f), beer.GetMinY() + NMath.Floor(beer.Height * 0.11272f - 0.4f) + 0.9f, NMath.Floor(beer.Width * 0.70772f) - NMath.Floor(beer.Width * 0.52148f + 0.5f) + 0.5f, NMath.Floor(beer.Height * 0.25907f + 0.1f) - NMath.Floor(beer.Height * 0.11272f - 0.4f) - 0.5f));
                OffWhite.SetFill();
                oval21Path.Fill();

                var oval22Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.45568f - 0.25f) + 0.75f, beer.GetMinY() + NMath.Floor(beer.Height * 0.01673f + 0.35f) + 0.15f, NMath.Floor(beer.Width * 0.64192f + 0.25f) - NMath.Floor(beer.Width * 0.45568f - 0.25f) - 0.5f, NMath.Floor(beer.Height * 0.16309f - 0.15f) - NMath.Floor(beer.Height * 0.01673f + 0.35f) + 0.5f));
                OffWhite.SetFill();
                oval22Path.Fill();

                var oval23Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.30097f - 0.1f) + 0.6f, beer.GetMinY() + NMath.Floor(beer.Height * 0.00000f - 0.05f) + 0.55f, NMath.Floor(beer.Width * 0.48721f + 0.4f) - NMath.Floor(beer.Width * 0.30097f - 0.1f) - 0.5f, NMath.Floor(beer.Height * 0.14636f + 0.45f) - NMath.Floor(beer.Height * 0.00000f - 0.05f) - 0.5f));
                OffWhite.SetFill();
                oval23Path.Fill();

                var oval24Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.15843f - 0.4f) + 0.9f, beer.GetMinY() + NMath.Floor(beer.Height * 0.01178f + 0.05f) + 0.45f, NMath.Floor(beer.Width * 0.34467f + 0.1f) - NMath.Floor(beer.Width * 0.15843f - 0.4f) - 0.5f, NMath.Floor(beer.Height * 0.15814f - 0.45f) - NMath.Floor(beer.Height * 0.01178f + 0.05f) + 0.5f));
                OffWhite.SetFill();
                oval24Path.Fill();

                var oval25Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.23169f - 0.15f) + 0.65f, beer.GetMinY() + NMath.Floor(beer.Height * 0.14199f + 0.3f) + 0.2f, NMath.Floor(beer.Width * 0.41793f + 0.35f) - NMath.Floor(beer.Width * 0.23169f - 0.15f) - 0.5f, NMath.Floor(beer.Height * 0.28835f - 0.2f) - NMath.Floor(beer.Height * 0.14199f + 0.3f) + 0.5f));
                OffWhite.SetFill();
                oval25Path.Fill();

                var oval26Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.25329f + 0.5f), beer.GetMinY() + NMath.Floor(beer.Height * 0.09504f - 0.05f) + 0.55f, NMath.Floor(beer.Width * 0.43953f) - NMath.Floor(beer.Width * 0.25329f + 0.5f) + 0.5f, NMath.Floor(beer.Height * 0.24140f + 0.45f) - NMath.Floor(beer.Height * 0.09504f - 0.05f) - 0.5f));
                OffWhite.SetFill();
                oval26Path.Fill();

                var oval27Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.12218f - 0.1f) + 0.6f, beer.GetMinY() + NMath.Floor(beer.Height * 0.09504f - 0.05f) + 0.55f, NMath.Floor(beer.Width * 0.30842f + 0.4f) - NMath.Floor(beer.Width * 0.12218f - 0.1f) - 0.5f, NMath.Floor(beer.Height * 0.24140f + 0.45f) - NMath.Floor(beer.Height * 0.09504f - 0.05f) - 0.5f));
                OffWhite.SetFill();
                oval27Path.Fill();

                var oval28Path = UIBezierPath.FromOval(new CGRect(beer.GetMinX() + NMath.Floor(beer.Width * 0.36702f - 0.4f) + 0.9f, beer.GetMinY() + NMath.Floor(beer.Height * 0.10910f - 0.35f) + 0.85f, NMath.Floor(beer.Width * 0.55327f + 0.1f) - NMath.Floor(beer.Width * 0.36702f - 0.4f) - 0.5f, NMath.Floor(beer.Height * 0.25546f + 0.15f) - NMath.Floor(beer.Height * 0.10910f - 0.35f) - 0.5f));
                OffWhite.SetFill();
                oval28Path.Fill();
            }
        }

    }
}

