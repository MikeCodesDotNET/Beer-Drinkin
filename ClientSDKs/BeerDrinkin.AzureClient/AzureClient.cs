using Microsoft.WindowsAzure.MobileServices;

namespace BeerDrinkin.AzureClient
{
    public class AzureClient : IAzureClient
    {
        IMobileServiceClient client;
        public IMobileServiceClient Client => client ?? (client = new MobileServiceClient(Utils.Keys.ServiceUrl, new AuthHandler()));
    }
}
