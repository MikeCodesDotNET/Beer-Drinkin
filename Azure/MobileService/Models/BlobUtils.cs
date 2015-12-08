
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Mobile.Server;

namespace BeerDrinkin.Service.Models
{
    public static class BlobUtils
    {
        public static async Task<string> SaveBinaryToAzureStorage(MobileAppSettingsDictionary settings, string blobId, string blobData )
        {
            string storageAccountName;
            string storageAccountKey;


            // Try to get the Azure storage account token from app settings.  
            if (!(settings.TryGetValue("STORAGE_ACCOUNT_NAME", out storageAccountName) |
                settings.TryGetValue("STORAGE_ACCOUNT_ACCESS_KEY", out storageAccountKey)))
            {
                return string.Empty;
            }

            // Set the URI for the Blob Storage service.
            Uri blobEndpoint = new Uri(string.Format("https://{0}.blob.core.windows.net", storageAccountName));

            // Create the BLOB service client.
            CloudBlobClient blobClient = new CloudBlobClient(blobEndpoint,
                new StorageCredentials(storageAccountName, storageAccountKey));

            string ContainerName = "beerdrinkinimages";

            // Create a container, if it doesn't already exist.
            CloudBlobContainer container = blobClient.GetContainerReference(ContainerName);
            await container.CreateIfNotExistsAsync();

            // Create a shared access permission policy. 
            BlobContainerPermissions containerPermissions = new BlobContainerPermissions();

            // Enable anonymous read access to BLOBs.
            containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;
            container.SetPermissions(containerPermissions);

            // Define a policy that gives write access to the container for 1 minute.                                   
            SharedAccessBlobPolicy sasPolicy = new SharedAccessBlobPolicy()
            {
                SharedAccessStartTime = DateTime.UtcNow,
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(1),
                Permissions = SharedAccessBlobPermissions.Write
            };

            // Get the SAS as a string.
            var SasQueryString = container.GetSharedAccessSignature(sasPolicy);

            // Set the URL used to store the image.
            var avatarUri = string.Format("{0}{1}/{2}", blobEndpoint.ToString(),
                ContainerName, blobId.ToLower());

            // Upload the new image as a BLOB from the string.
            CloudBlockBlob blobFromSASCredential =
                container.GetBlockBlobReference(blobId.ToLower());
            blobFromSASCredential.UploadTextAsync(blobData);

            return avatarUri;
        }
    }
}
