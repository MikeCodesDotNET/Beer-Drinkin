using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

using Microsoft.Azure;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BeerDrinkin.Service.Services
{
    public class ImageService
    {
        readonly CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        private CloudBlobClient blobClient;
        private string containerName;
        private CloudBlobContainer container;


        public ImageService(string containerName)
        {
            if (string.IsNullOrEmpty(containerName))
                throw new ArgumentNullException();

            if(containerName.Length <3 || containerName.Length > 63)
                throw new ArgumentOutOfRangeException();

            this.containerName = containerName;
            blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            container = blobClient.GetContainerReference(containerName);
        }

        public async Task<string> SaveFromUrl(string url, string name)
        {
            var webClient = new WebClient();
            var data = webClient.DownloadData(url);


            return "";
            
        }
    }
}