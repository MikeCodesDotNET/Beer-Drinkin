using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using BeerDrinkin.Core.Helpers;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;

namespace BeerDrinkin.Core.ViewModels
{
	public class WishListViewModel : ViewModelBase
	{
		public ObservableCollection<Wish> Wishes = new ObservableCollection<Wish>();

		ICommand loadWishListCommand;
		public ICommand LoadWishListCommand => loadWishListCommand ?? (loadWishListCommand = new RelayCommand(async () => await ExecuteLoadWishListCommandAsync()));

		public async Task ExecuteLoadWishListCommandAsync()
		{
			if (IsBusy)
				return;

			var track = Logger.Instance.TrackTime("LoadWishList");
			track.Start();

			try
			{
				IsBusy = true;
				CanLoadMore = true;

				Wishes.Clear();
				var wishes = await StoreManager.WishListStore.GetItemsAsync(0, 100, true);
				foreach (var wish in wishes)
				{
					Wishes.Add(wish);
				}

				CanLoadMore = Wishes.Count == 25;
			}
			catch (Exception ex)
			{
				Logger.Instance.Report(ex);
			}
			finally
			{
				track.Stop();
				IsBusy = false;
			}
		}

		ICommand addWishCommand;
		public ICommand AddWishCommand => addWishCommand ?? (addWishCommand = new RelayCommand<Wish>(async (wish) => await ExecuteAddWishCommandAsync(wish)));

		public async Task ExecuteAddWishCommandAsync(Wish wish)
		{
			if (IsBusy)
				return;

			var track = Logger.Instance.TrackTime("AddWish");
			track.Start();

			try
			{
				IsBusy = true;

				await StoreManager.WishListStore.InsertAsync(wish);
			}
			catch (Exception ex)
			{
				Logger.Instance.Report(ex);
			}
			finally
			{
				track.Stop();
				IsBusy = false;
			}
		}

	}
}

