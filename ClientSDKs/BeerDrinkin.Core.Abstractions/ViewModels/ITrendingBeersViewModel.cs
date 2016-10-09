using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.Models;

namespace BeerDrinkin.Core.Abstractions.ViewModels
{
    public interface ITrendingBeersViewModel
    {
        Task<List<Beer>> FetchTrendingBeers(int takeCount = 10);
    }
}

