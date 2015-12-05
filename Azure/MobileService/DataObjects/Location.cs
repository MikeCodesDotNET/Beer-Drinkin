using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace BeerDrinkin.Service.DataObjects
{
    public class Location : EntityData
    {
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string IsPrimary { get; set; }
        public string InPlanning { get; set; }
        public string IsClosed { get; set; }
        public string OpenToPublic { get; set; }
        public string LocationType { get; set; }
        public string LocationTypeDisplay { get; set; }
        public string CountryIsoCode { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public Country Country { get; set; }
    }
}