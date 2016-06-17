// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace InAppPurchaseTest
{
	[Register ("PurchaseTableViewController")]
	partial class PurchaseTableViewController
	{
		[Outlet]
		UIKit.UITabBarItem PurchasesTab { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (PurchasesTab != null) {
				PurchasesTab.Dispose ();
				PurchasesTab = null;
			}
		}
	}
}
