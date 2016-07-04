using System;
using System.Threading.Tasks;
using BeerDrinkin.Core.Abstractions.Services;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;

namespace BeerDrinkin.Core.ViewModels
{
    public class BeerDescriptionViewModel
    {
        
        public BeerDescriptionViewModel(Beer beer)
        {
            Beer = beer;
            Name = beer.Name;
            BreweryName = beer?.Brewery?.Name;
            Description = beer.Description;
            if (beer.HasImages == true)
                ImageUrl = beer.Image.LargeUrl;


            SearchProvider = ServiceLocator.Instance.Resolve<IDeviceSearchProvider>();
            SearchProvider.AddBeerToIndex(beer); 
        }

        public IDeviceSearchProvider SearchProvider { get; private set;}
        public Beer Beer { get; set;}
        public string Name { get; set;}
        public double ABV { get; set;}
        public string BreweryName { get; set;}
        public int Average { get; set;}
        public int ReviewCount { get; set;}
        public string Description { get; set;}
        public string ImageUrl { get; set;}

        public string SharingMessage
        {
            get
            {
                return $"I've just read about {Beer.Name} with Beer Drinkin for iOS";
            }
        }

    }
}

