using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BeerDrinkin.Core.Helpers;

namespace BeerDrinkin.Core.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;   

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
        }

        protected void SetProperty<T>(ref T backingStore, T value,[CallerMemberName]string propertyName = "", Action onChanged = null) 
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} didn't change value", propertyName));
                return;
            }

            if(typeof(T) == typeof(List<string>))
            {
                var bs = backingStore as List<string>;
                var v = value as List<string>;

                    if(bs.SequenceEqual(v))
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("Skipped by comparing the sequence on: {0}", propertyName));
                        return;
                    }
            }
           

            System.Diagnostics.Debug.WriteLine(string.Format("Property {0} changed from {1} to {2}", propertyName, backingStore, value));

            backingStore = value;

            if (onChanged != null) 
                onChanged();

            OnPropertyChanged(propertyName);

        }

    }
}

