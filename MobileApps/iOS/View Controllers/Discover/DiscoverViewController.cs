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
using BeerDrinkin.Core.Abstractions.ViewModels;

namespace BeerDrinkin.iOS
{
    public partial class DiscoverViewController : BaseViewController
    {
        const string segueIdentifier = "BEER_DESCRIPTION_SEGUE";
        const string beerDescriptionIdentifier = "BEER_DESCRIPTION_IDENTIFIER";
        const string cellIdentifier = "SEARCH_RESULT_CELL";

        readonly IDiscoverViewModel viewModel;

        List<Beer> searchResults;
        DiscoverBeerSearchResultsSource source;

        ScrollingTabView tabView;

        ILogService logger;
        public Beer SelectedBeer { get; private set;}

        public DiscoverViewController (IntPtr handle) : base (handle)
        {
            Initialize();

            viewModel = ServiceLocator.Instance.Resolve<IDiscoverViewModel>();
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

            var discoverBeers = Storyboard.InstantiateViewController("DiscoverBeers") as DiscoverBeersViewController;
            discoverBeers.Title = "Beers";
            discoverBeers.DidSelectBeer += BeerSelected;
            discoverBeers.PictureImport += PictureImport;

            var discoverBreweries = Storyboard.InstantiateViewController("DiscoverBreweries");
            discoverBreweries.Title = "Breweries";

            var list = new List<UIViewController>();
            list.Add(discoverBeers);
            list.Add(discoverBreweries);

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
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

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
                logger.Report(ex, "DiscoverViewController", "Search");
            }
            finally
            {
                stopWatch.Stop();

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

        void PictureImport()
        {
            if (!UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
                return;

            var imagePicker = new UIImagePickerController();
            imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
            PresentViewController(imagePicker, true, null);
            imagePicker.Canceled += async delegate
            {
                await imagePicker.DismissViewControllerAsync(true);
            };

            imagePicker.FinishedPickingMedia += async (object s, UIImagePickerMediaPickedEventArgs e) =>
            {
                try
                {
                    await imagePicker.DismissViewControllerAsync(true);

                    var image = e.OriginalImage;
                    Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Uploading photo");

                    var stream = ScaledImage(image, 500, 500).AsPNG().AsStream();
                    await viewModel.LookupImage(stream);
                    Acr.UserDialogs.UserDialogs.Instance.HideLoading();

                }
                catch (Exception ex)
                {
                    Acr.UserDialogs.UserDialogs.Instance.ShowError(ex.Message);
                }
            };
        }

        UIImage ScaledImage(UIImage image, nfloat maxWidth, nfloat maxHeight)
        {
            var maxResizeFactor = Math.Min(maxWidth / image.Size.Width, maxHeight / image.Size.Height);
            var width = maxResizeFactor * image.Size.Width;
            var height = maxResizeFactor * image.Size.Height;
            return image.Scale(new CoreGraphics.CGSize(width, height));
        }

    }
}