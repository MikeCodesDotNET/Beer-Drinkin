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

            btnPay.Layer.CornerRadius = 4f;
            btnPay.Layer.BorderWidth = 0f;

            btnAdd.Layer.CornerRadius = 4f;
            btnAdd.Layer.BorderWidth = 0;

            btnRemove.Layer.CornerRadius = 4f;
            btnRemove.Layer.BorderWidth = 0;

        }

        public override void LayoutIfNeeded()
        {
            Animate(0.5, () => 
            {
                base.LayoutIfNeeded();
            });
        }

        partial void BtnPay_TouchUpInside(UIButton sender)
        {
            Pay();
        }

        partial void BtnAdd_TouchUpInside(UIButton sender)
        {
            AddBeer();
        }

        public UILabel Price
        {
            get
            {
                return lblPrice;
            }
            set
            {
                lblPrice = value;
                SetNeedsDisplay();
            }
        }

        public UILabel Quantity
        {
            get
            {
                return lblQuantity;
            }
            set
            {
                lblQuantity = value;
                SetNeedsDisplay();
            }
        }

        public UILabel Total
        {
            get
            {
                return lblTotal;
            }
            set
            {
                lblTotal = value;
                SetNeedsDisplay();
            }
        }


        public delegate void AddBeerHandler();
        public event AddBeerHandler AddBeer;

        public delegate void RemoveBeerHandler();
        public event RemoveBeerHandler RemoveBeer;
        public delegate void PayHandler();
        public event PayHandler Pay;

        partial void BtnRemove_TouchUpInside(UIButton sender)
        {
            RemoveBeer();
        }

	}
}
