using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Mobile.Server;
#if !BACKEND
using MvvmHelpers;
#endif

namespace BeerDrinkin.DataObjects
{
    public interface IBaseDataObject
    {
        string Id { get; set; }
    }
#if !BACKEND
    public class BaseDataObject : ObservableObject, IBaseDataObject
    {
        public BaseDataObject()
        {
        }

        public bool IsHidden { get; set; }

        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        public string AzureVersion { get; set; }
    }
#else
     public class BaseDataObject : EntityData
    {
        public BaseDataObject ()
        {
            Id = Guid.NewGuid().ToString();
        }
        public bool IsHidden { get; set; }
    }
   
#endif
}
