using System;
using System.Threading.Tasks;
using BeerDrinkin.API;
using System.Collections.Generic;
using Xamarin;
using BeerDrinkin.Service.DataObjects;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using Geolocator.Plugin;
using System.Linq;

namespace BeerDrinkin.Core.ViewModels
{
    public class SearchViewModel
    {
        public ObservableCollection<BeerItem> Beers = new ObservableCollection<BeerItem>();

        public async Task SearchForBeersCommand(string searchTerm)
        {
            //Track what beers people are searching for.
            if (Helpers.Settings.UserTrackingEnabled)
                Insights.Track("Beer Database Searched", "Search term", searchTerm);

            APIResponse<List<BeerItem>> results = await Client.Instance.BeerDrinkinClient.SearchBeerAsync(searchTerm);

            Beers.Clear();

            if (results.Result.Count > 0)
            {
                var beers = results.Result.OrderBy(e => String.IsNullOrEmpty(e.Name)).ThenBy(e => string.IsNullOrEmpty(e.Brewery));

                foreach (var beer in beers)
                {
                    Beers.Add(beer);                  
                }  
                return;
            }
        }

        public async Task<bool> QuickCheckIn(BeerItem beer)
        {
            var checkin = new CheckInItem
            {
                Beer = beer,
                BeerId = beer.Id,
                CheckedInBy = Client.Instance.BeerDrinkinClient.GetUserId
            };

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            //Track the location of where the user consumed the beer
            if (position != null)
            {
                checkin.Longitude = position.Longitude;
                checkin.Latitude = position.Latitude;
            }

            var checkInResult = await Client.Instance.BeerDrinkinClient.CheckInBeerAsync(checkin);
            if (!checkInResult.HasError)
                return checkInResult.Result;

            UserDialogs.Instance.ShowError(checkInResult.ErrorMessage);
            return false;
        }
    }
}

