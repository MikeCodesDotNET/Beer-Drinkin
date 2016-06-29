using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerDrinkin.Services.Abstractions
{
    public interface IAppInsights
    {
        void Identify(string userId);

        //Crash Reporting 
        void Report(Exception exception);

        void Report(Exception exception, IList<string> tags);

        void Report(Exception exception, string viewController, string method, string comment);

        void Report(Exception exception, string viewController, string method);

        //Tracking 
        void Track(string eventName);

        void Track(string eventName, TimeSpan duration);

        void Track(string eventName, IDictionary<object, object> data);
    }
}
