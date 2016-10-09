using Foundation;
using System;
using UIKit;
using ObjCRuntime;

using BeerDrinkin.Models;
using SDWebImage;
using CoreImage;
using System.Linq;

namespace BeerDrinkin.iOS
{
    public partial class BeerDescriptionHeaderView : UIView
    {
        public BeerDescriptionHeaderView (IntPtr handle) : base (handle)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

        }


        public static BeerDescriptionHeaderView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("BeerDescriptionHeaderView", null, null);
            var v = Runtime.GetNSObject<BeerDescriptionHeaderView>(arr.ValueAt(0));
            return v;
        }

        Beer beer;
        public void SetBeer(Beer beer)
        {
            this.beer = beer;

            statsView.Name = beer.Name;
            statsView.Country = beer.OriginCountry;
            statsView.ABV = beer.Abv.ToString();

            if (beer.Images.Count > 0)
            {
                var img = beer.Images.FirstOrDefault();
                image.SetImage(new NSUrl(img.LargeUrl));
            }
        }

        void DarkenImage()
        {
            var img = image.Image;
            var ciImage = new CIImage(img);
            var hueAdjust = new CIHueAdjust();   // first filter
            hueAdjust.Image = ciImage;
            hueAdjust.Angle = 2.094f;
            var sepia = new CISepiaTone();       // second filter
            sepia.Image = hueAdjust.OutputImage; // output from last filter, input to this one
            sepia.Intensity = 0.3f;
            CIFilter color = new CIColorControls()
            { // third filter
                Saturation = 2,
                Brightness = 1,
                Contrast = 3,
                Image = sepia.OutputImage    // output from last filter, input to this one
            };
            var output = color.OutputImage;
            var context = CIContext.FromOptions(null);
            // ONLY when CreateCGImage is called do all the effects get rendered
            var cgimage = context.CreateCGImage(output, output.Extent);
            var ui = UIImage.FromImage(cgimage);
            image.Image = ui;
        }

    }
}