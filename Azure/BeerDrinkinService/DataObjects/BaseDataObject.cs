﻿using System;
using System.Collections.Generic;
using System.Text;
#if BACKEND
using Microsoft.Azure.Mobile.Server;
#else 
using MvvmHelpers;
#endif

namespace BeerDrinkin.DataObjects
{
    public interface IBaseDataObject
    {
        string Id { get; set; }
    }
#if BACKEND
    public class BaseDataObject : EntityData
    {
        public BaseDataObject ()
        {
            Id = Guid.NewGuid().ToString();
        }
        public bool IsHidden { get; set; }
    }
#else
    public class BaseDataObject : ObservableObject, IBaseDataObject
    {
        public BaseDataObject()
        {
            Id = Guid.NewGuid().ToString();
        }

        public bool IsHidden { get; set; }

        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }
    }
#endif
}
