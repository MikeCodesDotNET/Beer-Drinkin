using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Services.Abstractions
{
    public interface IImageService
    {
        Task<List<Beer>> LookupBeer(Stream stream);
        Task<string> SaveImage(Stream stream);
        Task<string> GetImageUrl(string id);
    }
}

