using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Awesomizer;

namespace BeerDrinkin.iOS
{
	partial class SearchSuggestionsViewController : UIViewController
	{
		public SearchSuggestionsViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var dataSource = new DataSources.SearchPlaceholderDataSource();
            tableView.Source = dataSource;
            tableView.ReloadData();

            var textfield = searchBar.Subviews[0].Subviews[1] as UITextField;
            if (textfield != null)
            {
                textfield.Font = UIFont.FromName("Avenir-Book", 14);
                textfield.BackgroundColor = "009CFB".ToUIColor();
                textfield.TextColor = UIColor.White;
            }            
        }

        partial void BtnCancel_TouchUpInside(UIButton sender)
        {
           DismissViewControllerAsync(true);
        }
	}
}
