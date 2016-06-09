###About Xamarin.InAppPurchase###

The `Xamarin.InAppPurchase` component provides a way to easily and quickly add Apple iTunes App Store In App Purchase of products, features or subscriptions to your iOS mobile applications.

Decorate your _Product Identifiers_ with specific keywords to define properties of your purchase items and have them automatically handled by the component. `Xamarin.InAppPurchase` contains methods to securely persist product purchases and to track items such as subscription dates and consumable product quantities.

In addition, `Xamarin.InAppPurchase` provides the ability to simulate interaction with the iTunes App Store so that In App Purchase routines and UI can be fully tested for every possible scenario. Using the simulation mode, In App Purchases can even be tested in the iOS Simulator and before any purchasable products have been added to iTunes Connect. This allows you to deliver a solid, issue free In App Purchasing experience to your end users.

###Key Features###

`Xamarin.InAppPurchase` supports the following features:

* **Keywords** - Use keywords in your Product Identifiers to define Product Type, Consumable Quantities, Subscription Duration, or test situations such as purchase failure.
* **Simulation Mode** - Run in simulation mode to test Product Identifiers, your app's UI or failure situations before product has been added to iTunes Connect. You can even test your app in the iOS Simulator running on a Mac.
* **Built-In Persistence** - Provides built-in, secure persistence of purchases to User Defaults, Local File System, iCloud or your own custom method.
* **Previous Purchases** - Easily ask if a user has purchased a product, feature or subscription.
* **Consumable Content** - Automatically tracks consumable content, provides methods to obfuscate available quantity and methods to easily consume those quantities.
* **Subscriptions** - Automatically tracks the expiration of both renewing and non-renewing subscriptions.
* **Hosted Content** - Automatically download content hosted in the iTunes App Store via iTunes Connect with tracking of new version availability.
* **Localization** - Handles localized products and provides methods to localize built-in messages and alerts.

###Example Product Identifiers###

As stated above, by using keywords when defining your Product Identifiers, you can define a wide range of products, features or subscriptions that will automatically be handled by the `Xamarin.InAppPurchase` component. Hard to test purchasing situations, such as download failure, can be simulated as well. Here are a few example Product Identifiers:

```
product.nonconsumable
feature.nonconsumable
feature.nonconsumable.fail
gold.coins.consumable_x25
gold.coins.consumable_x50
gold.coins.consumable_x100
newsletter.freesubscription
magazine.subscription.duration1month
antivirus.nonrenewingsubscription.duration6months
antivirus.nonrenewingsubscription.duration1year
product.nonconsumable.invalid
content.nonconsumable.downloadable
content.nonconsumable.downloadfail
content.nonconsumable.downloadupdate
```
_NOTE: Apple suggests that Product Identifiers start with **com.yourcompanyname.appname...**, for the sake of brevity this has not been included in this documentation or the example application, however that notation works correctly with the component._

###Events###

`Xamarin.InAppPurchase` defines the following events that you can monitor and respond to:

####InAppPurchaseManager Events####

* **InAppPurchaseProcessingError** - Raised whenever there is a general failure in processing purchases.
* **InAppPurchaseProductQuantityConsumed** - Raised whenever a quantity of a consumable product has been consumed.
* **InAppPurchasesRestored** - Raised whenever products have been restored from the iTunes App Store.
* **TransactionsRemovedFromQueue** - Raised whenever a transaction has been removed from the iTunes App Store queue.
* **InAppProductPurchased** - Raised whenever a product is purchase successfully.
* **InAppProductRestored** - Raised whenever a product is restored from the iTunes App Store.
* **InAppProductPurchaseFailed** - Raised when the purchase of a product fails.
* **InAppProductPurchaseUserCanceled** - Raised when the user cancels the purchase of a product.
* **ReceivedValidProducts** - Raised when valid products are returned after a call to the _QueryInventory_ method.
* **ReceivedInvalidProducts** - Raised when invalid products are returned after a call to the _QueryInventory_ method.
* **InAppProductWaitingOnContentDownload** - Raised when a product was successfully purchased and has hosted content waiting to be downloaded.
* **RequestInAppProductPersistence** - Raised when automatic persistence is set to _Custom_ and the purchases need to be saved.
* **RequestRestoreInAppProducts** - Raised when automatic persistence is set to _Custom_ and the purchases need to be loaded.
* **InAppProductPersistenceError** - Raised if there is an error persisting previous purchases.
* **InAppProductsRestoredFromPersistence** - Raised if previous purchases were retrieved from automatic persistence.
* **InAppPurchaseDeferred** - Called when parental controls are active and the user tries to make a purchase. After the parent has approved or declined the purchase, the normal In App Purchase events will be called.

####InAppPurchasePaymentObserver Events####

* **InAppPurchaseContentDownloadInProgress** - Raised when hosted content is being downloaded.
* **InAppPurchaseContentDownloadCompleted** - Raised when hosted content has completed downloading.
* **InAppPurchaseContentDownloadFailed** - Raised when hosted content download fails.
* **InAppPurchaseContentDownloadCanceled** - Raised when hosted content download is canceled by the user.
* **InAppPurchaseContentDownloadWaiting** - Raised when hosted content is waiting to be downloaded.

###Secure Transactions###

When developing Xamarin.iOS applications that support In App Purchase there are several steps that should be taken to protect your app from being hacked by a malicious user and keep unlocked content safe.

While the best practice is to perform signature verification on a remote server and not on a device, this might not always be possible. Another technique is to obfuscate your persisted purchases via encryption and never store the assembled encryption key in memory. 

`Xamarin.InAppPurchase` provides a quick and simple method to break your public key into a several pieces and to obfuscate those pieces. Once a public key has been provided to `Xamarin.InAppPurchase` it is never stored as plain text, it is always encrypted in memory.

It also contains built-in methods to securely persist purchase history to the local file system, user defaults, or iCloud. For greater security, the developer can provide their own persistence methods.

###iOS Example###

And here is an example of adding In App Purchasing to the _FinishedLaunching_ method of the **AppDelegate** of an iOS app using `Xamarin.InAppPurchase`:

```
using Xamarin.InAppPurchase;
using Xamarin.InAppPurchase.Utilities;
public InAppPurchaseManager PurchaseManager = new InAppPurchaseManager ();
...

// Initialize the In App Purchase Manager
PurchaseManager.SimulateiTunesAppStore = true;
PurchaseManager.PublicKey = value;

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

// Show any invalid product queries
PurchaseManager.ReceivedInvalidProducts += (productIDs) => {
	// Display any invalid product IDs to the console
	Console.WriteLine("The following IDs were rejected by the iTunes App Store:");
	foreach(string ID in productIDs){
		Console.WriteLine(ID);
	}
	Console.WriteLine(" ");
};

// Setup automatic purchase persistance and load any previous purchases
PurchaseManager.automaticPersistenceType = InAppPurchasePersistenceType.LocalFile;
PurchaseManager.PersistenceFilename = "AtomicData";
PurchaseManager.shuffleProductsOnPersistence = false;
PurchaseManager.RestoreProducts ();

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

// Attach the pruchase manager to the Main View
mainView.AttachToPurchaseManager (Storyboard, PurchaseManager);
```

