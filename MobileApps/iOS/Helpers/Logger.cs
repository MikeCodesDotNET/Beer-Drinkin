using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDrinkin.Services.Abstractions;
using Mindscape.Raygun4Net;
using Foundation;

namespace BeerDrinkin.iOS.Helpers
{
    public class Logger : ILogService
    {
        public Logger()
        {
            RaygunClient.Attach(Utils.Keys.CrashReportingKey);

            var appVersion = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
            var buildNumber = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
            var applicationVersion = $"{appVersion}.{buildNumber}";

            RaygunClient.Current.ApplicationVersion = applicationVersion;
        }

        public void Identify(string userId)
        {
            RaygunClient.Current.UserInfo.Identifier = userId;
            RaygunClient.Current.UserInfo.UUID = userId;
            RaygunClient.Current.User = userId;
        }

        public void Report(Exception exception)
        {
            RaygunClient.Current.SendInBackground(exception);
        } 

        public void Report(Exception exception, IList<string> tags)
        {
            RaygunClient.Current.Send(exception, tags);
        }
    }
}

