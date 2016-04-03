using System;
using UIKit;
using Photos;
using Foundation;

namespace CameraViewController.Models
{
	public class ImageModel : NSObject
	{
		public ImageModel(PHAsset asset, PHCachingImageManager manager)
		{
			ImageAsset = asset;
			ImageManager = manager;
		}

		bool Selected = false;

		PHAsset ImageAsset = new PHAsset();
		PHCachingImageManager ImageManager = new PHCachingImageManager();

	}
}

