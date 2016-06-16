using BeerDrinkin.Core.ViewModels;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Forms.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerDrinkin.Forms.Services
{
    internal class BeerDrinkinClient : IBeerDrinkinClient
    {
        private readonly DiscoverViewModel vm = new DiscoverViewModel();

        public async Task<List<Beer>> GetDiscoverBeersAsync()
        {
            return await vm.TrendingBeers();
        }

        public async Task<List<Beer>> SearchBeersAsync(string searchTerm)
        {
            return await vm.Search(searchTerm);
        }
    }
}