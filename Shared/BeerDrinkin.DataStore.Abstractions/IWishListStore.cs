using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.DataStore.Abstractions
{
    public interface IWishListStore : IBaseStore<Wish>
    {
    }
}
