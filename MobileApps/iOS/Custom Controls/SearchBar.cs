using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using BeerDrinkin.iOS.Helpers;
using Xamarin;
using System.Collections.Generic;
using MikeCodesDotNET.iOS;

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

            foreach(var view in Subviews[0].Subviews)
            {
                var textfield = Subviews[0].Subviews[1] as UITextField;
                if (textfield != null)
                {
                    textfield.Font = UIFont.FromName("Avenir-Book", 14);
                    textfield.BorderStyle = UITextBorderStyle.RoundedRect;
                    textfield.Layer.CornerRadius = 0;
                    textfield.Layer.MasksToBounds = true;
                }
            };

        }

        public delegate void ClickedHandler();
        public event ClickedHandler BarcodeButtonClicked;
	}
}
