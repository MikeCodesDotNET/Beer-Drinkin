using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.AzureClient;
using BeerDrinkin.Core.Abstractions.ViewModels;
using BeerDrinkin.DataObjects;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Services.Abstractions;
using BeerDrinkin.Utils;

namespace BeerDrinkin.Core.ViewModels
{
    public class TrendingBeersViewModel : ViewModelBase, ITrendingBeersViewModel
    {
        IAzureClient azure;
        ITrendsService trendsService;

        public TrendingBeersViewModel()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
            trendsService = ServiceLocator.Instance.Resolve<ITrendsService>();
        }

        public async Task<List<Beer>> FetchTrendingBeers(int takeCount = 10)
        {
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            List<Beer> results;
            if (Utils.Helpers.Settings.LocationEnabled == false)
            {
                results = await trendsService.TrendingBeers(takeCount, 0, 0);
            }
            else
            {
                var position = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync();
                results = await trendsService.TrendingBeers(takeCount, position.Longitude, position.Latitude);
            }

            stopWatch.Stop();

            return results;
        }
    }
}

