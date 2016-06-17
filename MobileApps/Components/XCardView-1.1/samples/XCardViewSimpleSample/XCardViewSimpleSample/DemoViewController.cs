using UIKit;
using System;
using CoreGraphics;
using Softweb.Xamarin.Controls.iOS;

namespace XCardViewSimpleSample
{
	public class DemoViewController : UIViewController, ICardViewDataSource
	{
		Func<byte> r = () => (Guid.NewGuid()).ToByteArray() [random.Next(0, 15)];
		static readonly Random random = new Random ();

		public CardView DemoCardView { get; set; }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			DemoCardView = new CardView ();
			DemoCardView.DidSwipeLeft += OnSwipe;
			DemoCardView.DidSwipeRight += OnSwipe;
			DemoCardView.DidCancelSwipe += OnSwipeCancelled;
			DemoCardView.DidStartSwipingCardAtLocation += OnSwipeStarted;
			DemoCardView.SwipingCardAtLocation += OnSwiping;
			DemoCardView.DidEndSwipingCard += OnSwipeEnded;
			View.BackgroundColor = UIColor.White;
		}

		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
			DemoCardView.Center = new CGPoint (View.Center.X, View.Center.Y - 10f);
			DemoCardView.Bounds = new CGRect (0f, 0f, View.Bounds.Width - 20f, View.Bounds.Height - 100f);
			View.AddSubview(DemoCardView);
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			DemoCardView.DataSource = this;
		}

		public UIView NextCardForCardView(CardView cardView)
		{
			var view = new UIView () {
				BackgroundColor = UIColor.FromRGB(r(), r(), r()),
				Frame = DemoCardView.Bounds
			};
			view.Layer.ShouldRasterize = true;
			return view;
		}

		private void OnSwipe(object sender, SwipeEventArgs e)
		{
			Console.WriteLine("View swiped.");
		}

		private void OnSwipeCancelled(object sender, SwipeEventArgs e)
		{
			Console.WriteLine("Swipe cancelled.");
		}

		private void OnSwipeStarted(object sender, SwipingStartedEventArgs e)
		{
			Console.Write("Swiping started at location {0}\n", e.Location);
		}

		private void OnSwiping(object sender, SwipingEventArgs e)
		{
			Console.Write("Swiping at location {0}\n", e.Location);
		}

		private void OnSwipeEnded(object sender, SwipingEndedEventArgs e)
		{
			Console.Write("Swiping ended at location {0}\n", e.Location);
		}
	}
}
