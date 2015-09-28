using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.CustomControls
{
    [Register("SignUpBox"), DesignTimeVisible(true)]
    public class SignUpBox : UIView
    {
        public SignUpBox(IntPtr p)
            : base(p)
        {
            Initialize();
        }

        public SignUpBox()
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

            // Rectangle 4 Drawing
            var rectangle4Path =
                UIBezierPath.FromRoundedRect(
                    new CGRect(frame.GetMinX() + 10.5f, frame.GetMinY() + 7.5f, frame.Width - 20.0f,
                        frame.Height - 20.0f), 4.0f);
            context.SaveState();
            context.SetShadow(shadow.ShadowOffset, shadow.ShadowBlurRadius, shadow.ShadowColor.CGColor);
            color4.SetFill();
            rectangle4Path.Fill();
            context.RestoreState();

            color5.SetStroke();
            rectangle4Path.LineWidth = 1.0f;
            rectangle4Path.Stroke();


            // Bezier 2 Drawing
            var bezier2Path = new UIBezierPath();
            bezier2Path.MoveTo(new CGPoint(frame.GetMinX() + 0.02386f*frame.Width,
                frame.GetMinY() + 0.21831f*frame.Height));
            bezier2Path.AddLineTo(new CGPoint(frame.GetMinX() + 0.97841f*frame.Width,
                frame.GetMinY() + 0.21831f*frame.Height));
            context.SaveState();
            context.SetShadow(shadow.ShadowOffset, shadow.ShadowBlurRadius, shadow.ShadowColor.CGColor);
            color4.SetFill();
            bezier2Path.Fill();
            context.RestoreState();

            color5.SetStroke();
            bezier2Path.LineWidth = 1.0f;
            bezier2Path.Stroke();


            // Bezier Drawing
            var bezierPath = new UIBezierPath();
            bezierPath.MoveTo(new CGPoint(frame.GetMinX() + 0.02386f*frame.Width,
                frame.GetMinY() + 0.40141f*frame.Height));
            bezierPath.AddLineTo(new CGPoint(frame.GetMinX() + 0.97841f*frame.Width,
                frame.GetMinY() + 0.40141f*frame.Height));
            context.SaveState();
            context.SetShadow(shadow.ShadowOffset, shadow.ShadowBlurRadius, shadow.ShadowColor.CGColor);
            color4.SetFill();
            bezierPath.Fill();
            context.RestoreState();

            color5.SetStroke();
            bezierPath.LineWidth = 1.0f;
            bezierPath.Stroke();


            // Bezier 3 Drawing
            var bezier3Path = new UIBezierPath();
            bezier3Path.MoveTo(new CGPoint(frame.GetMinX() + 0.02386f*frame.Width,
                frame.GetMinY() + 0.58451f*frame.Height));
            bezier3Path.AddLineTo(new CGPoint(frame.GetMinX() + 0.97841f*frame.Width,
                frame.GetMinY() + 0.58451f*frame.Height));
            context.SaveState();
            context.SetShadow(shadow.ShadowOffset, shadow.ShadowBlurRadius, shadow.ShadowColor.CGColor);
            color4.SetFill();
            bezier3Path.Fill();
            context.RestoreState();

            color5.SetStroke();
            bezier3Path.LineWidth = 1.0f;
            bezier3Path.Stroke();


            // Bezier 4 Drawing
            var bezier4Path = new UIBezierPath();
            bezier4Path.MoveTo(new CGPoint(frame.GetMinX() + 0.02386f*frame.Width,
                frame.GetMinY() + 0.76761f*frame.Height));
            bezier4Path.AddLineTo(new CGPoint(frame.GetMinX() + 0.97841f*frame.Width,
                frame.GetMinY() + 0.76761f*frame.Height));
            context.SaveState();
            context.SetShadow(shadow.ShadowOffset, shadow.ShadowBlurRadius, shadow.ShadowColor.CGColor);
            color4.SetFill();
            bezier4Path.Fill();
            context.RestoreState();

            color5.SetStroke();
            bezier4Path.LineWidth = 1.0f;
            bezier4Path.Stroke();
        }
    }
}