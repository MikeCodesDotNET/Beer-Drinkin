using BeerDrinkin.Forms.Pages;
using UIKit;
using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(DiscoverPage), typeof(DiscoverPageRenderer))]

namespace BeerDrinkin.Forms.iOS.CustomRenderers
{
    public class DiscoverPageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //if (SearchDisplayController != null)
            //{
            //    SearchDisplayController.DisplaysSearchBarInNavigationBar = true;
            //}
            if (NavigationController != null)
            {
                var foo = Element as DiscoverPage;

                NavigationController.NavigationBarHidden = true;

                var frame = NavigationController.View.Frame;
                frame.Y = 20;
                frame.Height = UIScreen.MainScreen.Bounds.Size.Height - 20;
                NavigationController.View.Frame = frame;
            }
        }
    }
}