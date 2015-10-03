using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Softweb.Xamarin.Controls.iOS;
using CoreGraphics;
using System.Collections.Generic;
using Color = BeerDrinkin.Helpers.Colours;
using Splat;


namespace BeerDrinkin.iOS
{
    partial class CardSwipeViewController : UIViewController
    {
        CardView cardView;
        List<UIColor> colors = new List<UIColor>();

        public CardSwipeViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            colors.Add(Color.Green.ToNative());
            colors.Add(Color.Red.ToNative());
            colors.Add(Color.Purple.ToNative());
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
        }

        int cardsShown = 0;

        public UIView NextCardForCardView(CardView cardView)
        {
            //Create a card with a random background color
            var card = new UIView
            {
                BackgroundColor = colors[cardsShown],
                Frame = cardView.Bounds
            };

            if (cardsShown == 3)
                cardsShown = 0;

            cardsShown++;

            //Rasterize card for more efficient animation
            card.Layer.ShouldRasterize = true;

            return card;
        }

        void OnSwipe(object sender, SwipeEventArgs e)
        {
            Console.WriteLine("View swiped.\n");
        }

    }
}
