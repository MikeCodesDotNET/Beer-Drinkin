using System;
using UIKit;
using Foundation;
using BeerDrinkin.iOS.CustomControls;
using System.Collections.Generic;
using MikeCodesDotNET.iOS;
using System.Text.RegularExpressions;

namespace BeerDrinkin.iOS.DataSources
{
    public class SearchSuggestionDataSource : UITableViewSource
    {       
        List<string> results;
        public SearchSuggestionDataSource(List<string> results)
        {
            this.results = results;
        }

        #region implemented abstract members of UITableViewSource

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return results.Count;
        }
        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            try
            {
                var cellIdentifier = new NSString("suggestion");
                var cell = tableView.DequeueReusableCell(cellIdentifier) as NoRecentSearchesViewCell ?? new NoRecentSearchesViewCell(cellIdentifier);

                var text = results[indexPath.Row];
                var hitStart = text.IndexOf("[");
                var hitEnd = text.LastIndexOf("]");

                var hitColor = "646265".ToUIColor();
                var textColor = "989898".ToUIColor();

                var defaultAttributes = new UIStringAttributes {
                    ForegroundColor = textColor,
                    Font = UIFont.FromName("Avenir", 18)
                };

                var hitAttributes = new UIStringAttributes {
                    ForegroundColor = hitColor,
                    Font = UIFont.FromName("Avenir-Medium", 18)
                };

                text = text.Remove(hitEnd, 1);
                text = text.Remove(hitStart, 1);

                var attributedString = new NSMutableAttributedString (text);
                attributedString.SetAttributes(defaultAttributes.Dictionary, new NSRange(0, text.Length));
                attributedString.SetAttributes(hitAttributes.Dictionary, new NSRange(0, hitEnd -1));

                cell.TextLabel.AttributedText = attributedString;
  
                //cell.TextLabel.Text = text;
                //cell.TextLabel.Font = UIFont.FromName("Avenir-Book", 14);
                return cell;
            }
            catch(Exception ex)
            {
                Xamarin.Insights.Report(ex);
                var cell = new UITableViewCell();
                cell.TextLabel.Text = results[indexPath.Row];
                cell.TextLabel.Font = UIFont.FromName("Avenir-Book", 14);
                return cell;
            }
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            SelectedRow(indexPath.Row);   
        }

        public delegate void RowSelectedHandler(int index);
        public event RowSelectedHandler SelectedRow;

        #endregion
    }
}

