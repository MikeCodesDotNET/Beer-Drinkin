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
        }

        public override void LayoutIfNeeded()
        {
            Animate(0.5, () => 
            {
                base.LayoutIfNeeded();
            });
        }
       
        decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                lblPrice.Text = $"Price: £{price}";
            }
        }

        public string DistributorName
        {
            get
            {
                return lblDistributorName.Text;
            }
            set
            {
                lblDistributorName.Text = value;
                SetNeedsDisplay();
            }
        }

        public string TagLine
        {
            get
            {
                return lblTagLine.Text;
            }
            set
            {
                lblTagLine.Text = value;
            }
        }

        int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                lblQuantity.Text = quantity.ToString();
                SetNeedsDisplay();
            }
        }

        public delegate void AddBeerHandler();
        public event AddBeerHandler AddBeer;

        public delegate void RemoveBeerHandler();
        public event RemoveBeerHandler RemoveBeer;
	}
}
