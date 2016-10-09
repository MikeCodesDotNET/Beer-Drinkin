using System;
using System.Threading.Tasks;
using BeerDrinkin.AzureClient;
using BeerDrinkin.Core.Abstractions.ViewModels;
using BeerDrinkin.Models;
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
        IUserStore userStore;

        IAzureClient azure;
        IAppInsights log;

        public CheckInViewModel()
        {
            checkInStore = ServiceLocator.Instance.Resolve<ICheckInStore>();
            userStore = ServiceLocator.Instance.Resolve<IUserStore>();

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
                    Beer = beer,
                    User = await userStore.GetCurrentUser(),
                    Longitude = location.Longitude,
                    Latitude = location.Latitude
                };

                var rating = new Rating
                {
                    User = await userStore.GetCurrentUser(),
                    Score = score,
                    CheckIn = checkIn
                };

                checkIn.Rating = rating;

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

