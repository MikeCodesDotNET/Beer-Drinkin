using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using BeerDrinkin.Models;

namespace BeerDrinkin.iOS
{
	partial class AddBeerTableViewController : UITableViewController
	{
        Beer beer;
        List<UITableViewCell> cells = new List<UITableViewCell>();

		public AddBeerTableViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
           // TableView.Source = new AddBeerTableViewSource(ref cells);
           // TableView.Delegate = new AddBeerDelegate(ref cells);
            //TableView.ReloadData();
            View.SetNeedsDisplay();

            NavigationItem.SetLeftBarButtonItem (new UIBarButtonItem(
                UIImage.FromFile("backArrow.png"), UIBarButtonItemStyle.Plain, (sender, args) => {
                NavigationController.PopViewController(true);
            }), true);
        }

        public void SetBeer(Beer beer)
        {
            this.beer = beer;  

            AddSourceTypeCell();
            if(UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera) == true)
            {
                AddBarcodeCell();
                AddPhotosCell();
            }
            AddRatingCell();
            AddNotesCell();
        }

        #region Adding Cells
        void AddSourceTypeCell()
        {
            var cellIdentifier = new NSString("addBeerSourceTypeCell");
            var cell = TableView.DequeueReusableCell(cellIdentifier) as AddBeerSourceTypeCell ??
                new AddBeerSourceTypeCell(cellIdentifier);
            cells.Add(cell);
        }

        void AddBarcodeCell()
        {
            var cellIdentifier = new NSString("addBeerBarcodeCell");
            var cell = TableView.DequeueReusableCell(cellIdentifier) as AddBeerBarcodeCell ??
                new AddBeerBarcodeCell(cellIdentifier);
            cells.Add(cell);
        }

        void AddPhotosCell()
        {
            var cellIdentifier = new NSString("addBeerPhotosCell");
            var cell = TableView.DequeueReusableCell(cellIdentifier) as AddBeerPhotosCell ??
                new AddBeerPhotosCell(cellIdentifier);
            cells.Add(cell);
        }
            
        void AddRatingCell()
        {
            var cellIdentifier = new NSString("addBeerRatingCell");
            var cell = TableView.DequeueReusableCell(cellIdentifier) as AddBeerRatingCell ??
                new AddBeerRatingCell(cellIdentifier);
            cells.Add(cell);
        }

        void AddNotesCell()
        {
            var cellIdentifier = new NSString("addBeerNotesCell");
            var cell = TableView.DequeueReusableCell(cellIdentifier) as AddBeerNotesCell ??
                new AddBeerNotesCell(cellIdentifier);
            cells.Add(cell);
        }

        #endregion

        #region Classses
        //TODO This is a duplicate of DecriptionTableViewSource. I should probably just reuse it
        class AddBeerTableViewSource : UITableViewSource
        {
            readonly List<UITableViewCell> cells = new List<UITableViewCell>();

            public AddBeerTableViewSource(ref List<UITableViewCell> cells)
            {
                this.cells = cells;
            }

            #region implemented abstract members of UITableViewSource

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                return cells[indexPath.Row];
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return cells.Count;
            }

            #endregion
        }

        class AddBeerDelegate : UITableViewDelegate
        {
            readonly List<UITableViewCell> cells = new List<UITableViewCell>();

            public AddBeerDelegate(ref List<UITableViewCell> cells)
            {
                this.cells = cells;
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = cells[indexPath.Row];

                if (cell.GetType() == typeof(AddBeerSourceTypeCell))
                    return 141;

                if (cell.GetType() == typeof(AddBeerBarcodeCell))
                    return 125;

                if (cell.GetType() == typeof(AddBeerPhotosCell))
                    return 119;

                if (cell.GetType() == typeof(AddBeerRatingCell))
                    return 113;

                if (cell.GetType() == typeof(AddBeerNotesCell))
                    return 224;

                return 0;
            }

            public override nfloat EstimatedHeight(UITableView tableView, NSIndexPath indexPath)
            {
                return GetHeightForRow(tableView, indexPath);
            }


        }

        #endregion
	}
}
