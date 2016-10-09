using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.Services.Abstractions;
using Foundation;
using System.Collections;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;
using BeerDrinkin.Models;

namespace BeerDrinkin.iOS.Helpers
{
    public class AppInsights : IAppInsights
    {

        public AppInsights()
        {
           
        }

        public void Identify(string userId)
        {
        }

        public void Report(Exception exception)
        {
			Xamarin.Insights.Report(exception);
        } 

        public void Report(Exception exception, IList<string> tags)
        {
			Xamarin.Insights.Report(exception);
        }

        public void Report(Exception exception, string viewController, string method, string comment = "")
        {
            Xamarin.Insights.Report(exception);
        }

        public void Report(Exception exception, string viewController, string method)
        {
            Report(exception, viewController, method, "");
        }

        public void Track(string eventName, TimeSpan time)
        {

        }

        public void Track(string eventName)
        {
        }

        public void Track(string eventName, IDictionary<object, object> data)
        {
        }
    }
}

