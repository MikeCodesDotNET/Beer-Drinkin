using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Core.Abstractions.ViewModels
{
    public interface ITrendingBeersViewModel
    {
        Task<List<Beer>> FetchTrendingBeers(int takeCount = 10);
    }
}

