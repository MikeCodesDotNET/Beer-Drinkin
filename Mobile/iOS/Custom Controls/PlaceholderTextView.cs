using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS.CustomControls
{
	[Register("PlaceholderTextView")]
	public class PlaceholderTextView : UITextView
	{
		/// <summary>
		/// Gets or sets the placeholder to show prior to editing - doesn't exist on UITextView by default
		/// </summary>
		public string Placeholder { get; set; }

		public PlaceholderTextView ()
		{
			Initialize ();
		}

		public PlaceholderTextView (CGRect frame)
			: base(frame)
		{
			Initialize ();
		}

		public PlaceholderTextView (IntPtr handle)
			: base(handle)
		{
			Initialize ();
		}

		void Initialize ()
		{
			Placeholder = "Write a comment";

			ShouldBeginEditing = t => {
				if (Text == Placeholder)
					Text = string.Empty;

				return true;
			};
			ShouldEndEditing = t => {
				if (string.IsNullOrEmpty (Text))
					Text = Placeholder;

				return true;
			};
		}
	}
}

