using System;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Core.Abstractions.ViewModels
{
    public interface ICheckInViewModel
    {
        Task CheckInBeer(Beer beer, int rating);

        string BeerName { get; set;}
        double? ABV { get; set;}
    }
}

