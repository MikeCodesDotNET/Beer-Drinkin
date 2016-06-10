using System;
using System.Threading.Tasks;

using MikeCodesDotNET.iOS;

using BeerDrinkin.Core.ViewModels;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;
using BeerDrinkin.Utils.Interfaces;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverViewController : BaseViewController
    {
        readonly SearchViewModel viewModel = new SearchViewModel();
        ILogger logger;

        public Beer SelectedBeer { get; private set;}

        public DiscoverViewController (IntPtr handle) : base (handle)
        {
            logger = ServiceLocator.Instance.Resolve<ILogger>();
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            await ValidateUserAuth();
            ConfigureUserInterface();
            ConfigureEvents();
        }

        async Task ValidateUserAuth()
        {
            if (string.IsNullOrEmpty(Utils.Helpers.Settings.UserId))
            {
                var vc = Storyboard.InstantiateViewController("SOCIAL_AUTH");
                await PresentViewControllerAsync(vc, false);
            }
        }

        void ConfigureUserInterface()
        {
            searchBar.Layer.BorderWidth = 1;
            searchBar.Layer.BorderColor = "15A9FE".ToUIColor().CGColor;
        }

        void ConfigureEvents()
        {
            searchBar.TextChanged += async (sender, e) => await Search(searchBar.Text);
            searchBar.SearchButtonClicked += async (sender, e) => await Search(searchBar.Text);
        }

        async Task Search(string searchTerm)
        { 
            try
            {
                if (string.IsNullOrEmpty(searchBar.Text) || searchBar.Text.Length < 2)
                    return;

                var beers = await viewModel.Search(searchTerm);
                SearchResultsTable.Source = new SearchDataSource(beers);
                SearchResultsTable.ReloadData();
            }
            catch (Exception ex)
            {
                logger.Report(ex);
            }
        }
    }
}