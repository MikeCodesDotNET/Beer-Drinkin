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
using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.iOS
{
    public partial class RateBeerViewController : UIViewController
    {
        public RateBeerViewController (IntPtr handle) : base (handle)
        {
        }

		BeerItem beer;
		public BeerItem SelectedBeer
		{
			get
			{
				return beer;
			}
			set
			{
				beer = value;
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			btnCheckIn.TouchUpInside += async delegate
			{
				Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Checking in");
				var checkIn = new CheckInItem();
	
				await Client.Instance.BeerDrinkinClient.CheckInBeerAsync(checkIn);
				Acr.UserDialogs.UserDialogs.Instance.HideLoading();
			};
		}
    }
}