using System;
using System.Collections.Generic;

using Foundation;
using UIKit;

using BeerDrinkin.Core.ViewModels;
using BeerDrinkin.Core.Services;

using Acr.UserDialogs;
using Awesomizer;
using Xamarin;
using System.Threading.Tasks;

using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using BeerDrinkin.iOS.DataSources;
using BeerDrinkin.Service.DataObjects;
using System.Linq;

namespace BeerDrinkin.iOS
{
    public partial class SearchViewController : BaseViewController
    {
        #region Fields
        private readonly SearchViewModel viewModel = new SearchViewModel();
        private BarcodeLookupService barcodeLookupService = new BarcodeLookupService();
        private SearchServiceClient serviceClient = new SearchServiceClient("beerdrinkin", new SearchCredentials(Core.Helpers.Keys.AzureSearchKey));
        private SearchIndexClient indexClient;
        private BeerItem selectedBeer;
        #endregion

        #region Constructor
        public SearchViewController(IntPtr handle) : base(handle)
        {
        }

        #endregion

        #region Overrides
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DismissKeyboardOnBackgroundTap();

            SetupUI();
            SetupEvents(); 

            if (TraitCollection.ForceTouchCapability == UIForceTouchCapability.Available)
                RegisterForPreviewingWithDelegate(new PreviewingDelegates.BeerDescriptionPreviewingDelegate(this), View);           
        }
       
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {            
            if (segue.Identifier != "beerDescriptionSegue")
                return;
            /*
            var index = placeHolderTableView.IndexPathForSelectedRow.Row;
            selectedBeer = selectedBeer ?? viewModel.Beers[index];
*/
            selectedBeer.Upc = barcodeLookupService.UPC;
            selectedBeer.RateBeerId = barcodeLookupService.RateBeerID;

            var beerDescriptoinViewController = segue.DestinationViewController as BeerDescriptionTableView;
            if (beerDescriptoinViewController == null)
                return;

            beerDescriptoinViewController.EnableCheckIn = true;
            beerDescriptoinViewController.SetBeer(selectedBeer);

            selectedBeer = null;
        }


        #endregion

        private void SetupUI() 
        {
            Title = BeerDrinkin.Core.Helpers.Strings.Search_Title;
            searchBar.Layer.BorderWidth = 1;
            searchBar.Layer.BorderColor = "15A9FE".ToUIColor().CGColor;

            serviceClient = new SearchServiceClient("beerdrinkin", new SearchCredentials(Core.Helpers.Keys.AzureSearchKey));
            indexClient = serviceClient.Indexes.GetClient("beers");

            View.AddSubview(suggestionsTableView);

            var dataSource = new SearchPlaceholderDataSource(this);
            placeHolderTableView.Source = dataSource;
            placeHolderTableView.ReloadData();
            placeHolderTableView.BackgroundColor = "F7F7F7".ToUIColor();
            placeHolderTableView.ContentInset = new UIEdgeInsets(10, 0, 0, 0);
            placeHolderTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            placeHolderTableView.ScrollsToTop = true;

            searchResultsTableView.ScrollsToTop = true;

            View.BringSubviewToFront(placeHolderTableView);

            searchBar.TextChanged += async delegate
            {
                 
                var connected = await Plugin.Connectivity.CrossConnectivity.Current.IsReachable("google.com", 1000);
                if(!connected)
                    return;

                if(searchBar.Text != "")
                {
                    View.BringSubviewToFront(suggestionsTableView);

                    var suggestParameters = new SuggestParameters();
                    suggestParameters.UseFuzzyMatching = true;
                    suggestParameters.Top = 25;
                    suggestParameters.HighlightPreTag = "[";
                    suggestParameters.HighlightPostTag = "]";
                    suggestParameters.MinimumCoverage = 100;
                                               
                    var response = await indexClient.Documents.SuggestAsync<Models.IndexedBeer>(searchBar.Text, "nameSuggester", suggestParameters);                    
                    var results = new List<string>();
                    foreach(var r in response.Results)
                    {
                        results.Add(r.Text);
                    }

                    var suggestionSource = new SearchSuggestionDataSource(results); 
                    suggestionSource.SelectedRow += (int index) =>
                    {
                        searchBar.Text = response.Results[index].Document.Name;
                        SearchForBeers(this, null);
                    };
                    suggestionsTableView.Source = suggestionSource;
                    suggestionsTableView.ReloadData();
                }
                else
                {
                    View.BringSubviewToFront(placeHolderTableView);
                }
            };

        }

        private void SetupEvents()
        {
            
           // searchBar.TextChanged += SearchBarTextChanged;           

            searchBar.SearchButtonClicked += SearchForBeers;

           // searchBar.BarcodeButtonClicked += async () => await ScanBarcode();

            viewModel.Beers.CollectionChanged += delegate
            {
                UserDialogs.Instance.HideLoading();
                searchBar.ResignFirstResponder();
            };
            
        }
            
        private async Task ScanBarcode()
        {
           try
            {
                var barcodeScanner = new ZXing.Mobile.MobileBarcodeScanner(this);
                var barcodeResult =  await barcodeScanner.Scan();

                if(string.IsNullOrEmpty(barcodeResult.Text))
                    return;

                var Beers = await barcodeLookupService.SearchForBeer(barcodeResult.Text);
                if(Beers != null)
                {
                }
            }
            catch (Exception ex)
            {
                Insights.Report(ex);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private void DisplayBeers(List<BeerItem> beers)
        {
            DataSource = new SearchDataSource(beers);
            DataSource.DidSelectBeer += delegate
            {
                PerformSegue("beerDescriptionSegue", this);
                    placeHolderTableView.DeselectRow(placeHolderTableView.IndexPathForSelectedRow, true);
            };

            placeHolderTableView.Source = DataSource;
            placeHolderTableView.ReloadData();

            View.BringSubviewToFront(placeHolderTableView);
            UserDialogs.Instance.HideLoading();
        }

        #region UI Control Event Handlers
        private void SearchBarTextChanged(object sender, UISearchBarTextChangedEventArgs uiSearchBarTextChangedEventArgs)
        {
            /*
            if (!string.IsNullOrEmpty(searchBar.Text))
                return;

            //Send table view to back and clear it.
            View.SendSubviewToBack(tableView);
            tableView.Source = new SearchDataSource(new List<BeerItem>());
            tableView.ReloadData();

            */
        }

        private async void SearchForBeers (object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Searching");
            var response = await indexClient.Documents.SearchAsync<Models.IndexedBeer>(searchBar.Text);             
            var beers = new List<BeerItem>();
            foreach(var result in response.Results)
            {
                var beerResult = result.Document; 
                if (beerResult != null)
                {
                    var beer = new BeerItem
                    {
                        ABV = beerResult.Abv,
                        Name = beerResult.Name,
                        Brewery = beerResult.BreweryName,
                        Description = beerResult.Description,
                        BreweryDbId = beerResult.Id,
                        BreweryId = beerResult.BreweryId,
                        Upc = beerResult.Upc
                    };
                    try
                    {
                        if(beerResult.Images != null || beerResult.Images[0] != null)
                        {
                            beer.ImageLarge = beerResult.Images[0];
                            beer.ImageMedium = beerResult.Images[1];
                            beer.ImageSmall = beerResult.Images[2];
                        }
                    }
                    catch(Exception ex)
                    {
                        Insights.Report(ex);
                    }
                    beers.Add(beer);
                }
            }
            var source = new SearchDataSource(beers);
            source.DidSelectBeer += (beer) => 
            {
                selectedBeer = beer;
                PerformSegue("beerDescriptionSegue", this);
                searchResultsTableView.DeselectRow(placeHolderTableView.IndexPathForSelectedRow, true);
            };
            
            searchResultsTableView.Source = source;
            searchResultsTableView.ReloadData();
            View.BringSubviewToFront(searchResultsTableView);
            UserDialogs.Instance.HideLoading();
        }       
           
        #endregion

        #region Properties
        public SearchDataSource DataSource {get; private set;}

        public UITableView SearchResultsTableView
        {
            get
            {
                return placeHolderTableView;
            }
        }

       #endregion
    }
}