using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using BeerDrinkin.API;
using BeerDrinkin.Service.DataObjects;

using Xamarin;

using Acr.UserDialogs;
using Plugin.Geolocator;
using Plugin.Connectivity;

namespace BeerDrinkin.Core.ViewModels
{
    public class SearchViewModel
    {
        public ObservableCollection<BeerItem> Beers = new ObservableCollection<BeerItem>();

        public async Task SearchForBeersCommand(string searchTerm)
        {

            var isConnected = await CrossConnectivity.Current.IsReachable("google.com", 1000);
            if(!isConnected)
            {
                //We're not connected to the internet so we need to search the current beers table instead. 
                //var beers = Client.Instance.BeerDrinkinClient.SearchCacheAsync(searchTerm);

            }
          

            //Track what beers people are searching for.
            if (Helpers.Settings.UserTrackingEnabled)
                Insights.Track("Beer Database Searched", "Search term", searchTerm);

            APIResponse<List<BeerItem>> results = await Client.Instance.BeerDrinkinClient.SearchBeerAsync(searchTerm);

            Beers.Clear();

            if (results.Result.Count > 0)
            {          
                foreach (var beer in results.Result)
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

