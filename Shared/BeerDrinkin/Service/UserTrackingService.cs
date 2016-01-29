using System;
using System.Threading.Tasks;
using Xamarin;

namespace BeerDrinkin.Core.Services
{
    public class UserTrackingService 
    {
        public static void ReportViewLoaded(string viewControllerName, string eventDescription)
        {
            if(BeerDrinkin.Core.Helpers.Settings.UserTrackingEnabled)
            {
                Insights.Track("Loaded AccountView", "ViewController", "AccountViewController");
            }
        }
    }
}


