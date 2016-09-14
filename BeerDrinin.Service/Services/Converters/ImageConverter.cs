using System.Net;
using System.Threading.Tasks;

using BeerDrinkin.DataObjects;
using BeerDrinkin.Service.Models;

using BreweryDB.Interfaces;

using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;

namespace BeerDrinkin.Converters
{
    public class ImageConverter
    {
        public async Task<Image> ConvertLabel(ILabels label, string beerID)
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("beer-labels");

            var largeBlockBlob = container.GetBlockBlobReference($"upload_{beerID}_large.png");
            var mediumBlockBlob = container.GetBlockBlobReference($"upload_{beerID}_medium.png");
            var iconBlockBlob = container.GetBlockBlobReference($"upload_{beerID}_icon.png");

            var webClient = new WebClient();
            byte[] largeImageBytes = webClient.DownloadData(label.Large);
            byte[] mediumImageBytes = webClient.DownloadData(label.Medium);
            byte[] smallImageBytes = webClient.DownloadData(label.Icon);

            //lets confirm its not a dick pic...
            var visionService = new Service.Services.VisionService();
            var mayContainManMeat = await visionService.ContainsAdultContent(largeImageBytes) || await visionService.ContainsAdultContent(mediumImageBytes) || await visionService.ContainsAdultContent(smallImageBytes);

            if (mayContainManMeat == false)
            {
                var context = new MobileServiceContext();
                var flaggedContent = new FlaggedContent
                {
                    IsAdult = true,
                    BeerId = beerID,
                    Description = "Failed CogS adult check on intial import from BreweryDB",
                    IsImage = true
                };
                context.FlaggedContents.Add(flaggedContent);
                context.SaveChanges();
                return null;
            }

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
