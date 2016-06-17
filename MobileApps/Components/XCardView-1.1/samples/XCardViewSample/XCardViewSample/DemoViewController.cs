using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using CoreAnimation;
using CoreGraphics;
using Softweb.Xamarin.Controls.iOS;
using UIKit;

namespace XCardViewSample
{
	partial class DemoViewController : UIViewController, ICardViewDataSource
	{
		private readonly Func<byte> r = () => (Guid.NewGuid()).ToByteArray() [random.Next(0, 15)];
		private static readonly Random random = new Random();
		private readonly HttpClient httpClient = new HttpClient();
		private readonly Queue<string> quotes = new Queue<string>(new[] {
			"Be happy.",
			"Be grateful for the good things you have in your life.",
			"The internet could be a very positive step towards education, organisation and participation in a meaningful society.  -Noam Chomsky",
			"Computer science is no more about computers than astronomy is about telescopes. -Edsger Dijkstra",
			"Treat your password like your toothbrush. Don't let anybody else use it, and get a new one every six months. -Clifford Stoll",
			"Man is still the most extraordinary computer of all. -John F. Kennedy",
			"To err is human - and to blame it on a computer is even more so. -Robert Orben",
			"In short, software is eating the world. -Mark Andreessen",
			"The future lies in designing and selling computers that people don't realize are computers at all. -Adam Osborne",
			"The good news about computers is that they do what you tell them to do. The bad news is that they do what you tell them to do. -Ted Nelson",
			"As a rule, software systems do not work well until they have been used, and have failed repeatedly, in real applications. -Dave Parnas"
		});

		public DemoViewController(IntPtr handle) : base(handle)
		{
			httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Initiate fetching quotes in the background
			GetQuotes();

			//Reload button event handler
			btnReload.TouchUpInside += (sender, e) => {
				DemoCardView.DiscardAllCards();
				DemoCardView.LoadNextCardsIfNeeded();
			};

			//Swipe buttons event handlers
			btnSwipeLeft.TouchUpInside += (sender, e) => DemoCardView.SwipeTopCardToLeft();
			btnSwipeRight.TouchUpInside += (sender, e) => DemoCardView.SwipeTopCardToRight();

			//XCardView event handlers
			DemoCardView.DidSwipeLeft += (sender, e) =>
				Console.WriteLine(((UILabel) e.View.Subviews.FirstOrDefault(v => v is UILabel)).Text);
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			DemoCardView.DataSource = this;
		}

		private async Task GetQuotes()
		{
			while (true)
			{
				if (quotes.Count > 20)
					return;
				var response = await httpClient.GetAsync("http://www.iheartquotes.com/fortune/show/" + random.Next(200, 20000));
				if (!response.IsSuccessStatusCode)
					continue;
				string quote = String.Empty;
				try
				{
					var content = await response.Content.ReadAsStringAsync();
					var pos = content.IndexOf("<div id=\"quote\"", StringComparison.OrdinalIgnoreCase);
					var endPos = content.IndexOf("</div>", pos, StringComparison.OrdinalIgnoreCase);
					var quoteTag = content.Substring(pos, endPos - pos + 6);
					var decoded = WebUtility.HtmlDecode(quoteTag);
					var xdoc = XDocument.Parse(decoded);
					quote = xdoc.Descendants(XName.Get("p")).FirstOrDefault().Value.Trim();
				} catch
				{
				}
				if (!String.IsNullOrEmpty(quote)
				    && !((UIDevice.CurrentDevice.UserInterfaceIdiom != UIUserInterfaceIdiom.Pad)
				    && (quote.Length > 200)))
					quotes.Enqueue(quote);
			}
		}

		#region ICardViewDataSource Implementation

		public UIView NextCardForCardView(CardView cardView)
		{
			var view = new UIView {
				BackgroundColor = UIColor.FromRGBA(r(), r(), r(), (byte) 255),
				Frame = DemoCardView.Bounds
			};
			view.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.All;
			view.Layer.ShadowColor = UIColor.Black.CGColor;
			view.Layer.ShadowOffset = new CGSize (0f, 1.5f);
			view.Layer.ShouldRasterize = true;
			view.Layer.ShadowOpacity = 0.33f;
			view.Layer.ShadowRadius = 4.0f;
			view.Layer.CornerRadius = 6.0f;

			var label = new UILabel {
				Font = UIFont.FromName(UIFont.FontNamesForFamilyName("Marion") [0], 22f),
				Bounds = new CGRect (0f, 0f, view.Frame.Width - 50f, view.Frame.Height - 100f),
				Text = quotes.Count > 0 ? quotes.ElementAt(random.Next(0, quotes.Count - 1)) : "Be Happy :)",
				LineBreakMode = UILineBreakMode.WordWrap,
				BackgroundColor = UIColor.Clear,
				TextColor = UIColor.White,
				Center = view.Center,
				Lines = 0
			};
			view.AddSubview(label);
			label.SizeToFit();
			label.Center = view.Center;
			return view;
		}

		#endregion
	}
}
