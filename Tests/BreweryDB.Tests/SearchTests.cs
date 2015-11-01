using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryDB.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BreweryDB.Tests
{
    [TestClass]
    public class SearchTests
    {

        private readonly string applicationKey = "b7da1c5827026053a276f0dbe2234962";


        [TestMethod]
        public void SearchForBeer()
        {
            BreweryDBClient.Initialize(applicationKey);
            var beers = new BreweryDBSearch<Beer>("duvel").Search().Result;
            
            Assert.IsNotNull(beers);
        }

        [TestMethod]
        public void BeerResultsContainBrewerys()
        {
            BreweryDBClient.Initialize(applicationKey);
            var beers = new BreweryDBSearch<Beer>("duvel").Search().Result;

            Assert.IsNotNull(beers.First().Breweries);
        }

        [TestMethod]
        public void BeerResultsContainLabelImages()
        {
            BreweryDBClient.Initialize(applicationKey);
            var beers = new BreweryDBSearch<Beer>("duvel").Search().Result;

            Assert.IsNotNull(beers.First().Labels);
        }
    }
}
