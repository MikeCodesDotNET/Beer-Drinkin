using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using BeerDrinkin.Core.Helpers;
using BeerDrinkin.Utils;
using Plugin.Share;

namespace BeerDrinkin.Core.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public string PrivacyPolicyUrl => "http://beerdrink.in/privacy";
        public string TermsOfUseUrl => "http://beerdrink.in/termsofuse";
        public string SourceOnGitHubUrl => "https://github.com/MikeCodesDotNet/BeerDrinkin";
        public string XamarinUrl => "http://xamarin.com";

        ICommand openBrowserCommand;
        public ICommand OpenBrowserCommand =>
            openBrowserCommand ?? (openBrowserCommand = new RelayCommand<string>(async (url) => await ExecuteOpenBrowserCommandAsync(url)));

        public async Task ExecuteOpenBrowserCommandAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return;

            await CrossShare.Current.OpenBrowser(url, new Plugin.Share.Abstractions.BrowserOptions
            {
                ChromeShowTitle = true,
                ChromeToolbarColor = new Plugin.Share.Abstractions.ShareColor { A = 255, R = 96, G = 125, B = 139 },
                UseSafariWebViewController = true,
                UseSafairReaderMode = false
            });
        }

        ICommand logoutCommand;
        public ICommand LogoutCommand =>
            logoutCommand ?? (logoutCommand = new RelayCommand(async () => await ExecuteLogoutCommandAsync()));


        public async Task<bool> ExecuteLogoutCommandAsync()
        {
            var progress = Acr.UserDialogs.UserDialogs.Instance.Loading("Logging out...", show: false, maskType: Acr.UserDialogs.MaskType.Clear);

            try
            {
                var result = await Acr.UserDialogs.UserDialogs.Instance.ConfirmAsync("Are you sure you want to logout?", "Logout?", "Yes, Logout", "Cancel");

                if (!result)
                    return false;

                progress?.Show();
                await StoreManager.DropEverythingAsync();

                Settings.UserId = string.Empty;
                Settings.AuthToken = string.Empty;
                Settings.LoginAccount = LoginAccount.None;

            }
            catch (Exception ex)
            {
                Logger.Instance.Report(ex);
            }
            finally
            {
                progress?.Dispose();
            }

            return true;
        }
    }
}
