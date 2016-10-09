using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.Models;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.DataStore.Azure.Stores;

namespace BeerDrinkin.DataStore.Azure
{
    public class BreweryStore : BaseStore<Brewery>, IBreweryStore
    {
        
    }
}
