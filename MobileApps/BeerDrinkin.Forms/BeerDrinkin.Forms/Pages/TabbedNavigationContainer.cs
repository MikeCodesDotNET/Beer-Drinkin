using FreshMvvm;
using Xamarin.Forms;

namespace BeerDrinkin.Forms.Pages
{
    public class TabbedNavigationContainer : FreshTabbedNavigationContainer
    {
        protected override Page CreateContainerPage(Page page)
        {
            return new NavigationPage(page)
            {
                BarBackgroundColor = (Color)Application.Current.Resources["PrimaryBarColor"],
                BarTextColor = (Color)Application.Current.Resources["PrimaryBarTextColor"]
            };
        }
    }
}