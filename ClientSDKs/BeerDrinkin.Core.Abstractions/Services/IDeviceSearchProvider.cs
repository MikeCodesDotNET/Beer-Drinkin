using System;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Core.Abstractions.Services
{
    public interface IDeviceSearchProvider
    {
        void AddBeerToIndex(Beer beer);
    }
}

