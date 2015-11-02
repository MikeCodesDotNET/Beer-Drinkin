using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using BeerDrinkin.iOS.Helpers;
using Xamarin;
using System.Collections.Generic;

namespace BeerDrinkin.iOS
{
	partial class SearchBar : UISearchBar
	{
		public SearchBar (IntPtr handle) : base (handle)
		{
		}

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            var cameraFound = false;

            if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
            {
                cameraFound = true;

                var button = new UIButton(UIButtonType.Custom);
                button.Frame = new CoreGraphics.CGRect(Frame.Width - 44, 9, 28, 21);
                button.SetBackgroundImage(UIImage.FromFile("Barcode.png"), UIControlState.Normal);
                button.TouchUpInside += (sender, e) =>
                {
                    button.PulseToSize(0.7f, 0.3, false);
                    Clicked();
                };
                Subviews[0].AddSubview(button);
            }                      

            foreach(var view in Subviews[0].Subviews)
            {
                if (cameraFound && view.GetType() == typeof(UITextField))
                    view.Frame = new CoreGraphics.CGRect(6, 5, view.Frame.Width - 44, 30);

                var textfield = Subviews[0].Subviews[1] as UITextField;
                if (textfield != null)
                    textfield.Font = UIFont.FromName("Avenir-Book", 14);
            };

        }

        public delegate void ClickedHandler();
        public event ClickedHandler Clicked;
	}
}
