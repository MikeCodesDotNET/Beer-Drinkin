using System;
using System.Threading.Tasks;

using MikeCodesDotNET.iOS;

using BeerDrinkin.Core.ViewModels;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;
using BeerDrinkin.Utils.Interfaces;

using UIKit;
using Foundation;
using System.Collections.Generic;
using SDWebImage;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverViewController : BaseViewController
    {
        const string segueIdentifier = "BEER_DESCRIPTION_SEGUE";
        const string beerDescriptionIdentifier = "BEER_DESCRIPTION_IDENTIFIER";
        const string cellIdentifier = "SEARCH_RESULT_CELL";

        readonly SearchViewModel viewModel = new SearchViewModel();
        List<Beer> searchResults;
        List<Beer> trendingBeers;

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

        public async override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            await PopulateTrendingSearches();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier != segueIdentifier)
                return;

            var beerDescriptoinViewController = segue.DestinationViewController as BeerDescriptionTableView;
            if (beerDescriptoinViewController == null)
                return;

            beerDescriptoinViewController.EnableCheckIn = true;
            beerDescriptoinViewController.SetBeer(SelectedBeer);
            SelectedBeer = null;
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

                searchResults = await viewModel.Search(searchTerm);
                SearchResultsTable.ReloadData();
            }
            catch (Exception ex)
            { 
                logger.Report(ex);
            }
        }

        async Task PopulateTrendingSearches()
        {
            var trends = await viewModel.TrendingBeers(10);

        }
    }
}