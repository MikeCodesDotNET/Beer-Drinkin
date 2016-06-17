
You can add an `XCardView` as shown in the following example.

#Example
Your `XCardView` must have an object that implements the `ICardViewDataSource` to act as a data source for cards.

You must assign set the `DataSource` property of your `XCardView` in your view controller's `ViewDidLayoutSubviews` method.

###View Controller
```
using Softweb.Xamarin.Controls.iOS;

public class DemoViewController : UIViewController, ICardViewDataSource
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
		//Create a card with a random background color
		var card = new UIView {
			BackgroundColor = UIColor.FromRGBA(r(), r(), r()),
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
```