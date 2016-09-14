using System;
using BeerDrinkin.Core.Abstractions.Services;
using BeerDrinkin.DataObjects;
using CoreSpotlight;
using Foundation;

namespace BeerDrinkin.iOS.Services
{
    public class SpotlightService : IDeviceSearchProvider
    {
        public SpotlightService()
        {
        }

        public void AddBeerToIndex(Beer beer)
        {
            var activity = new NSUserActivity("com.micjames.beerdrinkin.beerdetails");

            if (!string.IsNullOrEmpty(beer.Description))
            {
                var info = new NSMutableDictionary();
                info.Add(new NSString("name"), new NSString(beer.Name));
                info.Add(new NSString("description"), new NSString(beer.Description));

                /*
                if (beer?.Image?.MediumUrl != null)
                {
                    info.Add(new NSString("imageUrl"), new NSString(beer.Image.LargeUrl));
                }*/

                var attributes = new CSSearchableItemAttributeSet();
                attributes.DisplayName = beer.Name;
                attributes.ContentDescription = beer.Description;

                var keywords = new NSString[] { new NSString(beer.Name), new NSString("beerName") };
                activity.Keywords = new NSSet<NSString>(keywords);
                activity.ContentAttributeSet = attributes;

                activity.Title = beer.Name;
                activity.UserInfo = info;

                activity.EligibleForSearch = true;
                activity.EligibleForPublicIndexing = true;
                activity.BecomeCurrent();
            }

        }
    }
}

