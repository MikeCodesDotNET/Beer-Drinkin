using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace BeerDrinkin.Service.DataObjects
{
    public class Available : EntityData
    {
        public string Description { get; set; }
        public string Name { get; set; }
    }
}