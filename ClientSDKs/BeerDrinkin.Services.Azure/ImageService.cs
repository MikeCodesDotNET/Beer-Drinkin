using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BeerDrinkin.AzureClient;
using BeerDrinkin.Models;
using BeerDrinkin.Services.Abstractions;
using BeerDrinkin.Utils;

namespace BeerDrinkin.Services.Azure
{
    public class ImageService : IImageService
    {
        IAzureClient azure;
        IAppInsights logger;
        public ImageService()
        {
            azure = ServiceLocator.Instance.Resolve<IAzureClient>();
            logger = ServiceLocator.Instance.Resolve<IAppInsights>();
        }

        public Task<string> GetImageUrl(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Beer>> LookupBeer(Stream stream)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveImage(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}

