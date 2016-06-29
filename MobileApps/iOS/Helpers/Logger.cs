using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.Services.Abstractions;
using Mindscape.Raygun4Net;
using Foundation;
using System.Collections;
using BeerDrinkin.DataStore.Abstractions;
using BeerDrinkin.Utils;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.iOS.Helpers
{
    public class Logger : ILogService
    {

        IPerformanceEventStore performanceStore;

        public Logger()
        {
            RaygunClient.Attach(Utils.Keys.CrashReportingKey);

            var appVersion = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
            var buildNumber = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
            var applicationVersion = $"{appVersion}.{buildNumber}";

            RaygunClient.Current.ApplicationVersion = applicationVersion;

            performanceStore = ServiceLocator.Instance.Resolve<IPerformanceEventStore>();
        }

        public void Identify(string userId)
        {
            RaygunClient.Current.User = userId;
        }

        public void Report(Exception exception)
        {
            RaygunClient.Current.SendInBackground(exception);
        } 

        public void Report(Exception exception, IList<string> tags)
        {
            RaygunClient.Current.SendInBackground(exception, tags);
        }

        public void Report(Exception exception, string viewController, string method, string comment = "")
        {
            var dict = new Dictionary<string, object>();
            dict.Add("View Controller", viewController);
            dict.Add("Method", method);
            if(!string.IsNullOrEmpty(comment))
                dict.Add("Comment", comment);

            RaygunClient.Current.SendInBackground(exception, null, dict);
        }

        public void Report(Exception exception, string viewController, string method)
        {
            Report(exception, viewController, method, "");
        }

        public void Track(string eventName, TimeSpan time)
        {
            var e = new PerformanceEvent
            {
                UserId = Utils.Helpers.Settings.UserId,
                EventName = eventName,
                Elapsed = time.TotalMilliseconds
            };
            performanceStore.InsertAsync(e);
        }
    }
}

