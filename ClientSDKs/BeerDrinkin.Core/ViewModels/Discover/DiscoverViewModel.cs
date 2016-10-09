using BeerDrinkin.AzureClient;
using BeerDrinkin.Models;
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
        IBarcodeService barcodeService;
        IImageService imageService;

        public DiscoverViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (azure != null && searchService != null) return;

            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
            searchService = ServiceLocator.Instance.Resolve<ISearchService>();
            barcodeService = ServiceLocator.Instance.Resolve<IBarcodeService>();
        }

        public async Task<List<Beer>> Search(string searchTerm)
        {
            Initialize();
            return await searchService.Search(searchTerm);
        }

        public async Task<List<Beer>> LookupBarcode(string upc)
        {
            Initialize();
            return await barcodeService.LookupBarcode(upc);
        }

        public async Task<List<Beer>> LookupImage(Stream stream)
        {
            Initialize();
            return await imageService.LookupBeer(stream);
        }
    }
}
