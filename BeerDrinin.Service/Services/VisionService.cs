using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Vision;

namespace BeerDrinkin.Service.Services
{
    public class VisionService
    {
        public async Task<bool> ContainsAdultContent(byte[] imgArray)
        {
            var stream = new MemoryStream(imgArray);
            return await ContainsAdultContent(stream);
        }

        public async Task<bool> ContainsAdultContent(Stream imgStream)
        {
            //TODO Move API to portal config
            var VisionApiKey = ConfigurationManager.AppSettings["CognitiveServiceVisionApiKey"];
            var visionClient = new VisionServiceClient(VisionApiKey);
            VisualFeature[] features = { VisualFeature.Adult };
            var results = await visionClient.AnalyzeImageAsync(imgStream, features);

            return results.Adult.IsAdultContent;
        }
    }
}