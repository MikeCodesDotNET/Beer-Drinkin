using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Core.Abstractions.ViewModels
{
    public interface IUserProfileViewModel
    {
        string FirstName { get;}
        string LastName { get;}
        string AvatarUrl { get;}
        int BeerCount { get;}
        int RatingsCount { get; set;}
        int WishCount { get; set;}

        List<Wish> Wishes { get;}
        List<Rating> Ratings { get;}
    }
}

