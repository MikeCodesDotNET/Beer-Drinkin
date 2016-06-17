using Android.App;
using Android.OS;
using JudoDotNetXamarin;
using JudoPayDotNet.Enums;
using System;
using Android.Widget;
using JudoPayDotNet.Models;
using JudoDotNetXamarinAndroidSDK;
using Android.Content;
using JudoPayDotNet.Errors;
using Android.Views.InputMethods;
using Android.Views;
using System.Text;

namespace Android.Xamarin.SampleApp
{
    [Activity (Label = "@string/app_name_ui", MainLauncher = true, Icon = "@drawable/ic_app_icon")]
    public class WithUIActivity : Activity
    {
        private string paymentReference = "payment101010102";
        private string consumerRef = "consumer1010102";
        private const string cardNumber = "4976000000003436";
        private const string addressPostCode = "TR14 8PA";
        private const string startDate = "";
        private  const string expiryDate = "12/15";
        private const string cv2 = "452";

        private volatile string cardToken;
        private volatile string consumerToken;
   
        private volatile string lastFour;
        private volatile CardType cardType;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.withui);

            ConfigureJudoSDK ();

            // Get our button from the layout resource,
            // and attach an event to it
            Button payCard = FindViewById<Button> (Resource.Id.payCard);
            Button payToken = FindViewById<Button> (Resource.Id.payToken);
            Button payPreAuth = FindViewById<Button> (Resource.Id.payPreAuth);
            Button payTokenPreAuth = FindViewById<Button> (Resource.Id.payTokenPreAuth);
            Button registerCard = FindViewById<Button> (Resource.Id.registerCard);

            // Assigning click delegates
            payCard.Click += new EventHandler (payCard_Click);
            payToken.Click += new EventHandler (payToken_Click);
            payPreAuth.Click += new EventHandler (payPreAuth_Click);
            payTokenPreAuth.Click += new EventHandler (payTokenPreAuth_Click);
            registerCard.Click += new EventHandler (registerCard_Click);

            FindViewById<TextView> (Resource.Id.sdk_version_label).Text = "";

            Switch switchbutton = FindViewById<Switch> (Resource.Id.switch1);
            switchbutton.Checked = Judo.UIMode; 

            switchbutton.CheckedChange += delegate(object sender, CompoundButton.CheckedChangeEventArgs e) {
                Judo.UIMode = switchbutton.Checked;
                // Perform action on clicks
                if (switchbutton.Checked)
                    Toast.MakeText (this, "UI Mode on", ToastLength.Short).Show ();
                else
                    Toast.MakeText (this, "You are about to use non UI Mode so please look at the source code to understand the usage of Non-UI APIs.", ToastLength.Short).Show ();
            };

            if (bundle != null) {
                RestoreState (bundle);
            }

        }

        private void SuccessPayment (PaymentReceiptModel receipt)
        {
            cardToken = receipt.CardDetails.CardToken;
            consumerToken = receipt.Consumer.ConsumerToken;
            lastFour = receipt.CardDetails.CardLastfour;
            cardType = receipt.CardDetails.CardType;
            //set alert for executing the task
            AlertDialog.Builder alert = new AlertDialog.Builder (this);
            alert.SetTitle ("Transaction Successful, Receipt ID - " + receipt.ReceiptId);
            alert.SetPositiveButton ("OK", (senderAlert, args) => {
            });

            RunOnUiThread (() => {
                alert.Show ();
            });
        }

        private void FailurePayment (JudoError error, PaymentReceiptModel receipt)
        {
            //set alert for executing the task
            AlertDialog.Builder alert = new AlertDialog.Builder (this);

            string title = "Error";
            StringBuilder builder = new StringBuilder ();

            if (error != null && error.ApiError != null) {
                title = (error.ApiError.Message);
                if (error.ApiError.ModelErrors != null && error.ApiError.ModelErrors.Count > 0) {
                    foreach (FieldError model in error.ApiError.ModelErrors) {
                        builder.AppendLine (model.Message + (!String.IsNullOrWhiteSpace (model.FieldName) ? "(" + model.FieldName + ")" : ""));
                    }
                } else {
                    title = ("Error");
                    builder.AppendLine (error.ApiError.Message);

                }
            }
            if (receipt != null) {
                builder.AppendLine ("Transaction : " + receipt.Result);
                builder.AppendLine (receipt.Message);
                builder.AppendLine ("Receipt ID - " + receipt.ReceiptId);
            }
            alert.SetTitle (title);
            alert.SetMessage (builder.ToString ());
            alert.SetPositiveButton ("OK", (senderAlert, args) => {
            });
                
            RunOnUiThread (() => {
                alert.Show ();
            });
        }

        private void payCard_Click (object sender, EventArgs e)
        {
            var cardModel = GetCardViewModel ();

            Judo.AmExAccepted = true;
            Judo.Instance.Payment (cardModel, SuccessPayment, FailurePayment, this);

        }

        private void payPreAuth_Click (object sender, EventArgs e)
        {
            Judo.Instance.PreAuth (GetCardViewModel (), SuccessPayment, FailurePayment, this);
        }

        private void payToken_Click (object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace (cardToken) || string.IsNullOrWhiteSpace (lastFour)) {
                Toast.MakeText (this,
                    "Can't make a token payment before making a full card payment to save card token",
                    ToastLength.Short).Show ();
                return;
            }
                
            Judo.Instance.TokenPayment (GetTokenCardViewModel (), SuccessPayment, FailurePayment, this);

        }

        private void payTokenPreAuth_Click (object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace (cardToken) || string.IsNullOrWhiteSpace (lastFour)) {
                Toast.MakeText (this,
                    "Can't make a Preauth token payment before making a full preauth card payment to save card token",
                    ToastLength.Short).Show ();
                return;
            }

            Judo.Instance.TokenPreAuth (GetTokenCardViewModel (), SuccessPayment, FailurePayment, this);

         
        }

        private void registerCard_Click (object sender, EventArgs e)
        {
            var payment = GetCardViewModel ();
            payment.Amount = 1.01m;
            Judo.Instance.RegisterCard (payment, SuccessPayment, FailurePayment, this);
        }

        private PaymentViewModel GetCardViewModel ()
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

        TokenPaymentViewModel GetTokenCardViewModel ()
        {
            var tokenPayment = new TokenPaymentViewModel () {
                Amount = 3.5m,
                ConsumerReference = consumerRef,
                Currency = "GBP",
                CV2 = cv2,
                Token = cardToken,
                ConsumerToken = consumerToken,
                LastFour = lastFour,
                CardType = cardType
            };
            return tokenPayment;
        }

        void ConfigureJudoSDK ()
        {
            // setting up API token/secret 
            var configInstance = JudoConfiguration.Instance;


            //setting for Sandnox
            configInstance.Environment = JudoEnvironment.Live;
            Judo.UIMode = true;
            Judo.AmExAccepted = true;
            Judo.AVSEnabled = true;
            Judo.MaestroAccepted = true;
            Judo.RiskSignals = true;

            /*
            configInstance.ApiToken = "[Application ApiToken]"; //retrieve from JudoPortal
            configInstance.ApiSecret = "[Application ApiSecret]"; //retrieve from JudoPortal
            configInstance.JudoId = "[Judo ID]"; //Received when registering an account with Judo
            */


            if (configInstance.ApiToken == null) { 
                throw(new Exception ("Judo Configuration settings have not been set on the config Instance.i.e JudoID Token,Secret"));
            }
        }

        protected override void OnSaveInstanceState (Bundle outState)
        {

            if (!string.IsNullOrEmpty (cardToken)) {

                outState.PutString ("CARDTOKEN", cardToken);
                outState.PutString ("CONSUMERTOKEN", consumerToken);
                outState.PutString ("LASTFOUR", lastFour);
                outState.PutInt ("CARDTYPE", (int)cardType);

                // always call the base implementation!
                base.OnSaveInstanceState (outState);    
            }

        }

        void RestoreState (Bundle bundle)
        {

            cardToken = bundle.GetString ("CARDTOKEN", "");
            if (!string.IsNullOrEmpty (cardToken)) {
                consumerToken = bundle.GetString ("CONSUMERTOKEN", "");
                lastFour = bundle.GetString ("LASTFOUR", "");
                cardType = (CardType)bundle.GetInt ("CARDTYPE", (int)CardType.UNKNOWN);
            }

        }
    }
}

