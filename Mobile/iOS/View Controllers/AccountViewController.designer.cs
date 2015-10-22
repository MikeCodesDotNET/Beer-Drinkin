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
	[Register ("AccountViewController")]
	partial class AccountViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnAvatar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgAvatar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgRepeatingImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblBeerCount { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblPhotoCount { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblRatingCount { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIScrollView parallaxScrollView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UICollectionView photoCollection { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIScrollView placeHolderView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIScrollView scrollView { get; set; }

		[Action ("btnAvatar_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnAvatar_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnAvatar != null) {
				btnAvatar.Dispose ();
				btnAvatar = null;
			}
			if (imgAvatar != null) {
				imgAvatar.Dispose ();
				imgAvatar = null;
			}
			if (imgRepeatingImage != null) {
				imgRepeatingImage.Dispose ();
				imgRepeatingImage = null;
			}
			if (lblBeerCount != null) {
				lblBeerCount.Dispose ();
				lblBeerCount = null;
			}
			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}
			if (lblPhotoCount != null) {
				lblPhotoCount.Dispose ();
				lblPhotoCount = null;
			}
			if (lblRatingCount != null) {
				lblRatingCount.Dispose ();
				lblRatingCount = null;
			}
			if (parallaxScrollView != null) {
				parallaxScrollView.Dispose ();
				parallaxScrollView = null;
			}
			if (photoCollection != null) {
				photoCollection.Dispose ();
				photoCollection = null;
			}
			if (placeHolderView != null) {
				placeHolderView.Dispose ();
				placeHolderView = null;
			}
			if (scrollView != null) {
				scrollView.Dispose ();
				scrollView = null;
			}
		}
	}
}
