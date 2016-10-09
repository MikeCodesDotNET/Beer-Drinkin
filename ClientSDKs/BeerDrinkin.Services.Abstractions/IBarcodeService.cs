using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BeerDrinkin.Models;

namespace BeerDrinkin.Services.Abstractions
{
    public interface IBarcodeService
    {
        Task<List<Beer>>LookupBarcode(string upc);
    }
}

