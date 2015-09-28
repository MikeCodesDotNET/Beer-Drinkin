using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BreweryDB.Tests
{
    [TestClass]
    public class BreweryDBClientTests
    {

        private readonly string applicationKey = "b7da1c5827026053a276f0dbe2234962";


        [TestMethod]
        public void SearchForBeer()
        {
            BreweryDBClient.Initialize(applicationKey);
            var client = new BreweryDBClient();
            var beers = client.SearchForBeers("duvel").Result;

            Assert.IsNotNull(beers);
        }

        [TestMethod]
        public void BeerResultsContainBrewerys()
        {
            BreweryDBClient.Initialize(applicationKey);
            var client = new BreweryDBClient();
            var beers = client.SearchForBeers("duvel").Result;

            Assert.IsNotNull(beers.First().Breweries);
        }

        [TestMethod]
        public void BeerResultsContainLabelImages()
        {
            BreweryDBClient.Initialize(applicationKey);
            var client = new BreweryDBClient();
            var beers = client.SearchForBeers("duvel").Result;

            Assert.IsNotNull(beers.First().Labels);
        }
    }
}
