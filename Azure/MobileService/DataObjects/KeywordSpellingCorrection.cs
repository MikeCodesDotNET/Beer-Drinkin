
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#if !CLIENT
using Microsoft.Azure.Mobile.Server;
#endif

namespace BeerDrinkin.Service.DataObjects
{
    public class KeywordSpellingCorrection : EntityData
    {
        public string Orginal { get; set; }
        public string Correction { get; set; }
    }
}