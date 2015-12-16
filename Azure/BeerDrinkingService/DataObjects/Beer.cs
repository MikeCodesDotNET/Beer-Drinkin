using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using BreweryDB.Interfaces;

namespace BeerDrinkin.Service.DataObjects
{
    public class BeerItem : EntityData 
    {
        //3rd Party beer databases.
        public string RateBeerId { get; set; }
        public string BreweryDbId { get; set; }
        public string UntappdId { get; set; }
        public string Upc { get; set; }

        public double Abv { get; set; }
        public Available Available { get; set; }
        public int AvailableId { get; set; }
        public List<Brewery> Breweries { get; set; }
        public string Brewery { get; set; }
        public string CreateDate { get; set; }
        public string Description { get; set; }
        public Glass Glass { get; set; }
        public int GlasswareId { get; set; }
        public string IsOrganic { get; set; }
        public Images Labels { get; set; }    
        public string Name { get; set; }
        public string NameDisplay { get; set; }
        public string ServingTemperature { get;  set;}       
        public List<SocialAccount> SocialAccounts { get; set; }
        public Srm Srm { get; set; }
        public int SrmId { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public Style Style { get; set; }
        public int StyleId { get; set; }
        public string UpdateDate { get; set; }
    }
}
