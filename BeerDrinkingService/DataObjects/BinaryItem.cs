using System;

using Microsoft.WindowsAzure.Mobile.Service;

namespace BeerDrinkin.Service.DataObjects
{
    public class BinaryItem : EntityData
    {
        public string ObjectId { get; set; }

        public string BinaryUrl { get; set; }

        public string BinaryType { get; set; }

        public string UserId { get; set; }
    }
}