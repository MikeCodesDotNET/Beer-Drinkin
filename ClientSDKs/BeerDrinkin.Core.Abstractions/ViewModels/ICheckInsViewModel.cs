using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Core.Abstractions.ViewModels
{
    public interface ICheckInsViewModel
    {
        Task<List<CheckIn>> CheckIns(string userI);
    }
}

