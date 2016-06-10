using System;
using MikeCodesDotNET.iOS;
using UIKit;

namespace BeerDrinkin.iOS.Helpers
{
    public class Style
    {
        public static class Fonts
        {
            public static UIFont Heading = UIFont.FromName("Avenir-Medium", 20f);
            public static UIFont Subtitle = UIFont.FromName("Avenir-Medium", 17f);
            public static UIFont Button = UIFont.FromName("Avenir-Medium", 17f);
            public static UIFont Paragraph = UIFont.FromName("Avenir-Book", 15f);
            public static UIFont NavigationButton = UIFont.FromName("Avenir-Medium", 14f);
            public static UIFont TabBar = UIFont.FromName("Avenir-Book", 10f);
        }

        public static class Colors
        {
            public static UIColor Blue = "0D93FF".ToUIColor();
            public static UIColor NavigationBar = "0D93FF".ToUIColor();
            public static UIColor NavigationTint = UIColor.White;

        }

    }

}

