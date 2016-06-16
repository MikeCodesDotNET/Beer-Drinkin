using Android.App;
using Android.Content.PM;
using Android.OS;
using BeerDrinkin.Forms.Helpers;
using FFImageLoading.Forms.Droid;
using FormsToolkit.Droid;
using Xamarin;
using Xamarin.Forms.Platform.Android;

namespace BeerDrinkin.Forms.Droid
{
    [Activity(Label = "Beer Drinkin", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            InitPlugins();

            LoadApplication(new App());
        }

        private void InitPlugins()
        {
            CachedImageRenderer.Init();
            Toolkit.Init();
            Insights.Initialize(Keys.XamarinInsightsKey, this);
        }
    }
}