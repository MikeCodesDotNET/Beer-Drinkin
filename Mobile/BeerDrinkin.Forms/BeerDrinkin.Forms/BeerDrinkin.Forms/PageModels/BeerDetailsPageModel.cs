using BeerDrinkin.Forms.Interfaces;
using BeerDrinkin.Forms.Models;
using FreshMvvm;
using PropertyChanged;
using System.Linq;

namespace BeerDrinkin.Forms.PageModels
{
    [ImplementPropertyChanged]
    internal class BeerDetailsPageModel : FreshBasePageModel
    {
        private readonly IBreweryDbClient _breweryDbClient;

        public Beer SelectedBeer { get; set; }

        public BeerDetailsPageModel(IBreweryDbClient breweryDbClient)
        {
            _breweryDbClient = breweryDbClient;
        }

        public async override void Init(object initData)
        {
            var selectedBeer = initData as Beer;

            if (selectedBeer == null)
                return; // TODO Come on, you're nicer than this...

            if (string.IsNullOrWhiteSpace(selectedBeer.BreweryDbId))
                return; // TODO No really, you can't do this!

            var resultBeer = await _breweryDbClient.GetBeerAsync(selectedBeer.BreweryDbId);

            // TODO probably do this in service to return our own type of Beer
            SelectedBeer = new Beer
            {
                Abv = resultBeer.Abv.ToString(),
                Brewery = resultBeer.Brewery,
                BreweryDbId = resultBeer.Id,
                BreweryId = resultBeer.Breweries.FirstOrDefault()?.Id,
                Description = resultBeer.Description,
                ImageLarge = resultBeer.Labels?.Large,
                ImageMedium = resultBeer.Labels?.Medium,
                ImageSmall = resultBeer.Labels?.Icon,
                Name = resultBeer.Name
            };
        }
    }
}