using System;
using System.Collections.Generic;
using System.Text;


namespace BeerDrinkin.DataObjects
{
    public interface IBaseDataObject
    {
        string Id { get; set; }
    }

     public class BaseDataObject
    {
        public BaseDataObject()
        {
            Id = Guid.NewGuid().ToString();
        }

        public bool IsHidden { get; set; }

        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        public string AzureVersion { get; set; }
    }
   
}
