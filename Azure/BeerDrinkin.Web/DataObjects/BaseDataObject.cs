using System;

namespace BeerDrinkin.DataObjects
{
    public class BaseDataObject 
    {
        public BaseDataObject()
        {
            Id = Guid.NewGuid().ToString();
        }

        public bool IsHidden { get; set; }

        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }
    }
}
