using FFImageLoading.Transformations;
using Xamarin.Forms;

namespace BeerDrinkin.Forms.Pages
{
    public partial class BeerDetailsPage : ContentPage
    {
        public BeerDetailsPage()
        {
            InitializeComponent();

            // HACK: Needed to not optimize transformations dll out
            var foo = new CircleTransformation();
        }
    }
}