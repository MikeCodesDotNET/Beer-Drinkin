using BeerDrinkin.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerDrinkin.Forms.Interfaces
{
    internal interface IBeerDrinkinClient
    {
        Task<List<Beer>> GetDiscoverBeersAsync();

        Task<List<Beer>> SearchBeersAsync(string searchTerm);
    }
}