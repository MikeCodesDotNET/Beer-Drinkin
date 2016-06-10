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
        public static string InsightsKey => Keys.RaygunKey;

        static ILogger instance;
        public static ILogger Instance
        {
            get { return instance ?? (instance = ServiceLocator.Instance.Resolve<ILogger>()); }
        }

        public void Identify(string userId, string fullName, string email, bool isAnonymous)
        {
        }

        public void Report(Exception exception, IDictionary<string, object> extraData)
        {
        }

        public void Report(Exception exception)
        {
        }

        public void Report(Exception exception, IList<string> tags)
        {
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task PurgePendingCrashReports()
        {
            throw new NotImplementedException();
        }
    }
      
}
