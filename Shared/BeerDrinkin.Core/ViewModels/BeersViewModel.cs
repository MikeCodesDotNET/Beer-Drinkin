using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BeerDrinkin.Core.Helpers;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;
using MvvmHelpers;

namespace BeerDrinkin.Core.ViewModels
{
    public class BeersViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Beer> Beers { get; } = new ObservableRangeCollection<Beer>();

        ICommand loadBeersCommand;
        public ICommand LoadBeersCommand => loadBeersCommand ?? (loadBeersCommand = new RelayCommand(async () => await ExecuteLoadBeersCommandAsync()));

        public async Task ExecuteLoadBeersCommandAsync()
        {
            if (IsBusy)
                return;

            var track = Logger.Instance.TrackTime("LoadBeers");
            track.Start();

            try
            {
                IsBusy = true;
                CanLoadMore = true;

                Beers.ReplaceRange(await StoreManager.BeerStore.GetItemsAsync(0, 50, true));
                CanLoadMore = Beers.Count == 25;
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
