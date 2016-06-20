using MvvmHelpers;
using BeerDrinkin.Utils;
using BeerDrinkin.DataStore.Abstractions;

using BeerDrinkin.AzureClient;
using BeerDrinkin.DataStore.Azure;
using BeerDrinkin.Services.Abstractions;
using BeerDrinkin.Core.Abstractions.ViewModels;

namespace BeerDrinkin.Core.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {

        public static void Init()
        {
            //Azure Client
            ServiceLocator.Instance.Add<IAzureClient, AzureClient.AzureClient>();

            InitServices();
            InitDataStores();
            InitViewModels();

            ServiceLocator.Instance.Add<IStoreManager, StoreManager>();
            ServiceLocator.Instance.Resolve<IStoreManager>().InitializeAsync();
        }

        static void InitDataStores()
        {
            ServiceLocator.Instance.Add<ICheckInStore, CheckInStore>();
            ServiceLocator.Instance.Add<IUserStore, UserStore>();
            ServiceLocator.Instance.Add<IWishStore, WishStore>();
            ServiceLocator.Instance.Add<IBeerStore, BeerStore>();
            ServiceLocator.Instance.Add<IRatingStore, RatingStore>();

            //Used to log performance information. Not essential for users but useful to development (finding bottle necks)
            ServiceLocator.Instance.Add<IPerformanceEventStore, PerformanceEventStore>();
        }

        static void InitServices()
        {
            ServiceLocator.Instance.Add<ISearchService, SearchService>();
            ServiceLocator.Instance.Add<ITrendsService, TrendsService>();
            ServiceLocator.Instance.Add<IBarcodeService, BarcodeService>();
        }

        static void InitViewModels()
        {
            ServiceLocator.Instance.Add<ICheckInsViewModel, CheckInsViewModel>();
            ServiceLocator.Instance.Add<IDiscoverViewModel, DiscoverViewModel>();
            ServiceLocator.Instance.Add<IAppFeedbackViewModel, AppFeedbackViewModel>();
            ServiceLocator.Instance.Add<IBeersViewModel, BeersViewModel>();
            ServiceLocator.Instance.Add<ICheckInViewModel, CheckInViewModel>();
            ServiceLocator.Instance.Add<IUserProfileViewModel, UserProfileViewModel>();
            ServiceLocator.Instance.Add<IWishListViewModel, WishListViewModel>();
        }

        IStoreManager storeManager;
        public IStoreManager StoreManager => storeManager ?? (storeManager = ServiceLocator.Instance.Resolve<IStoreManager>());

    }
}
