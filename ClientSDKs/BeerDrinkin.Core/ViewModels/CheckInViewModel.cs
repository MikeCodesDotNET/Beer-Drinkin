using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerDrinkin.AzureClient;
using BeerDrinkin.Core.Abstractions.ViewModels;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Services.Abstractions;
using BeerDrinkin.Utils;
using Plugin.Geolocator;

namespace BeerDrinkin.Core.ViewModels
{
    public class CheckInViewModel : ViewModelBase, ICheckInViewModel
    {
        ICheckInStore checkInStore;
        IRatingStore ratingStore;

        IAzureClient azure;
        IAppInsights log;

        public CheckInViewModel()
        {
            checkInStore = ServiceLocator.Instance.Resolve<ICheckInStore>();
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
            log = ServiceLocator.Instance.Resolve<IAppInsights>();          
        }

        public async Task CheckInBeer(Beer beer, int score)
        {
            try
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Saving checkin");
                var location = await CrossGeolocator.Current.GetPositionAsync();
                var checkIn = new CheckIn
                {
                    BeerId = beer.Id,
                    UserId = azure.Client.CurrentUser.UserId,
                    Longitude = location.Longitude,
                    Latitude = location.Latitude
                };

                var rating = new Rating
                {
                    UserId = azure.Client.CurrentUser.UserId,
                    Score = score,
                    CheckIn = checkIn
                };

                checkIn.RatingId = rating.Id;

                await checkInStore.InsertAsync(checkIn);
                await ratingStore.InsertAsync(rating);

                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                log.Report(ex);
            }
        }

        public string BeerName { get; set;}
        public double? ABV { get; set;}

    }
}

