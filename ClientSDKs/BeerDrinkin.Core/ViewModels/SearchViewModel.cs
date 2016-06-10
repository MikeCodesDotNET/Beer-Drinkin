using BeerDrinkin.AzureClient;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.DataStore.Abstractions;

namespace BeerDrinkin.Core.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        IAzureClient azure;
        ISearchService searchService;
        ITrendsService trendsService;

        public SearchViewModel()
        {
            Initialize();
        }

        void Initialize()
        {
            if (azure == null || searchService == null || trendsService == null)
            {
                azure = ServiceLocator.Instance.Resolve<IAzureClient>();
                searchService = ServiceLocator.Instance.Resolve<ISearchService>();
                trendsService = ServiceLocator.Instance.Resolve<ITrendsService>();
            }
        }

        public async Task<List<Beer>> Search(string searchTerm)
        {
            Initialize();
            return await searchService.Search(searchTerm);
        }

        public async Task<List<Beer>> TrendingBeers(int takeCount = 10)
        {
            Initialize();
            return await trendsService.TrendingBeers(takeCount);
        }
    }
}
