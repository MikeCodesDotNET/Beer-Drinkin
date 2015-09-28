using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.CustomControls
{
    [Register("SignInBox"), DesignTimeVisible(true)]
    public class SignInBox : UIView
    {
        public SignInBox(IntPtr p)
            : base(p)
        {
            Initialize();
        }

        public SignInBox()
        {
            Initialize();
        }

        private void Initialize()
        {
        }

        public override void Draw(CGRect frame)
        {
            // General Declarations
            var context = UIGraphics.GetCurrentContext();

            // Color Declarations
            var color4 = UIColor.FromRGBA(1.000f, 1.000f, 1.000f, 1.000f);
            var color5 = UIColor.FromRGBA(0.793f, 0.793f, 0.793f, 1.000f);

            // Shadow Declarations
            var shadow = new NSShadow();
            shadow.ShadowColor = UIColor.Black.ColorWithAlpha(0.28f);
            shadow.ShadowOffset = new CGSize(3.1f, 3.1f);
            shadow.ShadowBlurRadius = 5.0f;

            // Rectangle Drawing
            var rectanglePath =
                UIBezierPath.FromRoundedRect(
                    new CGRect(frame.GetMinX() + 10.5f, frame.GetMinY() + 7.5f, frame.Width - 20.0f, 76.0f), 4.0f);
            context.SaveState();
            context.SetShadow(shadow.ShadowOffset, shadow.ShadowBlurRadius, shadow.ShadowColor.CGColor);
            color4.SetFill();
            rectanglePath.Fill();
            context.RestoreState();

            color5.SetStroke();
            rectanglePath.LineWidth = 1.0f;
            rectanglePath.Stroke();


            // Bezier 2 Drawing
            var bezier2Path = new UIBezierPath();
            bezier2Path.MoveTo(new CGPoint(frame.GetMinX() + 0.02386f*frame.Width,
                frame.GetMinY() + 0.50543f*frame.Height));
            bezier2Path.AddLineTo(new CGPoint(frame.GetMinX() + 0.97841f*frame.Width,
                frame.GetMinY() + 0.50543f*frame.Height));
            context.SaveState();
            context.SetShadow(shadow.ShadowOffset, shadow.ShadowBlurRadius, shadow.ShadowColor.CGColor);
            color4.SetFill();
            bezier2Path.Fill();
            context.RestoreState();

            color5.SetStroke();
            bezier2Path.LineWidth = 1.0f;
            bezier2Path.Stroke();
        }
    }
}