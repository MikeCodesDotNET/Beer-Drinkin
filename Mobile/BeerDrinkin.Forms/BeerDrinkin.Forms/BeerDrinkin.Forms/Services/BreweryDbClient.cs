using BeerDrinkin.Forms.Helpers;
using BeerDrinkin.Forms.Interfaces;
using BreweryDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerDrinkin.Forms.Services
{
    internal class BreweryDbClient : IBreweryDbClient
    {
        private readonly BreweryDB.BreweryDbClient _breweryDbClient;

        public BreweryDbClient()
        {
            _breweryDbClient = new BreweryDB.BreweryDbClient(Keys.BreweryDbKey);
        }

        public async Task<List<Beer>> SearchBeersAsync(string searchTerm)
        {
            return (await _breweryDbClient.Beers.Search(searchTerm)).Data;
        }

        public async Task<Beer> GetBeerAsync(string beerId)
        {
            return (await _breweryDbClient.Beers.Get(beerId)).Data;
        }
    }
}