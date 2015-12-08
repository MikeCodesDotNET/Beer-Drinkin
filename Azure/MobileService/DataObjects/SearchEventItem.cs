using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#if !CLIENT
using Microsoft.Azure.Mobile.Server;
#endif

namespace BeerDrinkin.Service.DataObjects
{
    //Every search a user makes will be stored in the DB. This will allow us to group search results together from the same users into sessions.
    public class SearchEventItem : EntityData
    {
        public string Query { get; set; }
        public int ResultsReturned { get; set; }
        public int UserId { get; set; }
    }
}