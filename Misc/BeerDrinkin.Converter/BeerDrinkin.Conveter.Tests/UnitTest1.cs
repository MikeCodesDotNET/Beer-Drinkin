using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeerDrinkin.Conveter.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var converter = new Converter.BreweryDBConverter();
            var client = new BreweryDB.BreweryDbClient("b7da1c5827026053a276f0dbe2234962");

            var beers = client.Beers.GetAll().Result;
            //Select page half way through db
            beers = client.Beers.GetAll(beers.NumberOfPages/2).Result;

            foreach (var beer in beers.Data)
            {
                //Check 50 beers
                var converteredBeer = converter.ConverterBeer(beer);

                Assert.IsTrue(beer != null && converteredBeer.Name == beer.Name);
                Assert.IsTrue(beer != null && converteredBeer.Description == beer.Description);
            }

        }
    }
}
