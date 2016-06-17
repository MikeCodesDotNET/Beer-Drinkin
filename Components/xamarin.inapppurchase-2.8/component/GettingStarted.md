##Xamarin.InAppPurchase Component##

###Getting Started with Xamarin.InAppPurchase###

To use `Xamarin.InAppPurchase` in your mobile application include the component in your project and reference the following using statements in your C# code:

```
using Xamarin.InAppPurchase;
using Xamarin.InAppPurchase.Utilities;
``` 

###In-App Purchasing Required Setup and Configurations###

Before you can successfully add iTunes App Store In App Purchasing to your mobile application there are several configurations and setting that must be properly configured on both your developer account and the application's identifier in the provisioning portal. For an overview of the In App Purchasing process and a detailed guide to setting the required configurations, please see the [In App Purchasing Basics and Configuration](http://docs.xamarin.com/guides/ios/application_fundamentals/in-app_purchasing/part_1_-_in-app_purchase_basics_and_configuration/) document.

However, several of these configuration and setup requirements are lifted if you are running the `Xamarin.InAppPurchase` component in the _Simulation Mode_. For more details, please see the information on simulating the iTunes App Store in the sections below.

If you are having issues using real In App Products against the live iTunes App Store (either in the Sandbox Environment or a live application), please see the **Testing In-App Purchases** and  **Troubleshooting Guide** sections at the end of this document.

###Before Implementing In-App Purchasing###

While the `Xamarin.InAppPurchase` component makes working with Apple's In-App Purchasing easier by encapsulating most of the common, repetitive code required to implement In-App Purchasing in your app, it still relies on the base StoreKit APIs. As a result, all of the setup, configuration and limitations of using StoreKit directly still apply to the `Xamarin.InAppPurchase` component.

Before you attempt to implement In-App Purchasing in your application using the `Xamarin.InAppPurchase` component, we suggest that you browse the following Apple documents first to get a feel for StoreKit and the requirements that In-App Purchasing places on an iOS application:

* [In-App Purchase Configuration Guide for iTunes Connect](https://developer.apple.com/library/ios/documentation/LanguagesUtilities/Conceptual/iTunesConnectInAppPurchase_Guide/Chapters/Introduction.html#//apple_ref/doc/uid/TP40013727)
* [Adding In-App Purchase to your iOS and OS X Applications](https://developer.apple.com/library/ios/technotes/tn2259/_index.html#//apple_ref/doc/uid/DTS40009578)
* [In-App Purchase Programming Guide](https://developer.apple.com/library/ios/documentation/NetworkingInternet/Conceptual/StoreKitGuide/Introduction.html#//apple_ref/doc/uid/TP40008267)
* [In-App Purchase Product Identifiers](https://developer.apple.com/library/ios/qa/qa1329/_index.html#//apple_ref/doc/uid/DTS40009463)
* [Best Practices when using IAP](https://developer.apple.com/library/ios/technotes/tn2387/_index.html#//apple_ref/doc/uid/DTS40014795)
* [Receipt Validation Programming Guide](https://developer.apple.com/library/ios/releasenotes/General/ValidateAppStoreReceipt/Introduction.html#//apple_ref/doc/uid/TP40010573)

In addition, you should browse our [In-App Purchasing](http://developer.xamarin.com/guides/ios/application_fundamentals/in-app_purchasing/) documentation for a Xamarin-specific example.

###Using the InAppPurchaseManager###

When using the `Xamarin.InAppPurchase` component in your iOS mobile application, you'll first need to create an instance of the **InAppPurchaseManager** class. This class handles all communication with the Apple iTunes App Store, tracks all available products and product purchases and handles automatic persistence of previous purchases.

In the following example, an instance of the **InAppPurchaseManager** class is created in the _FinishedLaunching_ method of the _AppDelegate_ class and then passed to every other view controller in the application:

```
public InAppPurchaseManager PurchaseManager = new InAppPurchaseManager ();
...

// Initialize the In App Purchase Manager
PurchaseManager.SimulateiTunesAppStore = false;
PurchaseManager.PublicKey = value;
...

// Attach the purchase manager to the Main View
mainView.AttachToPurchaseManager (Storyboard, PurchaseManager);
...
```

After the **InAppPurchaseManager** has been created and instantiated, the _CanMakePayments_ property will be _true_ if the current user can make purchases from the iTunes App Store. _For more information, see the Purchase Available section below._

When you initialize the **InAppPurchaseManager**, set a value telling it if it is running in the simulation mode and assign the public encryption key used when persisting purchase information. _For more information see the Security Encryption Key and Simulating the iTunes App Store sections below._

---
_**NOTE:** You should always create and instantiate the **InAppPurchaseManager** class in your application's `FinishedLaunching` method of the `AppDelegate` class otherwise iTunes App Store events such as completing a purchase can be missed. This instance of the **InAppPurchaseManager** class should then be passed to every other view controller that will be working with In-App Purchases in your application. Please see Apple's [In-App Purchase Best Practices](https://developer.apple.com/library/ios/technotes/tn2387/_index.html#//apple_ref/doc/uid/DTS40014795) documentation for more details._

---

####Implementing AttachToPurchaseManager####

Any view controller that will be consuming information from a **InAppPurchaseManager** should inherit from the **IPurchaseViewController** interface and implement the **AttachToPurchaseManager** method. The method takes a copy of the _UIStoryboard_ that the view controller belongs to and an instance of the  **InAppPurchaseManager**. Both parameters should be stored for later use.

In this method the view controller should listen to any required events on the **InAppPurchaseManager** and update its interface or display data as required. Example:

```
public partial class PurchaseTableViewController : UITableViewController, IPurchaseViewController
{
	#region Private Variables
	private InAppPurchaseManager _purchaseManager;
	private UIStoryboard _Storyboard;
	#endregion
	...
	
	// Listen to purchase events
	public void AttachToPurchaseManager(UIStoryboard Storyboard, InAppPurchaseManager purchaseManager) {

		// Save connection
		_Storyboard = Storyboard;
		_purchaseManager = purchaseManager;
		
		_purchaseManager.InAppProductPurchased += (MonoTouch.StoreKit.SKPaymentTransaction transaction, InAppProduct product) => 		{
			// Update list to remove any non-consumable products that were
			// purchased
			ReloadData();
		};
		...
		
	}
	
}
```

####Purchase Availability####

Before making any requests to the **InAppPurchaseManager** your code should check the status of the _CanMakePayments_ property. If this property returns _false_ the user currently logged into the Apple iOS Device does not have the ability to purchase In App Products and your apps store interface should either be disabled or not shown at all.

If you set the _CheckInternetConnection_ property of the **InAppPurchaseManager** to _true_, then an extra check for network connectivity (either via Wi-Fi or Cellular) is made before any call to the iTunes App Store. If no connection is available the **NoInternetConnectionAvailable** event will be raised. The _CheckInternetConnection_ property defaults to _false_ as the internal network connectivity checks done by Apple's StoreKit API are usually enough for most situations.

In addition, the **InAppPurchaseManager** includes a helper property to check the status on internet connectivity, _NetworkReachable_. If this property is _true_, then the iOS device that your app is running on can reach the internet either via Wi-Fi or Cellular network.

####Secure Encryption Key####

The Secure Encryption Key is used when encrypting the data that will be written to the persistence medium that you have selected. It can be any string containing any words or phrases, such as a series of GUIDs, the Shared Secret from your iTunes Connect account or a random string of letters or numbers.

`Xamarin.InAppPurchase` provides the **Unify** routine that can be used to break your public encryption key into two or more pieces and to obfuscate those pieces using one or more key/value pairs. In addition, `Xamarin.InAppPurchase` always encrypts your private key while it's in memory.

Here is an example of using **Unify** to obfuscate a private key:

```
string value = Security.Unify (
	new string[] { "X0X0-1c...", "+123+Jq...", "//w/2jANB...", "...Kl+/ID43" }, 
	new int[] { 2, 3, 1, 0 }, 
	new string[] {  "X0X0-1", "9V4XD", "+123+", "R9eGv", "//w/2", "MIIBI", "+/ID43", "9alu4" });
```
Where the first parameter is an array of strings containing your private key broken into two or more parts in a random order. The second parameter is an array of integers listing of order that the private key parts should be assembled in. The third, optional, parameter is a list of key/value pairs that will be used to replace sequences in the assembled key.

###Simulating the iTunes App Store###

There are several situation that can arise when working with In App Purchases, several of which can be hard to test for. The `Xamarin.InAppPurchase` component provides the ability to simulate interaction with the iTunes App Store so you can fully test out your application and provide a smooth, issue free In App Purchase experience for your end users.

When running in the simulation mode, decorate your product identifiers with specific keywords to test such things as invalid product IDs, failed purchases, hosted content download, etc. You can event test products before they are added to iTunes Connect and can test In App Purchases inside the iOS Simulator on a Mac.

To enter the simulation mode, use the following code:

```
// Initialize the purchase manager
PurchaseManager.SimulateiTunesAppStore = true;
...

// Setup the list of simulated purchases to restore when doing a simulated restore of purchase
// from the iTunes App Store
PurchaseManager.SimulatedRestoredPurchaseProducts = "product.nonconsumable,antivirus.nonrenewingsubscription.duration6months,content.nonconsumable.downloadable";
```

Use the _SimulatedRestoredPurchaseProducts_ property of the **InAppPurchaseManager** to define a list of products that will simulate being restored from the iTunes app store when calling the **RestorePreviousPurchases** method.

The _Simulated_ property of the **InAppProduct** will be _true_ if the product was loaded in the simulation mode.

###Working with Product Identifiers###

The `Xamarin.InAppPurchase` component provides several keywords that can be used in your In App Purchase _Product Identifiers_ to automatically define properties of your products, features or subscriptions. In addition, there are several special keywords that can be used when testing the `Xamarin.InAppPurchase` component in the simulation mode, allowing you to test otherwise hard to duplicate situations such as the download of hosted content failing.

####Product Type####

Include one of the following keywords in your _Product Identifier_ to automatically set the product type:

* **.consumable** - Defines a consumable product.
* **.nonconsumable** - Defines a standard, non-consumable product.
* **.subscription** - Defines an automatically renewing subscription. The expiration date will be managed by the Apple iTunes App Store.
* **.freesubscription** - Defines a free subscription. Free subscriptions can _only_ be used inside of Newsstand applications.
* **.nonrenewingsubscription** - Defines a non-automatically renewing subscription. Combine with a _Subscription Duration_ keyword below to have the **InAppPurchaseManager** automatically handle the expiration date for you.

####Subscription Duration####

Include one of the following keywords in your _Product Identifier_ to have the **InAppPurchaseManager** automatically handle the expiration date for you:

* **.duration7days** - Sets the expiration date to 7 days from the date of purchase.
* **.duration1month** - Sets the expiration date to 1 month from the date of purchase.
* **.duration2months** - Sets the expiration date to 2 months from the date of purchase.
* **.duration3months** - Sets the expiration date to 3 months from the date of purchase.
* **.duration6months** - Sets the expiration date to 6 months from the date of purchase.
* **.duration1year** - Sets the expiration date to 1 year from the date of purchase.

For automatically renewing subscriptions, the Apple iTunes App Store will automatically handle the _ExpirationDate_ and return it as part of the initial purchase receipt. There are instances where this date might not be correct, in those cases, you can set the _UseCalculatedExpirationDate_ of the _InAppProduct_ class to have the expiration date calculated for you using the Duration and the initial date of purchase. However, this should only be done as a last ditch effort.

For Non-Renewing Subscriptions the Subscription Duration will be used to calculate the _ExpirationDate_ off of the initial purchase date of the subscription. Since Non-Renewing Subscriptions are not restored from the iTunes App Store, the developer will have to implement their own logic for storing and restoring this type of purchase from their own servers - including the Expiration Date. This is beyond the scope of the `Xamarin.InAppPurchase` component.


####Consumable Quantities####

When working with consumable items you can specify the quantity of the item being purchased by appending _x#### (where #### is the quantity value) to the end of the *Product Identifier*. For example:

```
gold.coins.consumable_x25
gold.coins.consumable_x50
gold.coins.consumable_x100
```

Would define a package of consumable gold coins containing 25, 50 or 100 coins each.

####Simulating Failure####

When working with the `Xamarin.InAppPurchase` component in the simulation mode add one of the following keywords to your _Product Identifier_ to simulate a failure situation:

* **.invalid** - The given _Product Identifier_ will be rejected by the simulated iTunes App Store as invalid (not defined in iTunes Connect or unavailable) when calling the _QueryInventory_ of the **InAppPurchaseManager**.
* **.fail** - When the user attempts to purchase the given _Product Identifier_ the purchase will fail in the simulated iTunes App Store.

####Hosted Downloadable Content####

If your In App Purchase product has downloadable content hosted on the iTunes App Store add one of the following keywords to your _Product Identifier_:

* **.downloadable** - Tells the **InAppPurchaseManager** that this products has hosted content. The **InAppPurchaseManager** will automatically handle the downloading of the content when the product is purchased or restored. If running in the simulation mode, the **InAppPurchaseManager** will simulate the downloading of content.
* **.downloadfail** - When running in the simulation mode, the downloading of content for this product will fail halfway through.
* **.downloadupdate** - When running in the simulation mode, simulates downloadable content that has an updated version available.

####Example Product Identifiers####

By using the keywords specified above you can define a wide ranges of products, features or subscriptions that will automatically be handled by the `Xamarin.InAppPurchase` component. For example:

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
_NOTE: Apple suggests that Product Identifiers start with **com.yourcompanyname.appname...**, for the sake of brevity this has not been included in this documentation or the example application, however that notation works correctly with the component. For example: **com.xamarin.inapppurchasetest.product.consumable** per Apple's suggestion._

###Requesting Available Products###

Once you have your available products defined in iTunes Connect (or if you are running in the Simulation Mode), use the _QueryInventory_ method of the **InAppPurchaseManager** to return a list of valid products from the iTunes App Store. If any invalid Product Identifiers are found, the _ReceivedInvalidProducts_ event will be raised. Any valid Products will be added to the **InAppPurchaseManagers** collection of **InAppProducts** and the _ReceivedValidProducts_ event will be raised.  

The following is an example of querying inventory from the iTunes App Store:

```
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
```
If the _DefaultToUnknown_ property is _true_ and the **InAppPurchaseManager** cannot decide the type of a product, it will be set to **UnKnown** else it will default to **NonConsumable**.

After a list of _Product Identifiers_ have been successfully returned from the iTunes App Store, the list can be refreshed against the iTunes App Store by calling the _RequeryInventory_ method of the **InAppPurchaseManager**. Example:

```
PurchaseManager.RequeryInventory();
```

###Working with Available Products###

After successfully querying the iTunes App Store and if any valid Product Identifiers were found, the **InAppPurchaseManager** will contain a collection of **InAppProduct** that define the products available for purchase as well as any previous purchases (if they were previously loaded from persistence). The following is an example of getting a list of non-purchased products from the **InAppPurchaseManager**:

```
// Find all non-purchased products
foreach (InAppProduct product in PurchaseManager) {

	// Take action based on the product type
	switch (product.ProductType) {
	case InAppProductType.Consumable:
		// Consumable products can always be purchased again
		products.Add (product);
		break;
	case InAppProductType.AutoRenewableSubscription:
	case InAppProductType.NonRenewingSubscription:
		// Only display if the subscription has expired
		if (product.subscriptionExpired)
			products.Add (product);
		break;
	default:
		// Only display if the product hasn't been purchased
		if (!product.purchased)
			products.Add (product);
		break;
	}
}
```

Aside from containing the full product details, the **InAppProduct** class contains two properties for working with the unit price of the In App Product:

* **Price** - Contains the raw decimal price of the product as defined within iTunes Connect based on the Pricing Tier selected.
* **FormattedPrice** - A string containing the price ready to be displayed to the end user in the localized format.

Depending on the type of Automatic Persistence selected (if any), the pricing information may not be set when restoring products from persistence and will need to be re-retrieved from the iTunes App Store.

###Purchasing Products###

Once the user has selected a product, feature or subscription for purchase, call the _BuyProduct_ method of the **InAppPurchaseManager** to start the purchasing process with the iTunes App Store. Example:

```
PurchaseManager.BuyProduct (Product);
```
The user will be asked to log into their iTunes account (if not already) and be asked for their password. If the purchase is successful, the _InAppProductPurchased_ event will be raised with the transaction returned by Apple, else the _InAppProductPurchaseFailed_ event will be raised with the reason for the failure. If the user cancels the purchase, the _InAppProductPurchaseUserCanceled_ event will be raised instead.

If the optional _ApplicationUserName_ has been set on the **InAppPurchaseManager** class, that value will be encrypted and sent along with the purchase request to help eliminate fraud. This value should be a unique ID used to identify the user of your application. For example, the UserID of the account that the user uses to log into your servers.

####Verifying Transactions Against the iTunes App Store####

Apple suggests that you pass transactions to your own server that are then passed along to be verified against the iTunes App Store. The `Xamarin.InAppPurhcase` component does not provide a mechanism to handle this type of validation automatically. However whenever products are purchased your application can monitor the _InAppProductPurchased_ event of the **InAppPurhcaseManager** and pass the provided transaction on for validation.

If validation fails, call the **Invalidate** method of the **InAppProductReceipt** attached to the given **InAppProduct** to invalidate the purchase of the product.

For more information on verifying transaction receipts, please see Apple's [Receipt Validation Programming Guide](https://developer.apple.com/library/ios/releasenotes/General/ValidateAppStoreReceipt/Introduction.html#//apple_ref/doc/uid/TP40010573) documentation and Xamarin's [Transactions and Verification](http://docs.xamarin.com/guides/ios/application_fundamentals/in-app_purchasing/part_5_-_transactions_and_verification/) documentation.

####iTunes App Store Hosted Content####

If the product has content hosted in the iTunes App Store, the _InAppProductWaitingOnContentDownload_ event will be raised instead of the _InAppProductPurchased_ event. If the user is not connected to Wi-Fi, they will be asked if they wish to download the content now, else the content will start to download automatically.

The _DownloadDirectory_ property is used to specify the directory where the downloaded content will be saved. If the _CreateFolderForProduct_ property is _true_, a new folder will be created for each product based on it's Product Identifier (minus the periods). If the _OverwriteExistingContent_  property is _true_ then duplicate content will overwrite existing content, else content will be skipped. If the _FailOnDuplicateFile_ property is _true_, duplicate content will raise an error and the copy will be aborted.

The status of the download can be monitored by observing the _InAppPurchaseContentDownloadInProgress_, _InAppPurchaseContentDownloadCompleted_, _InAppPurchaseContentDownloadFailed_, _InAppPurchaseContentDownloadCanceled_ or the _InAppPurchaseContentDownloadWaiting_ events of the **InAppPurchasePaymentObserver** attached to your **InAppPurchaseManager**.

If the **InAppPurchaseManager** is in the process of downloading content, the _ActiveDownload_ property will be _true_ and the _ProductDownloadingContent_ property will contain the product that content is being loaded for. The _ActiveDownloadPercent_ will contain the percentage of the file that has been downloaded as a number between 0 and 1.

Once the content has been successfully downloaded, the _InAppProductPurchased_ event will be raised and the transaction will be finalized with the iTunes App Store.

For any **InAppProduct** that has hosted content, the _NewContentAvailable_ property will be _true_ if a newer version of the content is on the iTunes App Store that the content currently installed. The _DownloadableContentVersion_ will be the version of the latest content available on the iTunes App Store and the _DownloadableContentVersion_ of the product's **InAppProductReceipt** will contain the currently loaded content version. The _ContentDownloaded_ proper will be _true_ if the content has been loaded for the product and the _ContentPath_ will point to the directory holding the content.

####Subscriptions####

If the **InAppProduct** being purchased is a subscription, either auto renewing or non-renewing, the _SubscriptionDuration_ will set or return the length of the subscription and the _SubscriptionExpirationDate_ will return the date that the subscription will expire. If the product is past is subscription date, the _SubscriptionExpired_ property will be _true_.

###Secure Automatic Purchase Persistence###

When working with built-in persistence, the `Xamarin.InAppPurchase` component has several features to help obfuscate the persistence medium and hide it from malicious attacks. The following is an example of restoring previous purchases from a persistence file:

```
// Define a required public encryption key for persistence
PurchaseManager.PublicKey = "abcd...1234";
...

// Setup automatic purchase persistence and load any previous purchases
PurchaseManager.AutomaticPersistenceType = InAppPurchasePersistenceType.LocalFile;
PurchaseManager.PersistenceFilename = "AtomicData";
PurchaseManager.ShuffleProductsOnPersistence = false;
PurchaseManager.RestoreProducts ();
```
Use the _AutomaticePersistenceType_ property to select the type of automatic purchase persistence that the **InAppPurchaseManager** will use as one of the following:

* **None** - No automatic persistence.
* **UserDefaults** - Store the persisted purchases in the application's user defaults plist. _NOTE: This method of persistence is not suggested due to security risks and is only provided for testing purposes._
* **LocalFile** - Purchases will be stored as encrypted data in the mobile device's local file system.
* **iCloud** - Purchases will be stored to the user's iCloud account as encrypted data and shared across devices. _NOTE: Your application must be configured to use iCloud, please see the [Introduction to iCloud](http://tinyurl.com/p3ab2x9) document for more information._
* **Custom** - Use a developer provided custom method to persist purchase information. Monitor the **RequestInAppProductPersistence** event of the **InAppPurchaseManager** to persist the purchase information and the **RequestRestoreInAppProducts** event to restore it when required.

The _PublicKey_ must be set to a non-empty ("") value before any of the persistence methods will work. This key is required during the encryption/decryption of persisted items.

The _PersistenceFilename_ property interacts with the _AutomaticePersistenceType_ to control where the purchase information is persisted. Try to pick a filename that has nothing to do with purchasing to help hide your encrypted content. Any valid filename without extension can be used. _PersistenceFilename_ is required for _UserDefaults_, _LocalFile_ and _iCloud_ automatic persistence types.

If the _ShuffleProductsOnPersistence_ property is _true_ then purchase information will be shuffled every time they are persisted to further help obfuscate the content. if the _AutoPersistAfterPurchase_ property is _true_ and an automatic persistence type has been set, the **InAppPurchaseManager** will automatically persist product information after a successful purchase.

If the _FullPersistence_ property is set to _true_ then automatic product persistence will save the full details of the **InAppProduct**s to the persistence file. This is not suggested as it will increase the size of the persistence file and provide a greater target for hackers. Instead you should query the iTunes App Store again to get details such as title, description and price after products have been restored.

With the **InAppPurchaseManager** initialized and the automatic persistence properties set, call the _RestoreProducts_ method when your application starts to restore any previous purchases made by the user. If the _SetDefaultTitleAndDescriptionOnRestore_ property is set to _true_, then simulated titles and descriptions will be used until the real information can be loaded from the iTunes App Store via a _QueryInventory_ call.

The **InAppProduct** _DeveloperPayload_ property is a string that can hold any other information that you would like to have persisted along with the product information.

If at any point persistence fails, the _InAppProductPersistenceError_ event will be raised with the reason for the failure.

---
_**SECURITY WARNING!** While every attempt to obfuscate and secure your purchase information has been made inside the `Xamarin.InAppPurchase` component, there is a certain amount of risk involved as it can create "known patterns" that can be search for and hacked. The most secure method of purchase persistence is to set the `AutomaticePersistenceType` to `Custom` and provide your own unique persistence method for each mobile application you create._

---

###Recovering Previous Purchase###

If the user has previously purchased any In App Products or Subscriptions and has erased the application, call the _RestorePreviousPurchases_ method of the **InAppPurchaseManager** to recover those purchases. Example:

```
PurchaseManager.RestorePreviousPurchases();

```

If the optional _ApplicationUserName_ has been set on the **InAppPurchaseManager** class, that value will be encrypted and sent along with the restore request to help eliminate fraud. This value should be a unique ID used to identify the user of your application and should be the same one used when the initial purchase was made. For example, the UserID of the account that the user uses to log into your servers.

For any restored product that has downloadable content hosted on the iTunes App Store, if the content is not available on the user's device it will automatically start downing after a successful restore. If the _PromptToRestoreHostedContent_ property is _true_, the user will be asked if they wish to restore the content at this time. If the _PromptToDownloadOverCellular_ is _true_ and the user's device is not connected to wi-fi, they will be asked if they want to download the content over a cellular network.

The _InAppPurchaseUserCanceledRestore_ event will be called if the user cancels the restore of previous purchases from the iTunes App Store. Previous version of the component just raised the generic _InAppPurchaseProcessingError_ event.

The iTunes App Store will _only_ restore the previous purchase of **Non Consumable Products** and **Auto Renewing Subscriptions**. For any other type of previous product purchases, the developer is responsible for developing a restore mechanism, such as storing the purchase information on their own servers and retrieve the purchase information from there.

---
_NOTE: **RestorePreviousPurchases** is also used to retrieve updated version of hosted downloadable content. This is a limitation of the Apple iTunes App Store and not the `Xamarin.InApppurchase` component._

---

###Working with Purchased Products###

When the user successfully purchases a product, feature or subscription, the **InAppPurchaseManager** will keep track of those purchases. Test the _Purchased_ property of any **InAppProduct** to see if the user has purchased it. The following example will retrieve a list of purchased products:

```
// Find all purchased products
foreach (InAppProduct product in PurchaseManager) {
	// Was the product purchased?
	if (product.Purchased) {
		// Yes, add to list
		purchases.Add (product);
	}
}

```

You can also pass a Product Identifier to the _ProductPurchased_ method of the **InAppPurchaseManager** to see if it has been purchase. For Example:

```
// Was the feature purchased?
if (PurchaseManager.ProductPurchased("my.nonconsumabe.feature")) {
	...
}

```

###Finding a Product by its Identifier###

Once a product has been retrieved from the iTunes App Store or previously purchased you can ask the **InAppPurchaseManager** to find it by its _Product Identifier_. For example:

```
// Request a given product
InAppProduct product = PurchaseManager.FindProduct("my.nonconsumabe.feature");

// Found?
if (product != null) {
	...
}
```

###Working with Consumable Quantities###

When working with consumable products packages with multiple quantities available the `Xamarin.InAppPurchase` component has several features to persist and obfuscate the available quantity.

Given the following products are available for purchase and the user purchases one of each package:

```
gold.coins.consumable_x25
gold.coins.consumable_x50
gold.coins.consumable_x100
```

The following code would return a quantity of 175 gold coins available for use:

```
int quantity = PurchaseManager.ProductQuantityAvailable ("gold.coins");
```

The following code would consume 30 gold coins:

```
PurchaseManager.ConsumeProductQuantity("gold.coins", 30);
```

Given the scenario listed above the **gold.coins.consumable_x25** product would be totally consumed and the **gold.coins.consumable_x50** would have 45 coins left. Calling `PurchaseManager.ProductQuantityAvailable ("gold.coins")` again would return 145 gold coins remaining.

For **InAppProducts** that are **Consumable**, the _QuantityMultiplier_ will hold the number of items that will be given when purchasing that product, for example 50 for the _gold.coins.consumable_x50_. The _AvailableQuantity_ property holds the amount currently available for usage.

###Localization###

The `Xamarin.InAppPurchase` component automatically retrieves localized content (if available) from the iTunes App Store when querying for available products, features or subscriptions. However the component contains several built-in message and alerts that will need to be localized by hand inside your mobile application.

The **InAppPurchaseManager** contains the following strings that can be set for localization:

```
LocalizedProductIDError = "Error processing product IDs: {0}"; // Where {0} is the list of IDs
LocalizedRequestFailedError = "Request failed: {0}"; // Where {0} is the error message
LocalizedEncryptionKeyError = "ERROR: The required Public Encryption Key has not been set. Please provide a value for the PublicKey property.";
LocalizedFindProductError = "Error: Unable to find product {0}"; // Where {0} is the Product ID
LocalizedPersistProductsError = "Unable to persist products: {0}"; // Where {0} is a list of Product IDs
LocalizedRestoreProductsError = "Unable to restore products: {0}"; // Where {0} is a list of Product IDs
LocalizedHostedContentFileExistsError = "Unable to save hosted content: File already exists {0}"; // Where {0} is the path and filename
LocalizedSaveHostedContentError = "Unable to save downloaded content for product {0}: {1}"; // Where {0} is the product title and {1} is the error message
LocalizedSimulatedStoreAlertTitle = "Simulated iTunes App Store";
LocalizedSimulatedStoreAlertDescription = "Confirm purchase of {0} for {1}?"; // Where {0} is the product title and {1} is the price
LocalizedButtonCancel = "Cancel";
LocalizedButtonBuy = "Buy";
```

In addition, the **InAppPurchasePaymentTransactionObserver** contains the following localization strings:

```
LocalizedRestoreError = "Unable to restore previous purchases: {0}"; // Where {0} is the error message
LocalizedFindProductError = "Error: Unable to find product {0}"; // Where {0} is the Product ID
LocalizedNetworkUnavaiableError = "Network unavailable, unable to download content for {0}."; // Where {0} is the Product ID
LocalizedDownloadAlertTitle = "Download Product Content";
LocalizedDownloadOverCellularMessage = "You are not connected to Wi-Fi, are you sure you want to download the content for {0}?"; // Where {0} is the product title
LocalizedRestoreDownloadMessage = "Do you want to restore the content for {0}?"; // Where {0} is the product title
LocalizedButtonOK = "OK";
LocalizedButtonCancel = "Cancel";
```

###Provided Events###

Your application should monitor several of the events provided by the **InAppPurchaseManager** and **InAppPurchasePaymentObserver** to respond to In App Purchases to activate purchased products, features or content and/or update the application's UI as required.

####InAppPurchaseManager Events####

The following events are available:

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
* **InAppPurchaseUserCanceledRestore** - Raised if a request has been made to restore previous purchases and the user cancels the process.
* **InAppPurchaseDeferred** - Called when parental controls are active and the user tries to make a purchase. After the parent has approved or declined the purchase, the normal In App Purchase events will be called.

####InAppPurchasePaymentObserver Events####

The following events are available:

* **InAppPurchaseContentDownloadInProgress** - Raised when hosted content is being downloaded.
* **InAppPurchaseContentDownloadCompleted** - Raised when hosted content has completed downloading.
* **InAppPurchaseContentDownloadFailed** - Raised when hosted content download fails.
* **InAppPurchaseContentDownloadCanceled** - Raised when hosted content download is canceled by the user.
* **InAppPurchaseContentDownloadWaiting** - Raised when hosted content is waiting to be downloaded.

##Testing In-App Purchasing##

When initially testing In-App Purchasing in your iOS application using the `Xamarin.InAppPurchase` component, set the _Simulated_ property of the **InAppPurchaseManager** to _true_ and provide a set of product IDs using the testing keywords. In this way, you can make sure that your application gracefully handles all situations that can arise when dealing with In-App Purchasing, such as a purchase failing. You can also run tests in the iOS Simulator using this mode of operation.

When you are ready to test with real product IDs entered for your application in iTunes Connect, set the _Simulated_ property of the **InAppPurchaseManager** to _false_ and provide the real IDs to the purchase manager (making sure to decorate them with the correct keywords).

Testing real products requires a real iOS device and will not work in the iOS Simulator on a Mac. Also testing can only be done using a Test User Account created in iTunes Connect. To test with this account do the following:

1. On the test device open the **iTunes App Store** App.
2. Scroll to the bottom of the screen and tap on your **Apple ID**.
3. Select **Sign Out**.
4. **DO NOT sign into the iTunes App Store using the Test User Account here!** If you do that account will be invalidated and no longer able to be used for testing.
5. Run your application that includes the `Xamarin.InAppPurchase` component and the device and attempt to make a purchase.
6. You'll asked to sign into the App Store, use the Test Account credentials here.

When purchases are made (or any other transaction processed), you should see a note about being in the **Sandbox Environment**, if not, something has gone wrong and you will need to repeat the steps above again. Failing to do the above steps will result in any purchase attempt failing with a generic error message.

For more information on setting up and testing In-App Purchase equipped Xamarin.iOS applications, please see our [In-App Purchasing](http://developer.xamarin.com/guides/ios/application_fundamentals/in-app_purchasing/) documentation.


##Troubleshooting Guide##

Most issues getting In App Purchases to run on a real iOS device (either in the Sandbox or the live store) are caused by a configuration mismatch between the Provisioning Portal/iTunes Connect and the App Binary. If you are have having issues with In App Purchases using the `Xamarin.InAppPurchase` component, here are a couple of things to check:

* **Contracts, Tax and Banking** - Ensure that your developer account has been fully configured to make In App Purchases and that no policy updates are awaiting your approval. See the **Configuration** section of the [In App Purchasing Basics and Configuration](http://docs.xamarin.com/guides/ios/application_fundamentals/in-app_purchasing/part_1_-_in-app_purchase_basics_and_configuration/) document for more details.
* **Bundle ID** - Make sure the bundle ID for the application matches what you have defined in iTunes Connect & the Apple Certificates, Identifiers & Profiles website _exactly_.
* **Developer Identity & Provisioning Profile** - Again, make sure these match what is in iTunes Connect.
* **In-App Purchase Enabled** - In the Apple Certificates, Identifiers & Profiles website, make sure that your apps Provisioning Profile (as specified by the Bundle ID) has been configured for In-App Purchase in both _Development_ and _Distribution_.
* **InAppPurchaseManager** - You should always create and instantiate the **InAppPurchaseManager** class in your application's *FinishedLaunching* method of the *AppDelegate* class otherwise iTunes App Store events such as completing a purchase can be missed.
* **Product Status** - Ensure that the status of your In App Products in iTunes Connect are either _Waiting for Review_ or _Ready to Submit_.
*  **Physical Device** - Testing In App Purchases in the sandbox only works on real Apple hardware, not in simulation for most of the features.
* **Test User Account** - You have to create a test user account in iTunes Connect, on the physical device you are testing on open the iTunes App Store and sign out of your live account. When you test the app in Xamarin Studio on a physical device, you'll be asked to log in to iTunes, enter your test account information here. _(Note: If you log into the iTunes App Store App with a test account, it will be invalidated and can no longer be used for testing!)_

Outside of the above, are the **PurchaseManager.InAppPurchaseProcessingError** or **PurchaseManager.ReceivedInvalidProducts** event being raised? Are you monitoring the **PurchaseManager.ReceivedValidProducts** event as well?

Unfortunately Apple's Sandbox Environment could also be down or partially down (something that seems to happen quite often) and, other than searching the internet, there is no good way to tell what it's current state is. If you are having an unexplained error or "code that was working yesterday, all the sudden _just stops working_", it could indicate an issue with the Sandbox servers.

##Examples##

For full examples of using `Xamarin.InAppPurchase` in your mobile application, please see the  _InAppPurchaseTest_ example app included with this component.

See the API documentation for `Xamarin.InAppPurchase` for a complete list of features and their usage.

## Other Resources

* [Xamarin Components](https://components.xamarin.com)
* [In App Purchasing with C#](http://docs.xamarin.com/guides/ios/application_fundamentals/in-app_purchasing/)
* [Configuring your App for iCloud](http://tinyurl.com/p3ab2x9)
* [In App Purchase Guidelines](https://developer.apple.com/in-app-purchase/In-App-Purchase-Guidelines.pdf)
* [Configuring iTunes Connect for In App Purchase](https://developer.apple.com/library/ios/documentation/LanguagesUtilities/Conceptual/iTunesConnectInAppPurchase_Guide/Chapters/Introduction.html)
* [Adding In App Purchase to you Application](https://developer.apple.com/library/ios/technotes/tn2259/_index.html)
* [StoreKit Framework Reference](https://developer.apple.com/library/ios/documentation/StoreKit/Reference/StoreKit_Collection/_index.html)
* [Receipt Validation Reference](https://developer.apple.com/library/ios/releasenotes/General/ValidateAppStoreReceipt/Introduction.html#//apple_ref/doc/uid/TP40010573)
* [Support](http://xamarin.com/support)