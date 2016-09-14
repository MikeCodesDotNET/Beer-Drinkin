using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.DataObjects;
using Microsoft.WindowsAzure.Storage;

namespace BreweryDB.Converter
{
    public class ImageConverter
    {
        public async Task<Image> ConvertLabel(BreweryDB.Interfaces.ILabels label, string beerID, string connectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("beer-labels");

            var largeBlockBlob = container.GetBlockBlobReference($"upload_{beerID}_large.png");
            var mediumBlockBlob = container.GetBlockBlobReference($"upload_{beerID}_medium.png");
            var iconBlockBlob = container.GetBlockBlobReference($"upload_{beerID}_icon.png");

            var webClient = new WebClient();
            byte[] largeImageBytes = webClient.DownloadData(label.Large);
            byte[] mediumImageBytes = webClient.DownloadData(label.Medium);
            byte[] smallImageBytes = webClient.DownloadData(label.Icon);

            await largeBlockBlob.UploadFromByteArrayAsync(largeImageBytes, 0, largeImageBytes.Length);
            await mediumBlockBlob.UploadFromByteArrayAsync(mediumImageBytes, 0, mediumImageBytes.Length);
            await iconBlockBlob.UploadFromByteArrayAsync(smallImageBytes, 0, smallImageBytes.Length);

            var image = new Image
            {
                BeerId = beerID,
                LargeUrl = largeBlockBlob.Uri.ToString(),
                MediumUrl = mediumBlockBlob.Uri.ToString(),
                SmallUrl = iconBlockBlob.Uri.ToString()
            };
            return image;
        }
    }
}
