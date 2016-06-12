using System;

using UIKit;
using CoreGraphics;

using MikeCodesDotNET.iOS;

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
    }
}

