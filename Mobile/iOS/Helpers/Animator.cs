using System;

using UIKit;
using CoreGraphics;

using Awesomizer;

namespace BeerDrinkin.iOS.Helpers
{
    public static class Animator
    {    
        //EWWW TODO - Move this babe boy
        public static void GrowDivider(this UIView divider, UIView parent)
        {
            var orginalPosition = divider.Frame;
            var centerX = parent.Frame.GetMidX();
            divider.BackgroundColor = parent.BackgroundColor.Darken(2);
            divider.Frame = new CGRect(centerX - 30, divider.Frame.Y, 60, 1);
            divider.Alpha = 0.5f;

                UIView.Animate(0.3, 0.3, UIViewAnimationOptions.TransitionCurlUp,
                    () =>{
                    divider.Alpha = 1;
                    divider.Frame = orginalPosition ;
                    divider.SetHeight(1);
                },() =>{}); 
        }

        public static void FadeOut(this UIView view, double duration, float delay)
        {      
            UIView.AnimateNotify (duration, delay, 0, 1, 0, () => {
                view.Alpha = 0;
            }, null);  
        }

        public static void FadeIn(this UIView view, double duration, float delay)
        {
            UIView.Animate(duration, delay, UIViewAnimationOptions.CurveEaseIn,
                () =>{
                view.Alpha = 1;
            },() =>{ });
        }
    }
}

