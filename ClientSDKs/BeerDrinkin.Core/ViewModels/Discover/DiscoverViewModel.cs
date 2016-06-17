using BeerDrinkin.AzureClient;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.Services.Abstractions;
using System.IO;
using BeerDrinkin.Core.Abstractions.ViewModels;

namespace BeerDrinkin.Core.ViewModels
{
    public class DiscoverViewModel : ViewModelBase, IDiscoverViewModel
    {
        IAzureClient azure;
        ISearchService searchService;
        ITrendsService trendsService;
        IBarcodeService barcodeService;
        IImageService imageService;
        public DiscoverViewModel()
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
                barcodeService = ServiceLocator.Instance.Resolve<IBarcodeService>();
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

        public async Task<List<Beer>> LookupBarcode(string upc)
        {
            Initialize();
            return await barcodeService.LookupBarcode(upc);
        }

        public async Task<List<Beer>> ImageLookup(Stream stream)
        {
            Initialize();
            return await imageService.LookupBeer(stream);
        }
    }
}
