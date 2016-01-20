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

namespace BeerDrinkin.iOS
{
    public class JudoPaymentService
    {

        private ClientService _clientService;

        public JudoPaymentService ()
        {
            _clientService = new ClientService ();
        }

        private void SuccessPayment (PaymentReceiptModel receipt)
        {

        }

        private void FailurePayment (JudoError error, PaymentReceiptModel receipt)
        {
                
                            
        }

        public void BuyBeer (BeerPaymentViewModel beerPaymentModel)
        {
            PaymentViewModel judoModel = new PaymentViewModel () {
                Amount = beerPaymentModel.GetSubTotal (),
                Currency = "GBP",
                ConsumerReference = "ImHereForTheBeer01",
                Card = new CardViewModel ()
                
            };
            JudoSuccessCallback successCallback = SuccessPayment;
            JudoFailureCallback failureCallback = FailurePayment;
            Judo.Instance.Payment (judoModel, successCallback, failureCallback);
        }

        public void BuyBeerApplePay (BeerPaymentViewModel beerModel)
        {
            if (_clientService.ApplePayAvailable) {
                JudoSuccessCallback successCallback = SuccessPayment;
                JudoFailureCallback failureCallback = FailurePayment;

           
                Judo.Instance.MakeApplePayment (GetApplePayViewModel (beerModel), successCallback, failureCallback);

             
                Judo.Instance.MakeApplePreAuth (GetApplePayViewModel (beerModel), successCallback, failureCallback);        

            }
        }


        private ApplePayViewModel GetApplePayViewModel (BeerPaymentViewModel beerPaymentModel)
        {
               
            var summaryItems = new PKPaymentSummaryItem[beerPaymentModel.BeerBasket.Count];

            foreach (KeyValuePair<BeerItem,int> item in beerPaymentModel.BeerBasket.ToList()) {
                var summary = new  PKPaymentSummaryItem () {
                                        Amount = new NSDecimalNumber (item.Key.Price),
                                        Label = item.Key.Name + @" X" + item.Value.ToString ()

                };
            }
                       
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
                                        Amount = new NSDecimalNumber (beerPaymentModel.GetSubTotal ().ToString ()),
                                        Label = @"Beer Drinkin"

                },
                                ConsumerRef = new NSString (@"ImHereForTheBeer"),
                                MerchantIdentifier = new NSString ("merchant.com.judo.Xamarin")
            };
                       
            return applePayment;
        }
        
    }
}

