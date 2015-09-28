using NUnit.Framework;
using System;
using BreweryDB.Models;

namespace BreweryDB.Tests
{
    public class Client
    {
        //API key used exclusivly for Unit testing 
        private const string applicationKey = "b7da1c5827026053a276f0dbe2234962";

        [Test]
        public void QueryBeerById()
        {
            var breweryClient = new BreweryDBClient(applicationKey);
            var response = breweryClient.QueryBeerById("cBLTUw");

            Assert.IsTrue(response.Description.Contains("Heads this one's for you!"));
        }

        [Test]
        public async void SearchForBeer()
        {
            var breweryClient = new BreweryDBClient(applicationKey);
            var response = await breweryClient.SearchForBeers("Duvel");

            Assert.IsNotNull(response);
        }
    }
}

