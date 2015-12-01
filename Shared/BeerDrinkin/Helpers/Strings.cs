using System;

namespace BeerDrinkin.Core.Helpers
{
    public class Strings
    {
        #region WelcomePage

        public static readonly string Welcome_Title = "Create an account for saving beers!";
        public static readonly string Welcome_Facebook = "Connect to Facebook";
        public static readonly string Welcome_Google = "Connect to Google";
        public static readonly string Welcome_Promise = "We promise to never post on your accounts.";
        public static readonly string Welcome_AuthError = "Failed to authenticate with Facebook";

        #endregion

        #region Tabs

        public static readonly string Tabs_MyBeers = "My Beers";
        public static readonly string Tabs_Search = "Search";
        public static readonly string Tabs_Profile = "Profile";

        #endregion

        #region SearchTab

        public static readonly string Search_Title = "Search";
        public static readonly string Search_PlaceHolderTitle = "Search BeerDrinkin";
        public static readonly string Search_SubPlaceHolderTitle = "Find beers & breweries that interest you";
        public static readonly string Search_BarcodeNoResponse = "Unable to find beer with that barcode :(";
        public static readonly string Search_SearchingDatabase = "Searching for beer";

        #endregion
    }
}


