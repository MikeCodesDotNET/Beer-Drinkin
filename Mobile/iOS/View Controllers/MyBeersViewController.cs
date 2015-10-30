using System;
using System.Collections.Specialized;
using BeerDrinkin.Core.ViewModels;
using UIKit;
using Foundation;
using System.Linq;

namespace BeerDrinkin.iOS
{
    partial class MyBeersViewController : BaseViewController
    {
        private readonly MyBeersViewModel viewModel = new MyBeersViewModel();
        private MyBeersDataSource dataSource;

        public MyBeersViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DismissKeyboardOnBackgroundTap();

            var bounds = this.NavigationController.NavigationBar.Bounds;         
            var blur = UIBlurEffect.FromStyle (UIBlurEffectStyle.Light);
            var visualEffectView = new UIVisualEffectView(blur);
            visualEffectView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
            this.NavigationController.NavigationBar.AddSubview(visualEffectView);
            this.NavigationController.NavigationBar.Translucent = true;


            var refreshControl = new UIRefreshControl();
            refreshControl.ValueChanged += delegate
            {
                viewModel.FetchBeersCommand();
            };
            tableView.AddSubview(refreshControl);

            viewModel.Beers.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
            {
                dataSource = new MyBeersDataSource(viewModel.Beers);
                dataSource.DidSelectBeer += (beer) =>
                {
                    var navctlr = Storyboard.InstantiateViewController("beerDescription") as BeerDescriptionTableView;
                    if (navctlr == null)
                        return;

                    var rowPath = tableView.IndexPathForSelectedRow;
                    var beerItem = viewModel.Beers[rowPath.Row].CheckIns.FirstOrDefault().Beer;
                    navctlr.SetBeer(beerItem);

                    var beerInfo = viewModel.Beers[rowPath.Row];
                        navctlr.SetBeerInfo(beerInfo);

                    NavigationController.PushViewController(navctlr, true);
                };
                tableView.Source = dataSource;
                tableView.ReloadData();
                refreshControl.EndRefreshing();

                if (viewModel.Beers.Count > 0)
                    View.BringSubviewToFront(tableView);
            };

            viewModel.FetchBeersCommand();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            viewModel.FetchBeersCommand();
        }
    }
}