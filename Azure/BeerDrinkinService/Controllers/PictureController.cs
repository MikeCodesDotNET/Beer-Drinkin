using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Text;

namespace BeerDrinkin.Service.Controllers
{
    [MobileAppController]
    public class PictureController : ApiController
    {
        /*
        // GET api/Picture
        public async Task<string> Get(BinaryUploadRequest binaryUploadRequest)
        {
            var sas = "?sv=2015-04-05&ss=b&srt=sco&sp=rwdlac&se=2019-01-01T22:35:09Z&st=2016-07-01T14:35:09Z&spr=https&sig=OUJsZfe4PwNPcZvr0VNL%2FxYyYOTCasl%2BvbZj2wwTOUg%3D";
            var blobUrl = "https://beerdrinkinstore.blob.core.windows.net/";

            CloudBlobContainer container = new CloudBlobContainer(new Uri(sas));

            try
            {
                //Write operation: write a new blob to the container.
                CloudBlockBlob blob = container.GetBlockBlobReference("sasblob_" + date + ".txt");

                string blobContent = "This blob was created with a shared access signature granting write permissions to the container. ";
                MemoryStream msWrite = new
                MemoryStream(Encoding.UTF8.GetBytes(blobContent));
                msWrite.Position = 0;
                using (msWrite)
                {
                    await blob.UploadFromStreamAsync(msWrite);
                }
                Console.WriteLine("Write operation succeeded for SAS " + sas);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Write operation failed for SAS " + sas);
                Console.WriteLine("Additional error information: " + e.Message);
                Console.WriteLine();
            }


            return "Hello from custom controller!";
        }
        */
    }
}
