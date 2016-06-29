using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Utils;

namespace BeerDrinkin.Core.ViewModels
{
    public class BeersViewModel : ViewModelBase
    {
        public ObservableCollection<Beer> Beers { get; } = new ObservableCollection<Beer>();
    }
}
