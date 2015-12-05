using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using BeerDrinkin.Service.Models;
using System.Linq;
using BeerDrinkin.Service.Utils;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace BeerDrinkin.Service
{
    // A simple scheduled job which can be invoked manually by submitting an HTTP
    // POST request to the path "/jobs/UpdateSearchIndex".

    public sealed class UpdateSearchIndexJob : ScheduledJob
    {

        public async override Task ExecuteAsync()
        {
            var searchServiceName = "beerdrinkin";
            string apiKey;

            if (!Services.Settings.TryGetValue("SEARCH_PRIMARY_ADMIN_KEY", out apiKey))
            {
                Services.Log.Error("Failed to find Search Service admin key");
            }

            var serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apiKey));
            var indexClient = serviceClient.Indexes.GetClient("beers");

            Services.Log.Info("Started updating Beer Drinkin's search engine index!");

            var definition = new Index()
            {
                Name = "beers",
                Fields = new[]
                {
                    new Field("id", DataType.String)                            { IsKey = true },
                    new Field("name", DataType.String)                          { IsSearchable = true, IsFilterable = true },
                    new Field("description", DataType.String)                   { IsSearchable = true, IsFilterable = true },
                    new Field("brewery", DataType.String)                       { IsSearchable = true, IsFilterable = true },
                    new Field("abv", DataType.String)                           { IsFilterable = true, IsSortable = true }
                }
            };

            await serviceClient.Indexes.CreateOrUpdateAsync(definition);

            try
            {
                var context = new BeerDrinkinContext();
                var beerItems = context.Beers;
                if (beerItems.Count() != 0)
                {
                    var beers = beerItems.ToArray();
                    await indexClient.Documents.IndexAsync(IndexBatch.Create(beers.Select(IndexAction.Create)));
                }
                else
                    Services.Log.Info("Failed to find any beers in the DB to index");

            }   
            catch (IndexBatchException e)
            {
                // Sometimes when your Search service is under load, indexing will fail for some of the documents in
                // the batch. Depending on your application, you can take compensating actions like delaying and
                // retrying. For this simple demo, we just log the failed document keys and continue.
                Services.Log.Error( $"Failed to index some of the documents: {string.Join(", ", e.IndexResponse.Results.Where(r => !r.Succeeded).Select(r => r.Key))}");
            }

            Services.Log.Info("Finished updating Beer Drinkin's search engine index!");
        }
    }
}