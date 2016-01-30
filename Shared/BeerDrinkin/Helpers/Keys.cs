namespace BeerDrinkin.Core.Helpers
{
    public class Keys
    {
        public static readonly string AzureSearchKey = "FF2BC68DA8D3C9D57D3C7D0A2919B70B";

        public static readonly string XamarinInsightsKey = "7d20afb6d54b4754306ee7c62ba18f2a1e66a442";

        #if DEBUG
        public static readonly string ServiceUrl = "https://beerdrinkinservice-staging.azurewebsites.net";
        #else                                     
        public static readonly string ServiceUrl = "http://beerdrinkin.azure-mobile.net/";
        #endif

        public static readonly string ServiceKey = "zPjEdUBYuqSTNkZowbRApTbBJBASLZ60";

		public static readonly string FacebookClientId = "1441403606168987";

        public static readonly string BreweryDbKey = "a956af587b434c4c89ef18c7bbd2fac9";

    }
}