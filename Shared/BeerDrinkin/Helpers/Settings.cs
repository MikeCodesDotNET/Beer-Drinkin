// Helpers/Settings.cs
using Plugin.Settings.Abstractions;
using Plugin.Settings;

namespace BeerDrinkin.Core.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string UserTrackingEnabledName = "user_tracking_enabled";
        private static readonly bool UserTrackingEnabledDefault = true;

        private const string StoreLoginCredentialsName = "store_login_credentials_name";
        private static readonly bool StoreLoginCredentialsDefault = true;

        private const string FirstRunName = "first_run";
        private static readonly bool FirstRunDefault = true;

        private const string FacebookTokenName = "facebookToken";
        private static readonly string FacebookTokenDefault = string.Empty;

        private const string GoogleTokenName = "googleToken";
        private static readonly string GoogleTokenDefault = string.Empty;

		#region Recent Searches
		private const string RecentSearchOne = "recentSearchOne";
		private static readonly string RecentSearchOneDefault = string.Empty;

		private const string RecentSearchTwo = "recentSearchTwo";
		private static readonly string RecentSearchTwoDefault = string.Empty;

		private const string RecentSearchThree = "recentSearchThree";
		private static readonly string RecentSearchThreeDefault = string.Empty;

		private const string RecentSearchFour = "recentSearchFour";
		private static readonly string RecentSearchFourDefault = string.Empty;
		#endregion

        #endregion

        public static bool UserTrackingEnabled
        {
            get { return AppSettings.GetValueOrDefault<bool>(UserTrackingEnabledName, UserTrackingEnabledDefault); }
            set { AppSettings.AddOrUpdateValue<bool>(UserTrackingEnabledName, value); }
        }

        public static bool StoreLoginCredentials
        {
            get { return AppSettings.GetValueOrDefault<bool>(StoreLoginCredentialsName, StoreLoginCredentialsDefault); }
            set { AppSettings.AddOrUpdateValue<bool>(StoreLoginCredentialsName, value); }
        }

        public static bool FirstRun
        {
            get { return AppSettings.GetValueOrDefault<bool>(FirstRunName, FirstRunDefault); }
            set { AppSettings.AddOrUpdateValue<bool>(FirstRunName, value); }
        }

        public static string FacebookToken
        {
            get { return AppSettings.GetValueOrDefault<string>(FacebookTokenName, FacebookTokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(FacebookTokenName, value); }
        }

        public static string GoogleToken
        {
            get { return AppSettings.GetValueOrDefault<string>(GoogleTokenName, GoogleTokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(GoogleTokenName, value); }
        }

		public static string RecentSearch1
		{
			get { return AppSettings.GetValueOrDefault<string>(RecentSearchOne, RecentSearchOneDefault); }
			set { AppSettings.AddOrUpdateValue<string>(RecentSearchOne, value); }
		}

		public static string RecentSearch2
		{
			get { return AppSettings.GetValueOrDefault<string>(RecentSearchTwo, RecentSearchTwoDefault); }
			set { AppSettings.AddOrUpdateValue<string>(RecentSearchTwo, value); }
		}

		public static string RecentSearch3
		{
			get { return AppSettings.GetValueOrDefault<string>(RecentSearchThree, RecentSearchThreeDefault); }
			set { AppSettings.AddOrUpdateValue<string>(RecentSearchThree, value); }
		}

		public static string RecentSearch4
		{
			get { return AppSettings.GetValueOrDefault<string>(RecentSearchFour, RecentSearchFourDefault); }
			set { AppSettings.AddOrUpdateValue<string>(RecentSearchFour, value); }
		}
    }
}