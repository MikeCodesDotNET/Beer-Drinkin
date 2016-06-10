using BreweryDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerDrinkin.Forms.Interfaces
{
    internal interface IBreweryDbClient
    {
        Task<List<Beer>> SearchBeersAsync(string searchTerm);

        Task<Beer> GetBeerAsync(string beerId);
    }
}