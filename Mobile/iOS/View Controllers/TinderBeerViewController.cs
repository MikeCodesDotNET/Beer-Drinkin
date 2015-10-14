using System;
using Softweb.Xamarin.Controls.iOS;
using UIKit;
using CoreGraphics;
using Splat;


namespace BeerDrinkin.iOS.ViewControllers
{

    public class TinderBeerViewController : UIViewController, ICardViewDataSource
    {
        private static readonly Random random = new Random();

        //Returns a random byte
        private Func<byte> r = () => (Guid.NewGuid()).ToByteArray() [random.Next(0, 15)];

        public CardView DemoCardView { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            DemoCardView = new CardView();

            //Wire up events
            DemoCardView.DidSwipeLeft += OnSwipe;
            DemoCardView.DidSwipeRight += OnSwipe;
            DemoCardView.DidCancelSwipe += OnSwipeCancelled;
            DemoCardView.DidStartSwipingCardAtLocation += OnSwipeStarted;
            DemoCardView.SwipingCardAtLocation += OnSwiping;
            DemoCardView.DidEndSwipingCard += OnSwipeEnded;
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

            View.BackgroundColor = BeerDrinkin.Helpers.Colours.Blue.ToNative();

            DemoCardView.Center = new CGPoint (View.Center.X, View.Center.Y - 25f);
            DemoCardView.Bounds = new CGRect (0f, 0f, View.Bounds.Width - 50f, View.Bounds.Height - 200);
            View.AddSubview(DemoCardView);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            DemoCardView.DataSource = this;
        }

        public UIView NextCardForCardView(CardView cardView)
        {
            //Create a card with a random background color
            var card = new UIView {
                BackgroundColor = UIColor.FromRGB(r(), r(), r()),
                Frame = DemoCardView.Bounds
            };

            //Rasterize card for more efficient animation
            card.Layer.ShouldRasterize = true;

            return card;
        }   

        void OnSwipe(object sender, SwipeEventArgs e)
        {
            Console.WriteLine("View swiped.\n");
        }

        void OnSwipeCancelled(object sender, SwipeEventArgs e)
        {
            Console.WriteLine("Swipe cancelled.\n");
        }

        void OnSwipeStarted(object sender, SwipingStartedEventArgs e)
        {
            Console.Write("Started swiping at location {0}\n", e.Location);
        }

        void OnSwiping(object sender, SwipingEventArgs e)
        {
            Console.Write("Swiping at location {0}\n", e.Location);
        }

        void OnSwipeEnded(object sender, SwipingEndedEventArgs e)
        {
            Console.Write("Ended swiping at location {0}\n", e.Location);
        }
    }
}

