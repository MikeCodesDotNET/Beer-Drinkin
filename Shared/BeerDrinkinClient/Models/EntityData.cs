using System;
using Microsoft.WindowsAzure.MobileServices;

namespace BeerDrinkin.Models
{
    public class EntityData
    {
        public string Id { get; set; }

        public string Version { get; set; }

        [CreatedAt]
        public DateTimeOffset? CreatedAt { get; set; }

        [UpdatedAt]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}