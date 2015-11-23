using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BeerDrinkin.Service.DataObjects;
using BeerDrinkin.Service.Models;
using Foundation;
using SDWebImage;
using UIKit;
using CoreLocation;
using MapKit;
using CoreSpotlight;
using Xamarin;

namespace BeerDrinkin.iOS
{
    partial class BeerDescriptionTableView : UITableViewController
    {
        BeerItem beer;
        BeerInfo beerInfo;
        const string activityName = "com.beerdrinkin.beer";
        List<UITableViewCell> cells = new List<UITableViewCell>();



        public BeerDescriptionTableView(IntPtr handle) : base(handle)
        {
        }


        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier != "addBeerSegue")
                return;

            // set in Storyboard
            var navctlr = segue.DestinationViewController as AddBeerTableViewController;
            if (navctlr == null)
                return;
            navctlr.SetBeer(beer);
        }

        async partial void btnShare_Activated(UIBarButtonItem sender)
        {
            var text = string.Format("Grab yourself a {0}, its a great beer!", beer.Name);
            var items = new NSObject[] { new NSString (text) };
            var activityController = new UIActivityViewController (items, null);
            await PresentViewControllerAsync (activityController, true);
        }

        public bool EnableCheckIn = false;

        //This is normally called from the search tab 
        public void SetBeer(BeerItem item)
        {
            beer = item;           

            //Start adding cells 
            AddHeaderImage();
            AddHeaderInfo();
            AddDescription();
            TableView.ReloadData();
        }

        public void SetBeerInfo(BeerInfo item)
        {
            beerInfo = item;
            if (beerInfo.CheckIns.Any(ch => ch.Latitude != 0))
            {
                AddCheckInMap();
            }
        }

        #region AddCells
  
        void AddCheckIn()
        {
            var checkInCellIdentifier = new NSString("checkInCell");
            var checkInCell = TableView.DequeueReusableCell(checkInCellIdentifier) as BeerDescriptionCheckInCell ??
                new BeerDescriptionCheckInCell(checkInCellIdentifier);
            
            cells.Add(checkInCell);
            
        }

        void AddCheckInMap()
        {
            var mapViewCellIdentifier = new NSString("mapViewCell");
            var mapViewCell = TableView.DequeueReusableCell(mapViewCellIdentifier) as CheckInLocationMapCell ??
                              new CheckInLocationMapCell(mapViewCellIdentifier);

            if (mapViewCell.MapView == null)
                return;

            foreach (var checkin in beerInfo.CheckIns)
            {
                var location = new CLLocationCoordinate2D(checkin.Latitude, checkin.Longitude);
                var annotation = new CheckInMapViewAnnotation((location), beerInfo.Name, checkin.CreatedAt.ToString());
                mapViewCell.MapView.AddAnnotation(annotation);             
            }

            /*
            //Zooming 
            var minLatitude = beerInfo.CheckIns.Min(x => x.Latitude);
            var maxLatitude = beerInfo.CheckIns.Max(x => x.Latitude);
            var minLongitude = beerInfo.CheckIns.Min(x => x.Longitude);
            var maxLongitude = beerInfo.CheckIns.Max(x => x.Latitude);

            var loc = new CLLocationCoordinate2D(minLatitude + maxLatitude / 2, minLongitude + maxLongitude / 2);
            var span = new MKCoordinateSpan(maxLatitude - minLatitude, maxLongitude - minLongitude);
            mapViewCell.MapView.Region = new MKCoordinateRegion(loc, span);

            var tap = new UITapGestureRecognizer { CancelsTouchesInView = false };
            tap.AddTarget(() =>
                {
                    var vc = new UIStoryboard().InstantiateViewController("fullScreenMapView");
                    PresentViewController(vc, true, null);
                });
            
            mapViewCell.MapView.AddGestureRecognizer(tap);
            */
            cells.Add(mapViewCell);
           
        }

        void AddHeaderImage()
        {
            var headerImageCellIdentifier = new NSString("headerImageCell");
            var headerImageCell = TableView.DequeueReusableCell(headerImageCellIdentifier) as BeerHeaderImageCell ??
                                  new BeerHeaderImageCell(headerImageCellIdentifier);
            if (beer.Large != null)
            {
                headerImageCell.LogoImageView.SetImage(new NSUrl(beer.Large), UIImage.FromBundle("BeerDrinkin.png"));
            }
            else
            {
                headerImageCell.LogoImageView.Image = UIImage.FromBundle("BeerDrinkin.png");
            }

            cells.Add(headerImageCell);
        }

        void AddHeaderInfo()
        {
            var headerCellIdentifier = new NSString("headerCell");
            var headerCell = TableView.DequeueReusableCell(headerCellIdentifier) as BeerHeaderCell ??
                             new BeerHeaderCell(headerCellIdentifier);
            headerCell.Name = beer?.Name;
            headerCell.Brewery = beer?.Brewery;
            headerCell.Abv = beer?.ABV;

            headerCell.ConsumedAlpha = 0.3f;
            headerCell.RatingAlpha = 0.3f;
            //Lets fire up another thread so we can continue loading our UI and makes the app seem faster.
            Task.Run(() =>
                {
                    var response = Client.Instance.BeerDrinkinClient.GetBeerInfoAsync(beer.Id).Result;
                    if (response.Result != null)
                        beerInfo = response.Result;

                    InvokeOnMainThread(() =>
                        {
                            if (beerInfo == null)
                                return;

                            headerCell.Consumed = beerInfo?.CheckIns.ToList().Count.ToString();
                            headerCell.Rating = beerInfo?.AverageRating != 0 ? beerInfo.AverageRating.ToString(CultureInfo.InvariantCulture) : "NA";

                            UIView.Animate(0.3, 0, UIViewAnimationOptions.TransitionCurlUp, () =>
                                {
                                    headerCell.ConsumedAlpha = 1f;
                                    headerCell.RatingAlpha = 1f;

                                }, () =>
                                {
                                });
                        });
                });


            cells.Add(headerCell);
        }

        void AddDescription()
        {
            if (!string.IsNullOrEmpty(beer.Description))
            {
                var cellIdentifier = new NSString("descriptionCell");
                var cell = TableView.DequeueReusableCell(cellIdentifier) as BeerDescriptionCell ??
                    new BeerDescriptionCell(cellIdentifier);
                cell.Text = beer.Description;
                cells.Add(cell);
            }
        }
       
        #endregion 

        #region Overrides

        ITrackHandle trackerHandle;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (BeerDrinkin.Core.Helpers.Settings.UserTrackingEnabled)
            {
                trackerHandle = Insights.TrackTime("Time Viewing BeerDescription");
                trackerHandle.Start();

                Insights.Track("Beer Description Loaded", new Dictionary<string, string> {
                    {"Beer Name", beer.Name},
                    {"Beer Id", beer.Id}
                });
            }

            TableView.Source = new DescriptionTableViewSource(ref cells);
            TableView.Delegate = new DescriptionDelegate(ref cells);
            TableView.ReloadData();
            View.SetNeedsDisplay();


       
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            if(TabBarController != null)
                TabBarController.TabBar.Hidden = false;
            
            TableView.ReloadData();


        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            if (trackerHandle != null)
            {
                trackerHandle.Stop();
                trackerHandle = null;
            }
        }

        public override void UpdateUserActivityState(NSUserActivity activity)
        {
            activity.AddUserInfoEntries(NSDictionary.FromObjectAndKey(new NSString(beer.Id), new NSString("id")));
            base.UpdateUserActivityState(activity);
        }

        #endregion

        #region Useful snippets

        double MilesToLatitudeDegrees(double miles)
        {
            double earthRadius = 3960.0;
            double radiansToDegrees = 180.0 / Math.PI;
            return (miles / earthRadius) * radiansToDegrees;
        }

        double MilesToLongitudeDegrees(double miles, double atLatitude)
        {
            double earthRadius = 3960.0;
            double degreesToRadians = Math.PI / 180.0;
            double radiansToDegrees = 180.0 / Math.PI;

            // derive the earth's radius at that point in latitude
            double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
            return (miles / radiusAtLatitude) * radiansToDegrees;
        }


        #endregion

        #region Classses

        class DescriptionTableViewSource : UITableViewSource
        {
            readonly List<UITableViewCell> cells = new List<UITableViewCell>();

            public DescriptionTableViewSource(ref List<UITableViewCell> cells)
            {
                this.cells = cells;
            }

            #region implemented abstract members of UITableViewSource

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                return cells[indexPath.Row];
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return cells.Count;
            }

            #endregion
        }

        class DescriptionDelegate : UITableViewDelegate
        {
            readonly List<UITableViewCell> cells = new List<UITableViewCell>();

            public DescriptionDelegate(ref List<UITableViewCell> cells)
            {
                this.cells = cells;
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = cells[indexPath.Row];

                if (cell.GetType() == typeof(BeerDescriptionCell))
                {
                    var c = cell as BeerDescriptionCell;
                    return c.PreferredHeight + 24;
                }

                if (cell.GetType() == typeof(BeerHeaderCell))
                {
                    var c = cell as BeerHeaderCell;
                    return c.Frame.Height;
                }

                if (cell.GetType() == typeof(BeerHeaderImageCell))
                    return 150;

                if (cell.GetType() == typeof(CheckInLocationMapCell))
                    return 200;

                if (cell.GetType() == typeof(BeerDescriptionCheckInCell))
                    return 50;

                return 0;
            }

            public override nfloat EstimatedHeight(UITableView tableView, NSIndexPath indexPath)
            {
                return GetHeightForRow(tableView, indexPath);
            }


        }

        protected class CheckInMapViewAnnotation : MKAnnotation
        {

            CLLocationCoordinate2D coord;
            protected string title;
            protected string subtitle;

            public override CLLocationCoordinate2D Coordinate { get { return coord; } }

            public override string Title
            { get { return title; } }

            public override string Subtitle
            { get { return subtitle; } }

            public CheckInMapViewAnnotation(CLLocationCoordinate2D coordinate, string title, string subTitle)
                : base()
            {
                this.coord = coordinate;
                this.title = title;
                this.subtitle = subTitle;
            }
        }

        #endregion
    }
}