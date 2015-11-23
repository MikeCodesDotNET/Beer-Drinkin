using System;
using System.Runtime.Serialization;

#if !CLIENT
using Microsoft.WindowsAzure.Mobile.Service;
#endif
namespace BeerDrinkin.Service.DataObjects
{
    public class BeerItem:EntityData
    {
        public BeerItem()
        {

        }
        public BeerItem(BeerItemCache beer)
        {
            Name = beer.Name;
            Description = beer.Description;
            Brewery = beer.Brewery;
            StyleId = beer.StyleId;
            BreweryDBId = beer.BreweryDBId;
            ABV = beer.ABV;
            UPC = beer.UPC;
            RateBeerId = beer.RateBeerId;
            Icon = beer.Icon;
            Medium = beer.Medium;
            Large = beer.Large;

            #if CLIENT
            Style = beer.Style;
            IsCheckedIn = beer.IsCheckedIn;
            #endif

        }
        public string Name{get;set;}
        public string Description{get;set;}
        public string Brewery{get;set;}
        public string StyleId{get;set;}
        public string BreweryDBId{get;set;}
        public string ABV { get; set; }

        public string UPC { get; set;}
        public int RateBeerId {get; set;}

        public string Icon { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }

#if CLIENT
        [IgnoreDataMember]
        public BeerStyle Style{get;set;}
        [IgnoreDataMember]
        public bool IsCheckedIn { get; set; }
#endif
    }


    public class BeerItemCache:EntityData
    {
        public string NameLower { get; set;}

        public BeerItemCache()
        {
        }
        public BeerItemCache(BeerItem beer)
        {
            NameLower = beer.Name.ToLowerInvariant();
            Name = beer.Name;
            Description = beer.Description;
            Brewery = beer.Brewery;
            StyleId = beer.StyleId;
            BreweryDBId = beer.BreweryDBId;
            ABV = beer.ABV;
            UPC = beer.UPC;
            RateBeerId = beer.RateBeerId;
            Icon = beer.Icon;
            Medium = beer.Medium;
            Large = beer.Large;
            Style = beer.Style;
            IsCheckedIn = beer.IsCheckedIn;
        }

        public string Name{get;set;}
        public string Description{get;set;}
        public string Brewery{get;set;}
        public string StyleId{get;set;}
        public string BreweryDBId{get;set;}
        public string ABV { get; set; }

        public string UPC { get; set;}
        public int RateBeerId {get; set;}

        public string Icon { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }

        #if CLIENT
        [IgnoreDataMember]
        public BeerStyle Style{get;set;}
        [IgnoreDataMember]
        public bool IsCheckedIn { get; set; }
        #endif
    }
}
