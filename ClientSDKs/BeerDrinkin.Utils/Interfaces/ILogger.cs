using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.Utils.Interfaces
{
    public enum Severity
    {
        /// <summary>
        /// Warning Severity
        /// </summary>
        Warning,
        /// <summary>
        /// Error Severity, you are not expected to call this from client side code unless you have disabled unhandled exception handling.
        /// </summary>
        Error,
        /// <summary>
        /// Critical Severity
        /// </summary>
        Critical
    }

    public interface ILogger
    {
        void Identify(string userId, string fullName, string email, bool isAnonymous);
        
        void Report(Exception exception, IDictionary<string, object> extraData);
        void Report(Exception exception);
        void Report(Exception exception, IList<string> tags);

        Task Save();
        Task PurgePendingCrashReports();
    }

    public interface ITrackHandle
    {
        void Start();
        void Stop();
        IDictionary<string, string> Data { get; }
    }
}
