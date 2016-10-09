using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;

namespace BeerDrinkin.Models
{
    public interface IBaseModel
    {
        string Id { get; set; }
    }

    public class BaseModel : ObservableObject, IBaseModel
    {
        public BaseModel()
        {
        }

        public bool IsHidden { get; set; }

        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        public string AzureVersion { get; set; }
    }
}
