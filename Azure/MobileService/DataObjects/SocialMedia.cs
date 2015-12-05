using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace BeerDrinkin.Service.DataObjects
{
    public class SocailMedia : EntityData
    {
        public string Handle { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Website { get; set; }
    }
}