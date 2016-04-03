// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using MikeCodesDotNET.iOS;
using Xamarin.InAppPurchase;
using Xamarin.InAppPurchase.Utilities;
using CoreGraphics;
using BeerDrinkin.iOS.Helpers;

namespace BeerDrinkin.iOS
{
    public partial class InAppPurchaseViewController : UIViewController
    {
		public InAppPurchaseManager PurchaseManager = new InAppPurchaseManager ();

        public InAppPurchaseViewController (IntPtr handle) : base (handle)
        {
        }

		CGRect btnPayOrginalFrame;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			btnPay.Layer.CornerRadius = 4;
			btnPay.Layer.MasksToBounds = true;


			PurchaseManager.SimulateiTunesAppStore = true;
			PurchaseManager.PublicKey = BeerDrinkin.Core.Helpers.Keys.iTunesAppStorePublicKey;

			if (PurchaseManager.CanMakePayments)
			{
				btnPay.Enabled = true;
			}
			else
			{
				btnPay.Enabled = false;
			}

			PurchaseManager.AutomaticPersistenceType = InAppPurchasePersistenceType.LocalFile;
			PurchaseManager.PersistenceFilename = "AtomicData";
			PurchaseManager.ShuffleProductsOnPersistence = false;
			PurchaseManager.RestoreProducts();

			PurchaseManager.QueryInventory(new string[] {
				"com.micjames.beerdrinkin.pro"
			});

			btnPay.TouchUpInside += delegate
			{
				var product = new InAppProduct("com.micjames.beerdrinkin.pro", "", false, true);
				PurchaseManager.BuyProduct(product);
			};

			PurchaseManager.InAppProductPurchased += (transaction, product) =>
			{
				Acr.UserDialogs.UserDialogs.Instance.ShowSuccess($"You just purchased {product.Title}!");
			};


			PurchaseManager.InAppProductPurchaseFailed += (transaction, product) =>
			{
				Acr.UserDialogs.UserDialogs.Instance.ShowError($"Attempt to purchase {product.Title} has failed: {transaction.Error.ToString()}");
			};


			btnClose.Alpha = 0;
			imgBeerLogo.Alpha = 0;
			lblTitle.Alpha = 0;
			stvwUnlockBarcode.Alpha = 0;
			stvwUnlockOcr.Alpha = 0;
			stvwDarkTheme.Alpha = 0;
			stvwEndlessLove.Alpha = 0;
			btnRestore.Alpha = 0;
			btnPayOrginalFrame = btnPay.Frame;
			btnPay.Alpha = 0;

			var blur = UIBlurEffect.FromStyle (UIBlurEffectStyle.Light);
			var vibrancy = UIVibrancyEffect.FromBlurEffect (blur);
			var vibrancyView = new UIVisualEffectView(vibrancy)
			{
				Frame = View.Frame
			};
			//btnPay.Frame = new CGRect(btnPayOrginalFrame.X, btnPayOrginalFrame.Y + 150, btnPayOrginalFrame.Width, btnPayOrginalFrame.Height);
		}

		NSLayoutConstraint btnPayOrginalConstraint;

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			const double duration = 0.8;
			const float delay = 0.1f;

			imgBeerLogo.Pop(0.2, 0, 1f);

			btnClose.FadeIn(duration, delay);
			imgBeerLogo.FadeIn(duration, delay + 0.1f);
			lblTitle.FadeIn(duration, delay + 0.1f);
			stvwUnlockBarcode.FadeIn(duration, delay + 0.2f);
			stvwUnlockOcr.FadeIn(duration, delay + 0.3f);
			stvwDarkTheme.FadeIn(duration, delay + 0.4f);
			stvwEndlessLove.FadeIn(duration, delay + 0.5f);
			btnRestore.FadeIn(duration, delay + 0.8f);
			btnPay.FadeIn(duration, delay + 1.2f);
		}


		partial void BtnClose_TouchUpInside(UIButton sender)
		{
			this.DismissViewController(true, null);
		}
	}
}