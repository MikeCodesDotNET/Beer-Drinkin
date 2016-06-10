using System;

using System.Collections.Generic;
using System.Drawing;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using JudoDotNetXamarin;
using JudoDotNetXamariniOSSDK;
using JudoDotNetXamariniOSSDK;
using JudoDotNetXamariniOSSDK.ViewModels;
using JudoDotNetXamariniOSSDK.Views;
using JudoPayDotNet.Models;

using PassKit;

using UIKit;
using JudoPayDotNet.Errors;
using System.Text;

namespace JudoPayiOSXamarinSampleApp
{
    public partial class RootView : UIViewController
    {
        SlideUpMenu _menu;

        //keep this detail from last transaction
        private string cardToken;
        private string consumerToken;
        private string lastFour;
        private CardType cardType;

        private string consumerRef = "consumer10101021";
        private const string cardNumber = "4976000000003436";
        private const string addressPostCode = "TR14 8PA";
        private const string startDate = "";
        private  const string expiryDate = "12/20";
        private const string cv2 = "452";

        private ClientService _clientService;

        public RootView ()
            : base ("RootView", null)
        {
            _clientService = new ClientService ();
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            SetUpTableView ();

            UILabel label = new UILabel (new CGRect (0, 0, 120f, 30f));
            label.TextAlignment = UITextAlignment.Center;
            label.Font = UIFont.FromName ("Courier", 17.0f);
            label.BackgroundColor = UIColor.Clear;

            label.Text = "Judo Sample App";
            this.NavigationController.NavigationBar.TopItem.TitleView = label;

        }

        private void ShowMessage (string title, string message, string btnText = "OK")
        {
            UIAlertView msgbox = new UIAlertView (title, message, null, btnText, null);
            msgbox.Show ();
        }

        private void SuccessPayment (PaymentReceiptModel receipt)
        {
            cardToken = receipt.CardDetails.CardToken;
            consumerToken = receipt.Consumer.ConsumerToken;
            lastFour = receipt.CardDetails.CardLastfour;
            cardType = receipt.CardDetails.CardType;
            DispatchQueue.MainQueue.DispatchAfter (DispatchTime.Now, () => {

                // show receipt
                ShowMessage ("Transaction Successful", "Receipt ID - " + receipt.ReceiptId);

                // store token to further use
            });
        }

        private void FailurePayment (JudoError error, PaymentReceiptModel receipt)
        {
            DispatchQueue.MainQueue.DispatchAfter (DispatchTime.Now, () => {
                // move back to home screen
                // show receipt
                string title = "Error";
                string message = "";
                StringBuilder builder = new StringBuilder ();

                if (error != null && error.ApiError != null)
                    title = (error.ApiError != null ? error.ApiError.Message : "");

                if (error != null && error.ApiError != null) {
                    if (error.ApiError.ModelErrors != null && error.ApiError.ModelErrors.Count > 0) {
                        foreach (FieldError model in error.ApiError.ModelErrors) {
                            builder.AppendLine (model.Message);
                     
                        }
                    } else {
                        title = "Error";
                        builder.AppendLine (error.ApiError.Message);
                    }
                }

                if (receipt != null) {
                    builder.AppendLine ("Transaction : ");
                    builder.AppendLine (receipt.Message);
                    builder.AppendLine ("Receipt ID - " + receipt.ReceiptId);
                }

                ShowMessage (title, builder.ToString ());
            });
                
        }

        void SetUpTableView ()
        {
            Dictionary<string, Action> buttonDictionary = new Dictionary<string, Action> ();
            JudoSuccessCallback successCallback = SuccessPayment;
            JudoFailureCallback failureCallback = FailurePayment;

            var tokenPayment = new TokenPaymentViewModel () {
                Amount = 3.5m,
                ConsumerReference = consumerRef,  
                CV2 = cv2
            };

            buttonDictionary.Add ("Make a Payment", delegate {
                Judo.Instance.Payment (GetCardViewModel (), successCallback, failureCallback);
            });



            buttonDictionary.Add ("PreAuthorise", delegate {
                Judo.Instance.PreAuth (GetCardViewModel (), successCallback, failureCallback);
            });


            buttonDictionary.Add ("Token Payment", delegate {
                tokenPayment.Token = cardToken;
                tokenPayment.ConsumerToken = consumerToken;
                tokenPayment.LastFour = lastFour;
                tokenPayment.CardType = cardType;

                Judo.Instance.TokenPayment (tokenPayment, successCallback, failureCallback);
            });

            buttonDictionary.Add ("Token PreAuthorise", delegate {
                tokenPayment.Token = cardToken;
                tokenPayment.ConsumerToken = consumerToken;
                tokenPayment.LastFour = lastFour;
                tokenPayment.CardType = cardType;

                Judo.Instance.TokenPreAuth (tokenPayment, successCallback, failureCallback);
            });

            buttonDictionary.Add ("Register a Card", delegate {
                var payment = GetCardViewModel ();
                payment.Amount = 1.01m; //Minimum amount Gateways accept without question

                Judo.Instance.RegisterCard (payment, successCallback, failureCallback);
            });
            if (_clientService.ApplePayAvailable) {

                buttonDictionary.Add ("Make a ApplePay Payment", delegate {
                    Judo.Instance.MakeApplePayment (GetApplePayViewModel (), successCallback, failureCallback);
                });

                buttonDictionary.Add ("Make a ApplePay PreAuthorise", delegate {
                    Judo.Instance.MakeApplePreAuth (GetApplePayViewModel (), successCallback, failureCallback);
                });

            }

            MainMenuSource menuSource = new MainMenuSource (buttonDictionary);
            ButtonTable.Source = menuSource;
            TableHeightConstrant.Constant = menuSource.GetTableHeight () + 60f;
        }

        /// <summary>
        /// just for sample app, you can set all settings while configuring SDK
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewWillAppear (bool animated)
        {
            base.ViewWillAppear (animated);
            _menu = new SlideUpMenu (new RectangleF (0, (float)this.View.Frame.Bottom - 40f, (float)this.View.Frame.Width, 448f));
            _menu.AwakeFromNib ();
            _menu.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
            this.View.AddSubview (_menu);
        }

        PaymentViewModel GetCardViewModel ()
        {
            var cardPayment = new PaymentViewModel {
                Amount = 4.5m, 
                ConsumerReference = consumerRef,
                Currency = "GBP",
                // Non-UI API needs to pass card detail
                Card = new CardViewModel {
                    CardNumber = cardNumber,
                    CV2 = cv2,
                    ExpireDate = expiryDate,
                    PostCode = addressPostCode,
                    CountryCode = ISO3166CountryCodes.UK
                }
            };
            return cardPayment;
        }

        ApplePayViewModel GetApplePayViewModel ()
        {
            var summaryItems = new PKPaymentSummaryItem[] {
                new PKPaymentSummaryItem () {
                    Amount = new NSDecimalNumber ("0.90"),
                    Label = @"Judo Burrito"

                },
                new PKPaymentSummaryItem () {
                    Amount = new NSDecimalNumber ("0.10"),
                    Label = @"Extra Guac"

                }
            };
			
            var applePayment = new ApplePayViewModel {
				
                CurrencyCode = new NSString ("GBP"),
                CountryCode = new NSString (@"GB"),
                SupportedNetworks = new NSString[3] {
                    new NSString ("Visa"),
                    new NSString ("MasterCard"),
                    new NSString ("Amex")
                },
                SummaryItems = summaryItems,
                TotalSummaryItem = new PKPaymentSummaryItem () {
                    Amount = new NSDecimalNumber ("1.00"),
                    Label = @"El Judorito"

                },
                ConsumerRef = new NSString (@"GenerateYourOwnCustomerRefHere"),
                MerchantIdentifier = new NSString ("merchant.com.judo.Xamarin")
            };
            return applePayment;
        }

        public override void ViewWillDisappear (bool animated)
        {
            _menu.RemoveFromSuperview ();
            base.ViewWillDisappear (animated);
        }

        public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
        {
            base.DidRotate (fromInterfaceOrientation);
            _menu.ResetMenu ();
        }

        void CloseView ()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
                NavigationController.DismissViewController (true, null);
            } else {
                NavigationController.PopViewController (true);
            }
        }
    }
}

