using NUnit.Framework;
using System;

namespace RateBeerTests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        async public void LookupUPC()
        {
            var client = new RateBeer.Client();
            var beerInfo = await client.SearchForBeer("5411681014005");

            if (beerInfo.BeerName == "Duvel")
                Assert.Pass();
            else
                Assert.Fail();
        }

    }
}

