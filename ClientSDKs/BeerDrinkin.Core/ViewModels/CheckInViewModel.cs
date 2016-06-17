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
        IAzureClient azure;
        ILogService log;

        public CheckInViewModel()
        {
            checkInStore = ServiceLocator.Instance.Resolve<ICheckInStore>();
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
            log = ServiceLocator.Instance.Resolve<ILogService>();          
        }

        public async Task CheckInBeer(Beer beer, Rating rating, bool isBottled)
        {
            try
            {
                var location = await CrossGeolocator.Current.GetPositionAsync();
                var checkIn = new CheckIn
                {
                    BeerId = beer.Id,
                    UserId = azure.Client.CurrentUser.UserId,
                    Rating = rating,
                    IsBottled = isBottled,
                    Longitude = location.Longitude,
                    Latitude = location.Latitude
                };

                await checkInStore.InsertAsync(checkIn);
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

