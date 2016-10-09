using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BeerDrinkin.Models;

namespace BeerDrinkin.Core.Abstractions.ViewModels
{
    public interface ICheckInsViewModel
    {
        Task<List<CheckIn>> FetchCheckIns(string userId);
    }
}

