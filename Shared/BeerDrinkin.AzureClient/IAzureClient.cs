using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace BeerDrinkin.AzureClient
{
    public interface IAzureClient
    {
        IMobileServiceClient Client { get; }
    }
}
