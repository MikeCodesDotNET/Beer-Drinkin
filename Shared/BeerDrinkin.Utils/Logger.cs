using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerDrinkin.Utils.Interfaces;

namespace BeerDrinkin.Utils
{
    public class Logger : ILogger
    {
        public static string InsightsKey => BeerDrinkin.Utils.Keys.XamarinInsightsKeyWindowsManagementApp;

        static ILogger instance;
        public static ILogger Instance
        {
            get { return instance ?? (instance = ServiceLocator.Instance.Resolve<ILogger>()); }
        }
        #region ILogger implementation

        public virtual void WriteLine(string line)
        {
        }
        public virtual void Identify(string uid, IDictionary<string, string> table = null)
        {
            if (!Xamarin.Insights.IsInitialized)
                return;
            Xamarin.Insights.Identify(uid, table);
        }
        public virtual void Identify(string uid, string key, string value)
        {
            if (!Xamarin.Insights.IsInitialized)
                return;
            Xamarin.Insights.Identify(uid, key, value);
        }

        public virtual void Track(string trackIdentifier, IDictionary<string, string> table = null)
        {
            if (!Xamarin.Insights.IsInitialized)
                return;
            Xamarin.Insights.Track(trackIdentifier, table);
        }
        public virtual void Track(string trackIdentifier, string key, string value)
        {
            if (!Xamarin.Insights.IsInitialized)
                return;
            Xamarin.Insights.Track(trackIdentifier, key, value);
        }
        public virtual ITrackHandle TrackTime(string identifier, IDictionary<string, string> table = null)
        {

            if (!Xamarin.Insights.IsInitialized)
                return null;
            var handle = Xamarin.Insights.TrackTime(identifier, table);
            return new MyTripsTrackHandle(handle);
        }
        public virtual ITrackHandle TrackTime(string identifier, string key, string value)
        {

            if (!Xamarin.Insights.IsInitialized)
                return null;

            var handle = Xamarin.Insights.TrackTime(identifier, key, value);
            return new MyTripsTrackHandle(handle);
        }
        public virtual void Report(Exception exception = null, Severity warningLevel = Severity.Warning)
        {
            if (!Xamarin.Insights.IsInitialized)
                return;

            Xamarin.Insights.Report(exception, GetSeverity(warningLevel));
        }
        public virtual void Report(Exception exception, IDictionary extraData, Severity warningLevel = Severity.Warning)
        {

            if (!Xamarin.Insights.IsInitialized)
                return;
            Xamarin.Insights.Report(exception, extraData, GetSeverity(warningLevel));
        }
        public virtual void Report(Exception exception, string key, string value, Severity warningLevel = Severity.Warning)
        {
            if (!Xamarin.Insights.IsInitialized)
                return;
            Xamarin.Insights.Report(exception, key, value, GetSeverity(warningLevel));
        }
        public virtual Task Save()
        {
            if (!Xamarin.Insights.IsInitialized)
                return null;
            return Xamarin.Insights.Save();
        }
        public virtual Task PurgePendingCrashReports()
        {
            if (!Xamarin.Insights.IsInitialized)
                return null;
            return Xamarin.Insights.PurgePendingCrashReports();
        }

        public Xamarin.Insights.Severity GetSeverity(Severity severity)
        {
            switch (severity)
            {
                case Severity.Critical:
                    return Xamarin.Insights.Severity.Critical;
                case Severity.Error:
                    return Xamarin.Insights.Severity.Error;
                default:
                    return Xamarin.Insights.Severity.Warning;
            }
        }
        #endregion
    }

    public class MyTripsTrackHandle : ITrackHandle, IDisposable
    {
        readonly Xamarin.ITrackHandle handle;
        public MyTripsTrackHandle(Xamarin.ITrackHandle handle)
        {
            this.handle = handle;
        }

        #region ITrackHandle implementation
        public void Start() => handle?.Start();
        public void Stop() => handle?.Stop();

        public IDictionary<string, string> Data => handle?.Data;

        #endregion

        #region IDisposable implementation

        public void Dispose()
        {
            handle?.Stop();
            handle?.Dispose();
        }

        #endregion
    }
}
