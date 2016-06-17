using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.InAppPurchase;
using Xamarin.InAppPurchase.Utilities;


namespace InAppPurchaseTest
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{

		#region Public Properties
		public static UIStoryboard Storyboard = UIStoryboard.FromName ("MainStoryboard", null);
		public MainViewController mainView;
		public InAppPurchaseManager PurchaseManager = new InAppPurchaseManager ();
		#endregion

		#region Computed Properties
		/// <summary>
		/// Gets or sets the window.
		/// </summary>
		/// <value>The window.</value>
		public override UIWindow Window {
			get;
			set;
		}
		#endregion 

		#region Override Methods
		/// <summary>
		/// Finisheds the launching.
		/// </summary>
		/// <returns><c>true</c>, if launching was finisheded, <c>false</c> otherwise.</returns>
		/// <param name="application">Application.</param>
		/// <param name="launchOptions">Launch options.</param>
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Assembly public key
			string value = Security.Unify (
				new string[] { "1322f985c2", 
					"a34166b24", 
					"ab2b367", 
					"851cc6" }, 
				new int[] { 0,1,2,3 });

			// Build a window
			Window = new UIWindow (UIScreen.MainScreen.Bounds);

			// Get the defaul view from the storyboard
			mainView = Storyboard.InstantiateInitialViewController () as MainViewController;

			// Display the first view
			Window.RootViewController = mainView;
			Window.MakeKeyAndVisible ();

			// Initialize the In App Purchase Manager
			#if SIMULATED
			PurchaseManager.SimulateiTunesAppStore = true;
			#else
			PurchaseManager.SimulateiTunesAppStore = false;
			#endif
			PurchaseManager.PublicKey = value;
			PurchaseManager.ApplicationUserName = "KMullins";

			// Warn user that the store is not available
			if (PurchaseManager.CanMakePayments) {
				Console.WriteLine ("Xamarin.InAppBilling: User can make payments to iTunes App Store.");
			} else {
				//Display Alert Dialog Box
				using(var alert = new UIAlertView("Xamarin.InAppBilling", "Sorry but you cannot make purchases from the In App Billing store. Please try again later.", null, "OK", null))
				{
					alert.Show();	
				}

			}

			// Warn user if the Purchase Manager is unable to connect to
			// the network.
			PurchaseManager.NoInternetConnectionAvailable += () => {
				//Display Alert Dialog Box
				using(var alert = new UIAlertView("Xamarin.InAppBilling", "No open internet connection is available.", null, "OK", null))
				{
					alert.Show();	
				}
			};

			// Show any invalid product queries
			PurchaseManager.ReceivedInvalidProducts += (productIDs) => {
				// Display any invalid product IDs to the console
				Console.WriteLine("The following IDs were rejected by the iTunes App Store:");
				foreach(string ID in productIDs){
					Console.WriteLine(ID);
				}
				Console.WriteLine(" ");
			};

			// Report the results of the user restoring previous purchases
			PurchaseManager.InAppPurchasesRestored += (count) => {
				// Anything restored?
				if (count==0) {
					// No, inform user
					using(var alert = new UIAlertView("Xamarin.InAppPurchase", "No products were available to be restored from the iTunes App Store.", null, "OK", null))
					{
						alert.Show();	
					}
				} else {
					// Yes, inform user
					using(var alert = new UIAlertView("Xamarin.InAppPurchase", String.Format("{0} {1} restored from the iTunes App Store.",count, (count>1) ? "products were" : "product was"), null, "OK", null))
					{
						alert.Show();	
					}
				}
			};

			// Report miscellanous processing errors
			PurchaseManager.InAppPurchaseProcessingError += (message) => {
				//Display Alert Dialog Box
				using(var alert = new UIAlertView("Xamarin.InAppPurchase", message, null, "OK", null))
				{
					alert.Show();	
				}
			};

			// Report any issues with persistence
			PurchaseManager.InAppProductPersistenceError += (message) => {
				using(var alert = new UIAlertView("Xamarin.InAppPurchase", message, null, "OK", null))
				{
					alert.Show();	
				}
			};

			// Setup automatic purchase persistance and load any previous purchases
			PurchaseManager.AutomaticPersistenceType = InAppPurchasePersistenceType.LocalFile;
			PurchaseManager.PersistenceFilename = "AtomicData";
			PurchaseManager.ShuffleProductsOnPersistence = false;
			PurchaseManager.RestoreProducts ();

			#if SIMULATED
			// Ask the iTunes App Store to return information about available In App Products for sale
			PurchaseManager.QueryInventory (new string[] { 
				"product.nonconsumable",
				"feature.nonconsumable",
				"feature.nonconsumable.fail",
				"gold.coins.consumable_x25",
				"gold.coins.consumable_x50",
				"gold.coins.consumable_x100",
				"newsletter.freesubscription",
				"magazine.subscription.duration1month",
				"antivirus.nonrenewingsubscription.duration6months",
				"antivirus.nonrenewingsubscription.duration1year",
				"product.nonconsumable.invalid",
				"content.nonconsumable.downloadable",
				"content.nonconsumable.downloadfail",
				"content.nonconsumable.downloadupdate"
			});

			// Setup the list of simulated purchases to restore when doing a simulated restore of pruchases
			// from the iTunes App Store
			PurchaseManager.SimulatedRestoredPurchaseProducts = "product.nonconsumable,antivirus.nonrenewingsubscription.duration6months,content.nonconsumable.downloadable";
			#else
			// Ask the iTunes App Store to return information about available In App Products for sale
			PurchaseManager.QueryInventory (new string[] { 
				"xam.iap.nonconsumable.widget",
				"xam.iap.subscription.duration1month",
				"xam.iap.subscription.duration1year",
				"xam.iap.subscription.duration3months"
			});
			#endif

			// Attach the pruchase manager to the Main View
			mainView.AttachToPurchaseManager (Storyboard, PurchaseManager);
		
			return true;
		}

		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
		}
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
		}
		#endregion
	}
}

