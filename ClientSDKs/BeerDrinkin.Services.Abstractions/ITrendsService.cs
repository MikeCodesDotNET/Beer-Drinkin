using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Services.Abstractions
{
    public interface ITrendsService
    {
        Task<List<Beer>> TrendingBeers(int takeCount);
    }
}

