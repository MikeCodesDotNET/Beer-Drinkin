using System;
using System.Threading.Tasks;

using MikeCodesDotNET.iOS;

using BeerDrinkin.Core.ViewModels;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;

using UIKit;
using Foundation;
using System.Collections.Generic;
using BeerDrinkin.Services.Abstractions;
using BeerDrinkin.iOS.CustomControls;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverViewController : BaseViewController
    {
        const string segueIdentifier = "BEER_DESCRIPTION_SEGUE";
        const string beerDescriptionIdentifier = "BEER_DESCRIPTION_IDENTIFIER";
        const string cellIdentifier = "SEARCH_RESULT_CELL";

        readonly DiscoverViewModel viewModel = new DiscoverViewModel();

        List<Beer> searchResults;
        DiscoverBeerSearchResultsSource source;

        ScrollingTabView tabView;

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
            searchBar.ShowsCancelButton = false;
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

            tabView = new ScrollingTabView(list);
            tabView.Frame = new CoreGraphics.CGRect(0, 64, View.Bounds.Width, View.Bounds.Height);
            tabView.SelectionChanged += (index, title) =>
            {
                searchBar.Placeholder = $"Search {title}";
            };

            View.AddSubview(tabView);
        }

        void ConfigureEvents()
        {
            searchBar.OnEditingStarted += StartEditing;
            searchBar.CancelButtonClicked += EndEditing;
            searchBar.OnEditingStopped += HideKeyboard;

            searchBar.SearchButtonClicked += HideKeyboard;;
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
                source = new DiscoverBeerSearchResultsSource(searchResults);
                source.DidSelectBeer += BeerSelected;

                beerResultsTable.Source = source;
                beerResultsTable.ReloadData();
                View.BringSubviewToFront(beerResultsTable);
            }
            catch (Exception ex)
            { 
                logger.Report(ex);
            }
        }

        void StartEditing(object sender, EventArgs e)
        {
            searchBar.ShowsCancelButton = true;
            placeholderBackgroundView.BackgroundColor = UIColor.White;
            View.BringSubviewToFront(placeholderBackgroundView);
        }

        void EndEditing(object sender, EventArgs e)
        {
            searchBar.ShowsCancelButton = false;
            searchBar.Text = "";
            searchBar.ResignFirstResponder();
            View.SendSubviewToBack(beerResultsTable);
            View.SendSubviewToBack(placeholderBackgroundView);
        }

        void HideKeyboard(object sender, EventArgs e)
        {
            searchBar.ResignFirstResponder();
        }

        async void BeerSelected(Beer beer)
        {
            var vc = Storyboard.InstantiateViewController("BEER_DESCRIPTION") as BeerDescriptionTableView;
            vc.SetBeer(beer);
            await PresentViewControllerAsync(vc, true);
        }
    }
}