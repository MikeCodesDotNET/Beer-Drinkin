using MvvmHelpers;
using BeerDrinkin.Utils;
using BeerDrinkin.DataStore.Abstractions;

using BeerDrinkin.AzureClient;
using BeerDrinkin.Services.Azure;

using BeerDrinkin.DataStore.Azure;

namespace BeerDrinkin.Core.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {

        public static void Init()
        {
            //Azure Client
            ServiceLocator.Instance.Add<IAzureClient, AzureClient.AzureClient>();

            //Services
            ServiceLocator.Instance.Add<ISearchService, SearchService>();
            ServiceLocator.Instance.Add<IBarcodeService, BarcodeService>()

            //DataStores
            ServiceLocator.Instance.Add<ICheckInStore, CheckInStore>();
            ServiceLocator.Instance.Add<IUserStore, UserStore>();
            ServiceLocator.Instance.Add<IWishStore, WishStore>();
            ServiceLocator.Instance.Add<IBeerStore, BeerStore>();
            ServiceLocator.Instance.Add<IRatingStore, RatingStore>();

            ServiceLocator.Instance.Add<IStoreManager, StoreManager>();

            //TODO: Put this somewhere....
            ServiceLocator.Instance.Resolve<IStoreManager>().InitializeAsync();
        }

        IStoreManager storeManager;
        public IStoreManager StoreManager => storeManager ?? (storeManager = ServiceLocator.Instance.Resolve<IStoreManager>());

    }
}
