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
using BeerDrinkin.iOS.CustomControls;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverViewController : BaseViewController
    {
        const string segueIdentifier = "BEER_DESCRIPTION_SEGUE";
        const string beerDescriptionIdentifier = "BEER_DESCRIPTION_IDENTIFIER";
        const string cellIdentifier = "SEARCH_RESULT_CELL";

        ScrollingTabView tabView;
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
            discoverBeers.Title = "Beers";

            var discoverBreweries = Storyboard.InstantiateViewController("DiscoverBreweries");
            discoverBreweries.Title = "Breweries";

            var discoverUsers = Storyboard.InstantiateViewController("DiscoverUsers");
            discoverUsers.Title = "Users";

            var list = new List<UIViewController>();
            list.Add(discoverBeers);
            list.Add(discoverBreweries);
            list.Add(discoverUsers);

            tabView = new CustomControls.ScrollingTabView(list);
            tabView.Frame = new CoreGraphics.CGRect(0, 64, View.Bounds.Width, View.Bounds.Height);
            tabView.SelectionChanged += (index, title) =>
            {
                searchBar.Placeholder = $"Search {title}";
            };

            View.AddSubview(tabView);

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
    }
}