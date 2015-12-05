using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace BeerDrinkin.Service.DataObjects
{
    public class Category : EntityData
    {
        public string Name { get; set; }
    }

}