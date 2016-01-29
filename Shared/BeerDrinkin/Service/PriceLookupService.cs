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
            if(beerID == "c8VKLu")
                return "2.70";
            
            return (6.00f - ((int)beerID.ToCharArray () [0]) / 100f).ToString ();
        }
    }
}

