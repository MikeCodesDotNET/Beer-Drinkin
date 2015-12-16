using System;
using System.Runtime.Serialization;

#if !CLIENT
using Microsoft.WindowsAzure.Mobile.Service;
#endif
namespace BeerDrinkin.Service.DataObjects
{
    public class BeerItem:EntityData
    {
        public string Name{get;set;}
        public string Description{get;set;}
        public string Brewery{get;set;}
        public string StyleId{get;set;}
        public string BreweryDbId{get;set;}
        public string ABV { get; set; }

        public string Upc { get; set;}
        public int RateBeerId {get; set;}

        public Labels Labels {get; set;}


        #if CLIENT
        [IgnoreDataMember]
        public BeerStyle Style{get;set;}
        [IgnoreDataMember]
        public bool IsCheckedIn { get; set; }
        #endif
    }
}
