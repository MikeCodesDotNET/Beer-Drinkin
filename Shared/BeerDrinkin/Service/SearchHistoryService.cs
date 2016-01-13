using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BeerDrinkin.Service
{
    public class SearchHistoryService
    {
        public const int StoreSize = 4;
        public readonly ObservableCollection<string> History = new ObservableCollection<string>();

        public bool Add(string searchTerm)
        {            
            if(History.Count == StoreSize -1)
            {
                //Make space for the newest result
                History.RemoveAt(0);
            }
            History.Add(searchTerm);
            return true;
        }

        public bool Clear()
        {
            History.Clear();
            return true;
        }
    }
}

