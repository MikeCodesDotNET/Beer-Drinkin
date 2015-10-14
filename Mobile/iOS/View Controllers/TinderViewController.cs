using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Softweb.Xamarin.Controls.iOS;
using CoreGraphics;
using BeerDrinkin.Service.DataObjects;
using System.Collections.Generic;

namespace BeerDrinkin.iOS
{
    partial class TinderViewController : UIViewController, ICardViewDataSource
	{
		public TinderViewController (IntPtr handle) : base (handle)
		{
		}

        public List<BeerItem> Beers = new List<BeerItem>();

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            tinderView.BackgroundColor = UIColor.Clear;

            DemoCardView = new CardView();

            //Wire up events
            DemoCardView.DidSwipeLeft += OnSwipe;
            DemoCardView.DidSwipeRight += OnSwipe;
            DemoCardView.DidCancelSwipe += OnSwipeCancelled;
            DemoCardView.DidStartSwipingCardAtLocation += OnSwipeStarted;
            DemoCardView.SwipingCardAtLocation += OnSwiping;
            DemoCardView.DidEndSwipingCard += OnSwipeEnded;

            ZeroControlsAlpha();
            btnFinished.Frame = new CGRect(btnFinished.Frame.X, btnFinished.Frame.Y + btnFinished.Frame.Height, btnFinished.Frame.Width, btnFinished.Frame.Height);
        }
       
        void ZeroControlsAlpha()
        {
            DemoCardView.Alpha = 0;
            lblBeersCount.Alpha = 0;
            imgBeer1.Alpha = 0f;
            imgBeer2.Alpha = 0f;
            imgBeer3.Alpha = 0f;
            imgBeer4.Alpha = 0f;
        }

        public async override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);   


            DemoCardView.Center = new CGPoint (View.Center.X, View.Center.Y);
            DemoCardView.Frame = new CGRect (15f, 13f, View.Bounds.Width - 60f, View.Bounds.Height - 300f);
            tinderView.AddSubview(DemoCardView);
            tinderView.BackgroundColor = UIColor.Clear;
            DemoCardView.DataSource = this;
           

            UIView.Animate(1, 0, UIViewAnimationOptions.TransitionCurlUp,
                () =>
                {
                    imgBeer1.Alpha = 0.2f;
                    imgBeer2.Alpha = 0.2f;
                    imgBeer3.Alpha = 0.2f;
                    imgBeer4.Alpha = 0.2f;
                    DemoCardView.Alpha = 1f;
                    lblBeersCount.Alpha = 0.5f;
                    btnFinished.Frame = new CGRect(btnFinished.Frame.X, btnFinished.Frame.Y - btnFinished.Frame.Height, btnFinished.Frame.Width, btnFinished.Frame.Height);

                }, () =>
                {                    
                });            
            lblBeersCount.Text = "0 Beers";
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
        }

        private int progressCount = 0;

        public UIView NextCardForCardView(CardView cardView)
        {

            if (progressCount > Beers.Count || progressCount == Beers.Count)
            {
                var errorView = new UIView {
                    BackgroundColor = UIColor.Clear,
                    Frame = DemoCardView.Bounds
                };

                var bgd = new UIView {
                    BackgroundColor = UIColor.FromRGB(255,125,141),
                    Frame = DemoCardView.Bounds
                };
                bgd.Layer.CornerRadius = 4;
                bgd.Layer.ShadowColor = UIColor.Black.CGColor;
                bgd.Layer.ShadowOpacity = 0.2f;
                bgd.Layer.ShadowOffset = new CGSize(0, 0);
                bgd.Layer.ShouldRasterize = true;
                errorView.AddSubview(bgd);

                var errorLabel = new UILabel(new CGRect(20, 10, DemoCardView.Bounds.Width - 40, DemoCardView.Bounds.Height));
                errorLabel.Text = "Thats all 100 popular beers \nfor your current location!";
                errorLabel.Lines = 2;
                errorLabel.TextColor = UIColor.White;
                errorLabel.Font = UIFont.FromName("Avenir-Medium", 20.0f);
                errorLabel.TextAlignment = UITextAlignment.Center;
                errorLabel.TextAlignment = UITextAlignment.Center;
                errorView.AddSubview(errorLabel);
                return errorView;
            }




            var beerView = new UIView {
                BackgroundColor = UIColor.Clear,
                Frame = DemoCardView.Bounds
            };


            //Create a card with a random background color
            var card = new UIView {
                BackgroundColor = UIColor.White,
                Frame = DemoCardView.Bounds
            };

            //var cv = new CustomControls.TinderBox(new IntPtr(), "beername");          
            //cv.Frame = card.Bounds;
            //card.AddSubview(cv);
            //Rasterize card for more efficient animation

            card.Layer.CornerRadius = 4;
            card.Layer.ShadowColor = UIColor.Black.CGColor;
            card.Layer.ShadowOpacity = 0.5f;
            card.Layer.ShadowOffset = new CGSize(0, 0);
            card.Layer.ShouldRasterize = true;
            beerView.AddSubview(card);           

            var label = new UILabel(new CGRect(20, 10, card.Frame.Width - 40, 30));
            label.Text = "Duvel";
            label.TextColor = UIColor.FromRGB(104, 104, 104);
            label.Font = UIFont.FromName("Avenir-Medium", 24.0f);
            label.TextAlignment = UITextAlignment.Center;
            beerView.AddSubview(label);

            var btnNope = new UIButton(UIButtonType.RoundedRect);
            btnNope.SetTitle("Nope", UIControlState.Normal);
            btnNope.Font = UIFont.FromName("Avenir-Medium", 30.0f);
            btnNope.SetTitleColor(UIColor.FromRGB(255,125,141), UIControlState.Normal);
            btnNope.Frame = new CGRect(20, card.Frame.Height - 45, card.Frame.Width /2 -10, 30);
            btnNope.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            btnNope.TouchUpInside += delegate
            {
                  DemoCardView.SwipeTopCardToLeft();
            };

            beerView.Add(btnNope);

            var btnYes = new UIButton(UIButtonType.RoundedRect);
            btnYes.SetTitle("Yep", UIControlState.Normal);
            btnYes.Font = UIFont.FromName("Avenir-Medium", 30.0f);
            btnYes.SetTitleColor(UIColor.FromRGB(80,210,194), UIControlState.Normal);
            btnYes.Frame = new CGRect(10 + card.Frame.Width /2, card.Frame.Height - 45, card.Frame.Width /2 - 20, 30);
            btnYes.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            btnYes.TouchUpInside += delegate
                {
                    DemoCardView.SwipeTopCardToRight();
                };

            beerView.Add(btnYes);

            return beerView;
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

        public CardView DemoCardView { get; set; }

        async partial void BtnFinished_TouchUpInside(UIButton sender)
        {
            UIView.Animate(0.4, 0, UIViewAnimationOptions.TransitionCurlUp,
                () =>
                {
                    DemoCardView.Frame = new CGRect(DemoCardView.Frame.X, -100 - DemoCardView.Frame.Height, DemoCardView.Frame.Width, DemoCardView.Frame.Height);
                    ZeroControlsAlpha();
                }, () =>
                {        
                    DemoCardView.Alpha = 0.0f;
                    var parent = this.PresentingViewController.GetType();
                    if(parent == typeof(ShakeWelcomeViewController))
                    {
                        //URGh....horrible
                        PresentingViewController.PresentingViewController.PresentingViewController.DismissViewControllerAsync(true);
                    }
                });            
        }
	}
}
