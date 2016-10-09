using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.Models;

namespace BeerDrinkin.Core.Abstractions.ViewModels
{
    public interface IBeersViewModel
    {
        Task<List<Beer>> FetchBeers(); 
    }
}

