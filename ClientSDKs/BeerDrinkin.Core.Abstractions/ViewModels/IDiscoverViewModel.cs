using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BeerDrinkin.DataObjects;
using System.IO;

namespace BeerDrinkin.Core.Abstractions.ViewModels
{
    public interface IDiscoverViewModel
    {
        Task<List<Beer>> Search(string searchTerm);

        Task<List<Beer>> FetchTrendingBeers(int takecount);

        Task<List<Beer>> LookupBarcode(string upc);

        Task<List<Beer>> LookupImage(Stream stream);
    }
}

