using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;

namespace BeerDrinkin.API
{
    public class AzureSyncHandler : IMobileServiceSyncHandler
    {
        public Task<JObject> ExecuteTableOperationAsync(IMobileServiceTableOperation operation)
        {
            Debug.WriteLine("Executing operation '{0}' for table '{1}'", operation.Kind, operation.Table.TableName);
            return operation.ExecuteAsync();
        }

        public Task OnPushCompleteAsync(MobileServicePushCompletionResult result)
        {
            Debug.WriteLine("Push result: {0}", result.Status);
            foreach (var error in result.Errors)
            {
                Debug.WriteLine("  Push error: {0}", error.Status);
                if (error.Status == HttpStatusCode.Conflict)
                {
                    // Simplistic conflict handling - server wins
                    error.Handled = true;
                    error.CancelAndUpdateItemAsync(error.Item);
                }
            }


            return Task.FromResult(0);
        }
    }
}