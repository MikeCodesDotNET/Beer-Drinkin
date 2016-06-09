using System;
using System.Drawing;
using Foundation;
using UIKit;
using Xamarin.InAppPurchase;
using System.Collections.Generic;

namespace InAppPurchaseTest
{
	public class PurchaseTableSource : UITableViewSource
	{
		#region Private Variables
		private PurchaseTableViewController _controller;
		private List<InAppProduct> purchases = new List<InAppProduct> ();
		#endregion 

		#region Computed Properties
		/// <summary>
		/// Gets the puchased product count.
		/// </summary>
		/// <value>The puchased product count.</value>
		public int puchasedProductCount {
			get { return purchases.Count; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="InAppPurchaseTest.PurchaseTableSource"/> class.
		/// </summary>
		/// <param name="controller">Controller.</param>
		public PurchaseTableSource (PurchaseTableViewController controller)
		{
			// Initialize
			_controller = controller;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Scans the Purchase Manage for products that have already been purchased.
		/// </summary>
		public void LoadData() {

			// Anything to process?
			if (_controller.PurchaseManager == null)
				return;

			// Clear list
			purchases.Clear ();

			// Find all purchased products
			foreach (InAppProduct product in _controller.PurchaseManager) {
				// Was the product purchased?
				if (product.Purchased) {
					// Yes, add to list
					purchases.Add (product);
				}
			}
		}
		#endregion 

		#region Public Override Methods
		/// <Docs>Table view displaying the sections.</Docs>
		/// <returns>Number of sections required to display the data. The default is 1 (a table must have at least one section).</returns>
		/// <para>Declared in [UITableViewDataSource]</para>
		/// <summary>
		/// Numbers the of sections.
		/// </summary>
		/// <param name="tableView">Table view.</param>
		public override nint NumberOfSections (UITableView tableView)
		{
			// Only one section in this table
			return 1;
		}

		/// <Docs>Table view displaying the rows.</Docs>
		/// <summary>
		/// Rowses the in section.
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override nint RowsInSection (UITableView tableview, nint section)
		{

			// Return value
			return purchases.Count;
		}

		/// <Docs>Table view containing the section.</Docs>
		/// <summary>
		/// Called to populate the header for the specified section.
		/// </summary>
		/// <see langword="null"></see>
		/// <returns>The for header.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="section">Section.</param>
		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return "Purchased Items";
		}

		/// <Docs>Table view containing the section.</Docs>
		/// <summary>
		/// Called to populate the footer for the specified section.
		/// </summary>
		/// <see langword="null"></see>
		/// <returns>The for footer.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="section">Section.</param>
		public override string TitleForFooter (UITableView tableView, nint section)
		{
			return "";
		}

		/// <Docs>Table view requesting the cell.</Docs>
		/// <summary>
		/// Gets the cell.
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (PurchaseTableCell.Key) as PurchaseTableCell;
			
			// Get product for given cell
			InAppProduct product = purchases [indexPath.Row];

			// Populate cell with product information
			cell.DisplayProduct (_controller, _controller.PurchaseManager, product);
			
			return cell;
		}
		#endregion
	}
}

