using System;
using Microsoft.WindowsAzure.MobileServices;

namespace BeerDrinkin.Service.DataObjects
{
    public class EntityData
    {
        public int Id { get; set; }

        public string Version { get; set; }

        [CreatedAt]
        public DateTimeOffset? CreatedAt { get; set; }

        [UpdatedAt]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}