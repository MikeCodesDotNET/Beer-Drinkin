using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

using JudoDotNetXamariniOSSDK;
using JudoPayDotNet.Models;
using JudoDotNetXamarin;
using BeerDrinkin.Service.DataObjects;
using Awesomizer;

namespace BeerDrinkin.iOS
{
	partial class PurchaseTableViewCell : UITableViewCell
	{
        private ClientService clientService;

        public PurchaseTableViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public PurchaseTableViewCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            clientService = new ClientService();

            if (!clientService.ApplePayAvailable)
            {
                btnApplePay.Enabled = false;
                btnApplePay.Hidden = true;
            }

            btnBuyNow.Layer.CornerRadius = 4f;
            btnBuyNow.Layer.BorderWidth = 0f;

            btnBuyNow.TouchUpInside += delegate
            {
                BuyNow();
            };

            btnApplePay.TouchUpInside += delegate
            {
                ApplePay();
            };

            stepper.MinimumValue = 0;
            stepper.MaximumValue = 250;
            stepper.ValueChanged += delegate
            {
                Quantity = stepper.Value;
                Total = (price * Quantity).ToString();
            };

            Total = (price * Quantity).ToString();
        }

        public override void LayoutIfNeeded()
        {
            Animate(0.5, () => 
            {
                base.LayoutIfNeeded();
            });
        }
       
        double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public double Quantity
        {
            get
            {
                return stepper.Value;
            }
            set
            {
                lblQuantity.Text = $"Quantity: {value}";
                SetNeedsDisplay();
            }
        }

        public string Total
        {
            get
            {
                return lblTotal.Text;
            }
            set
            {
                lblTotal.Text = $"Total: £{value}";
                SetNeedsDisplay();
            }
        }
            


        public delegate void AddBeerHandler();
        public event AddBeerHandler AddBeer;

        public delegate void RemoveBeerHandler();
        public event RemoveBeerHandler RemoveBeer;

        public delegate void BuyNowHandler();
        public event BuyNowHandler BuyNow;

        public delegate void ApplePayHandler();
        public event ApplePayHandler ApplePay;



	}
}
