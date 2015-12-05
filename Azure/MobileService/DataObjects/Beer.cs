using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.Azure.Search.Models;
using Newtonsoft.Json;
#if !CLIENT
using Microsoft.WindowsAzure.Mobile.Service;
#endif
namespace BeerDrinkin.Service.DataObjects
{
    [SerializePropertyNamesAsCamelCase]
    public class Beer:EntityData 
    {
        //3rd Party beer databases.
        public string RateBeerId { get; set; }
        public string BreweryDbId { get; set; }
        public string UntappdId { get; set; }

        public string Name{get;set;}
        public string Description{get;set;}

        public string BreweryId { get; set; }
        public Brewery Brewery{get;set;}
        
        public string AvailableId { get; set; }
        public Available Available { get; set; }

        public string GlassId { get; set; }
        public Glass Glass { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public string ImagesId { get; set; }
        public Images Images { get; set; }
        
        public string SocialMediaId{get;set;}
        public SocailMedia SocailMedia { get; set; }

        public string StyleId { get; set; }
        public Style Style { get; set; }
            
        public string ABV { get; set; }
        public string UPC { get; set;}
        
#if CLIENT
        [IgnoreDataMember]
        public Style Style{get;set;}
        [IgnoreDataMember]
        public bool IsCheckedIn { get; set; }
#endif
    }
}
