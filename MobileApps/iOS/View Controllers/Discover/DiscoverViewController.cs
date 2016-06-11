using System;
using System.Threading.Tasks;

using MikeCodesDotNET.iOS;

using BeerDrinkin.Core.ViewModels;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;

using UIKit;
using Foundation;
using System.Collections.Generic;
using SDWebImage;
using BeerDrinkin.Services.Abstractions;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverViewController : BaseViewController
    {
        const string segueIdentifier = "BEER_DESCRIPTION_SEGUE";
        const string beerDescriptionIdentifier = "BEER_DESCRIPTION_IDENTIFIER";
        const string cellIdentifier = "SEARCH_RESULT_CELL";

        readonly DiscoverViewModel viewModel = new DiscoverViewModel();
        List<Beer> searchResults;
        List<Beer> trendingBeers;

        ILogService logger;

        public Beer SelectedBeer { get; private set;}

        public DiscoverViewController (IntPtr handle) : base (handle)
        {
            logger = ServiceLocator.Instance.Resolve<ILogService>();
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
            searchBar.Layer.BorderWidth = 0;
            searchBar.Layer.CornerRadius = 2;
            searchBar.Layer.MasksToBounds = true;
            searchBar.Layer.BorderColor = "15A9FE".ToUIColor().CGColor;

            var discoverBeers = Storyboard.InstantiateViewController("DiscoverBeers");
            var discoverBreweries = Storyboard.InstantiateViewController("DiscoverBreweries");
            var discoverUsers = Storyboard.InstantiateViewController("DiscoverUsers");

            discoverBeers.View.Frame = View.Bounds;
            scrollView.AddSubview(discoverBeers.View);
            scrollView.AddSubview(discoverBreweries.View);
            scrollView.AddSubview(discoverUsers.View);
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
                //SearchResultsTable.ReloadData();
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

        partial void BtnBeer_TouchUpInside(UIButton sender)
        {
            searchBar.Placeholder = "Search for beers";
            btnBeer.SetTitleColor(UIColor.White, UIControlState.Normal);
            btnBreweries.SetTitleColor("0868B6".ToUIColor(), UIControlState.Normal);
            btnUsers.SetTitleColor("0868B6".ToUIColor(), UIControlState.Normal);
        }

        partial void BtnBreweries_TouchUpInside(UIButton sender)
        {
            searchBar.Placeholder = "Search for breweries";
            btnBeer.SetTitleColor("0868B6".ToUIColor(), UIControlState.Normal);
            btnBreweries.SetTitleColor(UIColor.White, UIControlState.Normal);
            btnUsers.SetTitleColor("0868B6".ToUIColor(), UIControlState.Normal);
        }

        partial void BtnUsers_TouchUpInside(UIButton sender)
        {
            searchBar.Placeholder = "Search for users";
            btnBeer.SetTitleColor("0868B6".ToUIColor(), UIControlState.Normal);
            btnBreweries.SetTitleColor("0868B6".ToUIColor(), UIControlState.Normal);
            btnUsers.SetTitleColor(UIColor.White, UIControlState.Normal);
        }
    }
}