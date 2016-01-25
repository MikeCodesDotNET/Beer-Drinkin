using System;
using JudoDotNetXamariniOSSDK;
using JudoDotNetXamarin;
using JudoPayDotNet.Models;
using JudoDotNetXamariniOSSDK.ViewModels;
using PassKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using BeerDrinkin.Service.DataObjects;
using CoreFoundation;
using UIKit;

namespace BeerDrinkin.iOS
{
    public class JudoPaymentService
    {

        private ClientService _clientService;

        public JudoPaymentService ()
        {
            _clientService = new ClientService ();
        }

        private void ShowMessage (string title, string message, string btnText = "OK")
        {
            UIAlertView msgbox = new UIAlertView (title, message, null, btnText, null);
            msgbox.Show ();
        }

        private void SuccessPayment (PaymentReceiptModel receipt)
        {

//            Client.Instance.PaymentToken.CardToken = receipt.CardDetails.CardToken;
//            Client.Instance.PaymentToken.ConsumerToken = receipt.Consumer.ConsumerToken;
//            Client.Instance.PaymentToken.CardLastfour = receipt.CardDetails.CardLastfour;
//            Client.Instance.PaymentToken.CardType = (int)receipt.CardDetails.CardType;
//            DispatchQueue.MainQueue.DispatchAfter (DispatchTime.Now, () => {
//
//                // show receipt
//                ShowMessage ("Transaction Successful", "Receipt ID - " + receipt.ReceiptId);
//
//                // store token to further use
//            });
        }


        private void FailurePayment (JudoError error, PaymentReceiptModel receipt)
        {
                
                            
        }

     

        public void BuyBeer (BeerPaymentViewModel beerPaymentModel)
        {
//            PaymentViewModel judoModel = new PaymentViewModel () {
//                Amount = beerPaymentModel.GetSubTotal (),
//                Currency = "GBP",
//                ConsumerReference = "ImHereForTheBeer01",
//                Card = new CardViewModel ()
//                
//            };
//            JudoSuccessCallback successCallback = SuccessPayment;
//            JudoFailureCallback failureCallback = FailurePayment;
//
//
//            if (String.IsNullOrEmpty (Client.Instance.PaymentToken.CardToken)) {
//                Judo.Instance.Payment (judoModel, successCallback, failureCallback);
//            } else {
//                TokenPaymentViewModel tokenModel = new TokenPaymentViewModel () {
//                    Amount = beerPaymentModel.GetSubTotal (),
//                    Currency = "GBP",
//                    ConsumerReference = "ImHereForTheBeer01",
//                    Token = Client.Instance.PaymentToken.CardToken,
//                    ConsumerToken = Client.Instance.PaymentToken.ConsumerToken,
//                    LastFour = Client.Instance.PaymentToken.CardLastfour,
//                    CardType = (CardType)Client.Instance.PaymentToken.CardType  
//                    
//                };
//                Judo.Instance.TokenPayment (tokenModel, successCallback, failureCallback);
//            }

           
        }

        public void BuyBeerApplePay (BeerPaymentViewModel beerModel)
        {
//            if (_clientService.ApplePayAvailable) {
//                JudoSuccessCallback successCallback = SuccessPayment;
//                JudoFailureCallback failureCallback = FailurePayment;
//
//                Judo.Instance.MakeApplePreAuth (GetApplePayViewModel (beerModel), successCallback, failureCallback);        
//
//            }
        }


        //        private ApplePayViewModel GetApplePayViewModel (BeerPaymentViewModel beerPaymentModel)
        //        {
        //
        //            var summaryItems = new List<PKPaymentSummaryItem> ();
        //
        //            foreach (KeyValuePair<BeerItem,int> item in beerPaymentModel.BeerBasket.ToList()) {
        //                var summary = new  PKPaymentSummaryItem () {
        //                                        Amount = new NSDecimalNumber (item.Key.Price),
        //                                        Label = item.Key.Name + @" X" + item.Value.ToString ()
        //
        //                };
        //                summaryItems.Add (summary);
        //            }
        //
        //            var applePayment = new ApplePayViewModel {
        //
        //                                CurrencyCode = new NSString ("GBP"),
        //                                CountryCode = new NSString (@"GB"),
        //                                SupportedNetworks = new NSString[3] {
        //                                        new NSString ("Visa"),
        //                                        new NSString ("MasterCard"),
        //                                        new NSString ("Amex")
        //                },
        //                                SummaryItems = summaryItems.ToArray (),
        //                                TotalSummaryItem = new PKPaymentSummaryItem () {
        //                                        Amount = new NSDecimalNumber (beerPaymentModel.GetSubTotal ().ToString ()),
        //                                        Label = @"Beer Drinkin"
        //
        //                },
        //                                ConsumerRef = new NSString (@"ImHereForTheBeer"),
        //                                MerchantIdentifier = new NSString ("merchant.com.mikejames.beerdrinkin")
        //            };
        //
        //            return applePayment;
        //        }
        
    }
}

