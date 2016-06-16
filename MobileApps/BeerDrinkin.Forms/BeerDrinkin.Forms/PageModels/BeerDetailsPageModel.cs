using BeerDrinkin.DataObjects;
using BeerDrinkin.Forms.Interfaces;
using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;

namespace BeerDrinkin.Forms.PageModels
{
    [ImplementPropertyChanged]
    internal class BeerDetailsPageModel : FreshBasePageModel
    {
        private readonly IBeerDrinkinClient _beerDrinkinClient;
        private Command _closeCommand;

        public Beer SelectedBeer { get; set; }

        public Command CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new Command(async () => await CoreMethods.PopPageModel(true))); }
        }

        public BeerDetailsPageModel(IBeerDrinkinClient breweryDbClient)
        {
            _beerDrinkinClient = breweryDbClient;
        }

        public override void Init(object initData)
        {
            var selectedBeer = initData as Beer;

            if (selectedBeer == null)
                return; // TODO Come on, you're nicer than this...

            SelectedBeer = selectedBeer;
        }
    }
}