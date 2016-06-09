using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerDrinkin.Utils;
using BeerDrinkin.AzureClient;

namespace BeerDrinkin.Core.Tests
{
    [TestClass]
    public class Search
    {

        public Search()
        {
            ServiceLocator.Instance.Add<IAzureClient, AzureClient.AzureClient>();
        }

        [TestMethod]
        public void SearchForDuvel()
        {
            var searchViewModel = new ViewModels.SearchViewModel();
            var results = searchViewModel.Search("duvel").Result;

            Assert.IsTrue(results.Count > 0, $"Number of beers returned: {results.Count}");

            var duvel = results.FirstOrDefault(x => x.Id == "c8VKLu");
            Assert.IsNotNull(duvel);
        }

        [TestMethod]
        public void FetchTrendingBeers()
        {
            var searchViewModel = new ViewModels.SearchViewModel();
            var results = searchViewModel.TrendingBeers(10).Result;

            Assert.IsTrue(results.Count == 10);
        }
    }
}
