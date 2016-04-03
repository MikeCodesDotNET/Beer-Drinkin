namespace BeerDrinkin.Core.Helpers
{
    public class Keys
    {
        public static readonly string AzureSearchKey = "1EFFA883093FF79ABA9B19BCD807198C";

        public static readonly string XamarinInsightsKey = "7d20afb6d54b4754306ee7c62ba18f2a1e66a442";

        #if DEBUG
        public static readonly string ServiceUrl = "https://beerdrinkinservice-staging.azurewebsites.net";
        #else                                     
        public static readonly string ServiceUrl = "http://beerdrinkin.azure-mobile.net/";
        #endif

        public static readonly string ServiceKey = "zPjEdUBYuqSTNkZowbRApTbBJBASLZ60";

		public static readonly string FacebookClientId = "1441403606168987";

        public static readonly string BreweryDbKey = "a956af587b434c4c89ef18c7bbd2fac9";

		public static readonly string iTunesAppStorePublicKey = "";

    }
}