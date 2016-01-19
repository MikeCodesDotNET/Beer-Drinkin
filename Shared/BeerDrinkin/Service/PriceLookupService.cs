using System;

namespace BeerDrinkin
{
    public class PriceLookupService
    {
        public PriceLookupService ()
        {
        }

        public  string GetPriceForBeer (string beerID)
        {
            return (6.00f - ((int)beerID.ToCharArray () [0]) / 100f).ToString ();
        }
    }
}

