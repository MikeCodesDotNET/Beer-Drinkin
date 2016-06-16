using BeerDrinkin.DataObjects;
using BeerDrinkin.Forms.Interfaces;
using FreshMvvm;
using PropertyChanged;

namespace BeerDrinkin.Forms.PageModels
{
    [ImplementPropertyChanged]
    internal class BeerDetailsPageModel : FreshBasePageModel
    {
        private readonly IBeerDrinkinClient _breweryDbClient;

        public Beer SelectedBeer { get; set; }

        public BeerDetailsPageModel(IBeerDrinkinClient breweryDbClient)
        {
            _breweryDbClient = breweryDbClient;
        }

        public async override void Init(object initData)
        {
            //var selectedBeer = initData as Beer;

            //if (selectedBeer == null)
            //    return; // TODO Come on, you're nicer than this...

            //if (string.IsNullOrWhiteSpace(selectedBeer.BreweryDbId))
            //    return; // TODO No really, you can't do this!

            //var resultBeer = await _breweryDbClient.GetBeerAsync(selectedBeer.BreweryDbId);

            //// TODO probably do this in service to return our own type of Beer
            //SelectedBeer = new Beer
            //{
            //    Abv = resultBeer.Abv.ToString(),
            //    Brewery = resultBeer.Brewery,
            //    BreweryDbId = resultBeer.Id,
            //    BreweryId = resultBeer.Breweries.FirstOrDefault()?.Id,
            //    Description = resultBeer.Description,
            //    ImageLarge = resultBeer.Labels?.Large,
            //    ImageMedium = resultBeer.Labels?.Medium,
            //    ImageSmall = resultBeer.Labels?.Icon,
            //    Name = resultBeer.Name
            //};
        }
    }
}