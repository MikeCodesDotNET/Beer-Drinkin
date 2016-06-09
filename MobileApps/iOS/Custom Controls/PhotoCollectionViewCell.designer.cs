// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BeerDrinkin.iOS
{
	[Register ("PhotoCollectionViewCell")]
	partial class PhotoCollectionViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgPhoto { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (imgPhoto != null) {
				imgPhoto.Dispose ();
				imgPhoto = null;
			}
		}
	}
}
