using System.Threading.Tasks;
using BeerDrinkin.Core.Abstractions.Services;
using BeerDrinkin.Models;
using BeerDrinkin.Utils;
using BeerDrinkin.DataStore.Abstractions;

namespace BeerDrinkin.Core.ViewModels
{
    public class BeerDescriptionViewModel
    {
        public IDeviceSearchProvider SearchProvider { get; private set; }
        public IBreweryStore BreweryStore { get; private set; }
        public IRatingStore RatingStore { get; private set; }
        
        public BeerDescriptionViewModel(Beer beer)
        {
            BreweryStore = ServiceLocator.Instance.Resolve<IBreweryStore>();
            RatingStore = ServiceLocator.Instance.Resolve<IRatingStore>();
            SearchProvider = ServiceLocator.Instance.Resolve<IDeviceSearchProvider>();
            
            Beer = beer;
            SearchProvider.AddBeerToIndex(beer); 
        }

        public async Task Refresh()
        {
            var brewery = await BreweryStore.GetItemAsync(Beer.BreweryId);
            BreweryName = brewery.Name;

            Name = Beer.Name;
            Description = Beer.Description;
        }
        
        public Beer Beer { get; private set;}
        public string Name { get; private set;}
        public double ABV { get; private set;}
        public string BreweryName { get; private set;}
        public int AverageRating { get; private set;}
        public string Description { get; private set;}
    
        public string SharingMessage
        {
            get
            {
                return $"I've just read about {Beer.Name} with Beer Drinkin for iOS";
            }
        }
    }
}

