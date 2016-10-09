﻿using BeerDrinkin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.DataStore.Abstractions
{
    public interface IUserStore : IBaseStore<User>
    {
        Task<User> GetCurrentUser();
    }
}
