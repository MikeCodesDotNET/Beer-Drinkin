using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace BeerDrinkin.Service.DataObjects
{
    public class Images : EntityData
    {
        public string Icon { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }
}