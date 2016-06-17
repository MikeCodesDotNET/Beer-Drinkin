using System;
using System.Collections.Generic;
using UIKit;
using Foundation;
using System.Linq;

namespace JudoPayiOSXamarinSampleApp
{
	public class MainMenuSource: UITableViewSource
	{

		Dictionary<string,Action> ButtonDictionary;
		KeyValuePair<string,Action>[] ButtonArray;
		string CellIdentifier = "genericCell";
		List<UITableViewCell> TableCells;

		public MainMenuSource (Dictionary<string,Action> buttonDictionary)
		{
			TableCells = new List<UITableViewCell> ();
			ButtonArray = buttonDictionary.ToArray ();
			foreach (var buttonProperty in ButtonArray) {
				var cell = new UITableViewCell ();
				cell.TextLabel.Text = buttonProperty.Key;
				TableCells.Add (cell);
			}
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return ButtonArray.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{

			UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);
			cell = TableCells [indexPath.Row];
			cell.IndentationLevel = 0;

			if (cell != null) {
				return cell;
			} else {
				cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier);
				cell.TextLabel.Text = ButtonArray [indexPath.Row].Key;
				return cell;
			}
		}

		public float GetTableHeight ()
		{
			float height = 0f;
			foreach (UITableViewCell cell in TableCells) {
				height += (float)cell.Frame.Height;
			}
			return height;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			ButtonArray [indexPath.Row].Value.Invoke ();
			var cell = TableCells [indexPath.Row];
			cell.SetSelected (false, false);
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{

			UITableViewCell cell = TableCells [indexPath.Row];
			return cell.Bounds.Height;
		}
	}
}

