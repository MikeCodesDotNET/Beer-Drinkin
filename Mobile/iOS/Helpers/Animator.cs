using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;
using Foundation;
using System.Collections.Generic;
using System.Linq;


namespace BeerDrinkin.iOS.Helpers
{
    public static class Animator
    {        

        public static bool AutoHide;
        static float springDampingRatio = 0.25f;
        static float initialSpringVelocity = 1.0f;     


        static void Init(UIView view)
        {           
        }

        public static void Pop(this UIView view, double duration, float delay, float force)
        {
            Init(view);
                       
        }

        public static void Grow(this UIView view, float scale, double duration, float delay)
        {

            Init(view);

            var transform = CGAffineTransform.MakeIdentity();
            transform.Scale(scale, scale); 

            UIView.Animate(duration, delay, UIViewAnimationOptions.TransitionCurlUp,
                () =>{
                view.Transform = transform;
            },() =>{});

            if (AutoHide)
                FadeOut(view, duration, delay);
        }

        public static void Shrink(this UIView view, double duration, float delay)
        {

            Init(view);

            var transform = CGAffineTransform.MakeIdentity();
            transform.Scale(0.5f, 0.5f); 

            UIView.Animate(duration, delay, UIViewAnimationOptions.TransitionCurlUp,
                () =>{
                view.Transform = transform;
            },() =>{});

            if (AutoHide)
                FadeOut(view, duration, delay);
        }

        public static void HideAllSubViews(this UIView view)
        {
            Init(view);

            foreach(var subView in view.Subviews)
            {
                subView.Alpha = 0;
            }
        }

        public static void FadeSubviewsIn(this UIView view, double duration, float delay)
        {
            Init(view);

            foreach (var subView in view.Subviews)
            {
                UIView.Animate(duration, delay, UIViewAnimationOptions.CurveEaseIn,
                    () =>
                    {
                        subView.Alpha = 1;
                    }, () =>
                    {
                    });
            }
        }

        public static void FadeSubviewsOut(this UIView view, double duration, float delay)
        {
            Init(view);

            foreach (var subView in view.Subviews)
            {
                UIView.Animate(duration, delay, UIViewAnimationOptions.CurveEaseIn,
                    () =>
                    {
                        subView.Alpha = 0;
                    }, () =>
                    {
                    });
            }
        }

        public static void FadeOut(this UIView view, double duration, float delay)
        {        
            Init(view);


            UIView.AnimateNotify (duration, delay, springDampingRatio, initialSpringVelocity, 0, () => {
                view.Alpha = 0;
            }, null);  
        }

        public static void FadeIn(this UIView view, double duration, float delay)
        {
            Init(view);

            UIView.Animate(duration, delay, UIViewAnimationOptions.CurveEaseIn,
                () =>{
                view.Alpha = 1;
            },() =>{ });
        }


        public static void SlideRight(this UIView view, double duration, float delay)
        {
            Init(view);

            var bounds = UIScreen.MainScreen.Bounds;

            UIView.AnimateNotify (duration, delay, springDampingRatio, initialSpringVelocity, 0, () => {

                view.Frame = new CGRect(bounds.X + view.Frame.Width, view.Frame.Y, view.Frame.Width, view.Frame.Height);

            }, null);        
        }

        public static void FallDown(this UIView view)
        {
            Init(view);

            var animator = new UIDynamicAnimator(view);
            UIGravityBehavior gravityBehavior = new UIGravityBehavior(view);
            animator.AddBehavior(gravityBehavior);

            UICollisionBehavior collisionBehavior = new UICollisionBehavior(view) { TranslatesReferenceBoundsIntoBoundary = true };
            animator.AddBehavior(collisionBehavior);

            UIDynamicItemBehavior elasticityBehavior = new UIDynamicItemBehavior(view) { Elasticity = 0.7f };
            animator.AddBehavior(elasticityBehavior);
        }

        public static void Shake(this UIView view, double duration, float repeatCount)
        {
            Init(view);

            var animation = new CABasicAnimation();
            animation.KeyPath = "position";
            animation.Duration = duration;
            animation.RepeatCount = repeatCount;
            animation.AutoReverses = true;
            animation.From = NSValue.FromPointF(new System.Drawing.PointF((float)view.Center.X - 10, (float)view.Center.Y));
            animation.To = NSValue.FromPointF(new System.Drawing.PointF((float)view.Center.X + 10, (float)view.Center.Y));
            view.Layer.AddAnimation(animation, "position");
        }

        public static void SlideLeft(this UIView view, double duration, float delay)
        { 
            Init(view);

            var bounds = UIScreen.MainScreen.Bounds;
            UIView.AnimateNotify (duration, delay, springDampingRatio, initialSpringVelocity, 0, () => {

                view.Frame = new CGRect(bounds.X - view.Frame.Width, view.Frame.Y, view.Frame.Width, view.Frame.Height);

            }, null);  
        }

        public static void Restore(this UIView view, UIView orginalView, double duration, float delay)
        {                    
            for (int i = 0; i <= orginalView.Subviews.Length -1; i++)
            {                
                var bounds = UIScreen.MainScreen.Bounds;
                float springDampingRatio = 0.25f;
                float initialSpringVelocity = 1.0f;

                UIView sv = orginalView.Subviews[i];

                UIView.AnimateNotify (duration, delay, springDampingRatio, initialSpringVelocity, 0, () => {

                    view.Hidden = sv.Hidden;
                    view.Alpha = sv.Alpha;
                    view.Frame = sv.Frame;
                    //view.Transform = sv.Transform;

                    Console.WriteLine(string.Format("{0} - X:{1} Y:{2}", view.GetType().ToString(), view.Frame.X, view.Frame.Y));

                }, null);  
            }
        }

       

    }
}

