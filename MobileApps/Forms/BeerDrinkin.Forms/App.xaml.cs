using Acr.UserDialogs;
using BeerDrinkin.Core.ViewModels;
using BeerDrinkin.Forms.Interfaces;
using BeerDrinkin.Forms.PageModels;
using BeerDrinkin.Forms.Pages;
using BeerDrinkin.Forms.Services;
using FreshTinyIoC;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace BeerDrinkin.Forms
{
    public partial class App : Application
    {
        public App()
        {
            ViewModelBase.Init();
            //ServiceLocator.Instance.Add<ILogService, Logger>();

            InitializeComponent();

            FreshTinyIoCContainer.Current.Register<IUserDialogs>(UserDialogs.Instance);
            FreshTinyIoCContainer.Current.Register<IBeerDrinkinClient>(new BeerDrinkinClient());

            var mainPage = new TabbedNavigationContainer();

            mainPage.AddTab<DiscoverPageModel>("Discover", "tabbar_search");
            mainPage.AddTab<MyBeersPageModel>("My Beers", "tabbar_mybeers");
            mainPage.AddTab<WishListPageModel>("Wish List", "tabbar_wishlist");
            mainPage.AddTab<ProfilePageModel>("Profile", "tabbar_profile");

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}