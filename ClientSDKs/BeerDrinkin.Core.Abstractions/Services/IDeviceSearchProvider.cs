using System;
using BeerDrinkin.Models;

namespace BeerDrinkin.Core.Abstractions.Services
{
    public interface IDeviceSearchProvider
    {
        void AddBeerToIndex(Beer beer);
    }
}

