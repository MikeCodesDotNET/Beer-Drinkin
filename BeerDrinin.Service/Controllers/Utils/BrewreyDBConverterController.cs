using System;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

using BeerDrinkin.DataObjects;

using Microsoft.ApplicationInsights;
using Microsoft.Azure;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.WindowsAzure.Storage;

namespace BeerDrinin.Service.Controllers
{
    [MobileAppController]
    public class BrewreyDbConverterController : ApiController
    {
        private readonly TelemetryClient telemtryClient = new TelemetryClient();
        private readonly string apiKey = ConfigurationManager.AppSettings["BreweryDbApiKey"];

        [Route("api/brewerydb/convert/beer")]
        public async Task<Beer> GetBeerById(BreweryDB.Models.Beer dbBeer)
        {
            telemtryClient.TrackEvent("BreweryDB Beer Conversion");
            try
            {
                var beerConverter = new BeerDrinkin.Converters.BeerConverter();
                var beer = await beerConverter.ConvertBeerById(dbBeer, true);
                return beer;
            }
            catch (Exception ex)
            {
                telemtryClient.TrackException(ex);
                return null;
            }
        }

        [Route("api/brewerydb/convert/brewery")]
        public async Task<Brewery> GetBreweryById(string id)
        {
            try
            {
                telemtryClient.TrackEvent("BreweryDB Brewery Conversion");
                var client = new BreweryDB.BreweryDbClient(apiKey);
                var breweryResponse = await client.Breweries.Get(id);
                var dbBrewery = breweryResponse.Data;

                if (dbBrewery == null)
                    return null;

                var brewery = new Brewery
                {
                    Name = dbBrewery.Name,
                    Description = dbBrewery.Description,
                    Website = dbBrewery.Website
                };

                return brewery;
            }
            catch (Exception ex)
            {
                telemtryClient.TrackException(ex);
                return null;
            }
        }

        [Route("api/brewerydb/convert/style")]
        public async Task<Style> GetStyleById(string id)
        {
            try
            {
                telemtryClient.TrackEvent("BreweryDB Style Conversion");
                var client = new BreweryDB.BreweryDbClient(apiKey);
                var styleResponse = await client.Styles.Get(id);
                var dbStyle = styleResponse.Data;

                if (dbStyle == null)
                    return null;

                var style = new Style
                {
                    Name = dbStyle.Name,
                    ShortName = dbStyle.ShortName,
                    Description = dbStyle.Description,
                    IbuMin = dbStyle.IbuMin,
                    IbuMax = dbStyle.IbuMax,
                    AbvMin = dbStyle.AbvMin,
                    AbvMax = dbStyle.AbvMax,
                    SrmMin = dbStyle.SrmMin,
                    SrmMax = dbStyle.SrmMax,
                    OgMin = dbStyle.OgMin,
                    FgMax = dbStyle.FgMax,
                    FgMin = dbStyle.FgMin
                };

                return style;
            }
            catch (Exception ex)
            {
                telemtryClient.TrackException(ex);
                return null;
            }
        }

        private async Task<Image> SaveImageFromLabel(string beerID, BreweryDB.Interfaces.ILabels label)
        {
            try
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
            catch (Exception ex)
            {
                if(ex != null)
                    telemtryClient.TrackException(ex);
                throw;
            }
        }
    }
}
