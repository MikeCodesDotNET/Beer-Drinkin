using System;

#if !CLIENT
using Microsoft.Azure.Mobile.Server;
#endif

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