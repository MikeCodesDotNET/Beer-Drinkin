using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using BeerDrinkin.Service.DataObjects;

namespace BeerDrinkin.Core.Services
{
    /*  Description
     *  
     *  The databse (BreweryDB) doesn't contain any barcode (unique product code) information which is a key feature of competing apps. In order to add this functionality
     *  into BeerDrinkin, we cheat a little. 
     * 
     *  We first want to check if we've already assoicated a beer in our database with a UPC. If we have then we can return the BeerItem which BeerDrinkin can display with
     *  no issues. If we don't happen to the UPC in our database then we'll use the users device to find the beer using RateBeer. The reason we use the users device rather
     *  than having the Azure backend complete the task is to avoid spamming the RateBeer API from one IP address. This way it becomes very difficult for the RateBeer team to
     *  identify if its geniune traffic or us pulling data. 
     * 
     *  Once RateBeer returns some beer information, we take the name of the first response (its an array but 99.9% of the time it only contains 1 item) and use that as a 
     *  search term with our standard beer searching methods. Once the user selects a beer and goes to check it in, we'll assume that the barcode matches the beer they
     *  selected. This of course could lead to incorrect entries. Its for this reason that we can add multiple barcodes to a BeerItem and we'll try and deduce incorrect 
     *  products on the backend. 
     * 
     *  Because we will now have a link between a BeerItem and the RateBeer beer ID, we save this for future use. It means that if we ever get a developer API key for 
     *  RateBeer (I have requested one but havn't heard back) we can add more functionality whilst keeping users existing DBs from BreweryDB. 
     */

    public class BarcodeLookupService
    {
        public string UPC { get; private set;}
        public int RateBeerID { get; private set;}

        public async Task<List<BeerItem>> SearchForBeer(string upc)
        {
            UPC = upc; 

            //Search Azure
            var azureResult = await Client.Instance.BeerDrinkinClient.LookupUpcAsync(upc);
            if (azureResult.Result != null)
            {
                return azureResult.Result;
            }

            //Search RateBeer 
            var rateBeerClient = new RateBeer.Client();
            var rateBeerResponse = await rateBeerClient.SearchForBeer(UPC);

            if(rateBeerResponse != null)
            {       
                RateBeerID = rateBeerResponse.BeerID;
                
                azureResult = await Client.Instance.BeerDrinkinClient.SearchBeerAsync(rateBeerResponse.BeerName);
                if(azureResult.Result != null)
                {
                    return azureResult.Result;
                }
            }
            return null;
        }

        public void ForgetLastSearch()
        {
            UPC = string.Empty;
            RateBeerID = 0;
        }
    }
}

