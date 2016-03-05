using MvvmHelpers;
using BeerDrinkin.Utils;
using BeerDrinkin.DataStore.Abstractions;

//Use Mock
using BeerDrinkin.DataStore.Mock.Stores;
using BeerDrinkin.DataStore.Mock;

//Use Azure
//using MyTrips.DataStore.Azure;
//using MyTrips.DataStore.Azure.Stores;
//using BeerDrinkin.DataStore.Azure;

using BeerDrinkin.AzureClient;

namespace BeerDrinkin.Core.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {

        public static void Init()
        {
            ServiceLocator.Instance.Add<IAzureClient, AzureClient.AzureClient>();
            ServiceLocator.Instance.Add<ICheckInStore, CheckInStore>();
			ServiceLocator.Instance.Add<IBeerStore, BeerStore>();
			ServiceLocator.Instance.Add<IWishListStore, WishListStore>();

            ServiceLocator.Instance.Add<IStoreManager, StoreManager>();

            //TODO: Put this somewhere....
            ServiceLocator.Instance.Resolve<IStoreManager>().InitializeAsync();
        }

        public Settings Settings
        {
            get { return Settings.Current; }
        }

        IStoreManager storeManager;
        public IStoreManager StoreManager => storeManager ?? (storeManager = ServiceLocator.Instance.Resolve<IStoreManager>());

    }
}
