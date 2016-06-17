using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Core.Abstractions.ViewModels
{
    public interface IWishListViewModel
    {
        Task DeleteWish(string id);
        Task<List<Wish>> GetWishes();
    }
}

