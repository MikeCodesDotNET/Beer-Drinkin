using System;

#if !CLIENT
using Microsoft.WindowsAzure.Mobile.Service;
#endif
namespace BeerDrinkin.Service.DataObjects
{
    public class Style : EntityData
    {
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string IbuMin { get; set; }
        public string IbuMax { get; set; }
        public string AbvMin { get; set; }
        public string AbvMax { get; set; }
        public string SrmMin { get; set; }
        public string SrmMax { get; set; }
        public string OgMin { get; set; }
        public string FgMin { get; set; }
        public string FgMax { get; set; }
    }
}
