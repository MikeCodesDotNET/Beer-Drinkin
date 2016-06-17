// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace InAppPurchaseTest
{
	[Register ("StoreTableViewController")]
	partial class StoreTableViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITabBarItem StoreTab { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (StoreTab != null) {
				StoreTab.Dispose ();
				StoreTab = null;
			}
		}
	}
}
