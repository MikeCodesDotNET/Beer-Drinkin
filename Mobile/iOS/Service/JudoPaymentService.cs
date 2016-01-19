using System;
using JudoDotNetXamariniOSSDK;
using JudoDotNetXamarin;
using JudoPayDotNet.Models;

namespace BeerDrinkin.iOS
{
    public class JudoPaymentService
    {
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
    }
}

