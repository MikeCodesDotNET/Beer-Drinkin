using System;

#if !CLIENT
using Microsoft.WindowsAzure.Mobile.Service;
#endif
namespace BeerDrinkin.Service.DataObjects
{
    public class ReviewItem:EntityData
    {
        public string BeerId { get; set; }
        public string Taste { get; set; }
        public string Appearance { get; set; }
        public string ReviewedBy { get; set; }
        public double Rating { get; set; }
        public int Useful { get; set; }
        public int Inappropriate { get; set; }
    }
}
