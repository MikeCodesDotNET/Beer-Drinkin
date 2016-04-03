using System;
using AVFoundation;
using CameraViewController.Views;
using CoreGraphics;
using Foundation;
using UIKit;

namespace CameraViewController
{
	public class CameraViewController : UIViewController
	{

		CameraView cameraView;
		CropOverlay cameraOverlay;
		UIButton cameraButton;

		UIButton closeButton;
		UIButton swapButton;
		UIButton libraryButton;
		UIButton toggleFlashButton;

		bool allowsCropping;

		float verticlePadding = 30f;
		float horizontalPadding = 30f;

		public CameraViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.Black;
			View.AddSubview(cameraView);

			if (allowsCropping == true)
			{
				LayoutCropView();
			}

			cameraView.Frame = View.Bounds;
		}

		public void SwapCamera()
		{
			cameraView.SwapCameraInput();
			toggleFlashButton.Hidden = cameraView.CurrentPosition == AVFoundation.AVCaptureDevicePosition.Front ? true : false;
		}

		public void ToggleFlash()
		{
			var device = AVCaptureDevice.DefaultDeviceWithMediaType(AVMediaType.Video);
			NSError error;
			if (device.FlashMode == AVCaptureFlashMode.On) {
				device.LockForConfiguration (out error);
				device.FlashMode = AVCaptureFlashMode.Off;
				device.UnlockForConfiguration ();

				toggleFlashButton.SetBackgroundImage (UIImage.FromFile ("flashOffIcon.png"), UIControlState.Normal);
			} else {
				device.LockForConfiguration (out error);
				device.FlashMode = AVCaptureFlashMode.On;
				device.UnlockForConfiguration ();

				toggleFlashButton.SetBackgroundImage (UIImage.FromFile ("flashOnIcon.png"), UIControlState.Normal);
			}
		}

		public async void CheckPermissions ()
		{
			var authorizationStatus = AVCaptureDevice.GetAuthorizationStatus (AVMediaType.Video);

			if (authorizationStatus != AVAuthorizationStatus.Authorized) {
				await AVCaptureDevice.RequestAccessForMediaTypeAsync (AVMediaType.Video);
			}
		}

		void LayoutCamera()
		{
			cameraButton.SetImage(UIImage.FromFile("cameraButton.png"), UIControlState.Normal);
			cameraButton.SetImage(UIImage.FromFile("cameraButtonHighlighted.png"), UIControlState.Highlighted);

			closeButton.SetImage(UIImage.FromFile("closeButton.png"), UIControlState.Normal);
			swapButton.SetImage(UIImage.FromFile("swapButton.png"), UIControlState.Normal);
			libraryButton.SetImage(UIImage.FromFile("libraryButton.png"), UIControlState.Normal);
			toggleFlashButton.SetImage(UIImage.FromFile("swapButton.png"), UIControlState.Normal);

			cameraButton.SizeToFit();
			closeButton.SizeToFit();
			swapButton.SizeToFit();
			libraryButton.SizeToFit();
			toggleFlashButton.SizeToFit();

			View.AddSubview(cameraButton);
			View.AddSubview(libraryButton);
			View.AddSubview(closeButton);
			View.AddSubview(swapButton);
			View.AddSubview(toggleFlashButton);

			cameraButton.Enabled = true;
			CameraEndState();

		}

		void CameraEndState()
		{

		}

		void LayoutCropView()
		{
			
		}

		void ShowPermissionsView()
		{
			var permissionsView = new Views.PermissionsView(View.Bounds);
			View.AddSubview(permissionsView);
			View.AddSubview(closeButton);

			closeButton.SetImage(UIImage.FromFile(""), UIControlState.Normal);
			closeButton.SizeToFit();
			closeButton.TouchUpInside += delegate {

			};

			var size = View.Frame.Size;
			var closeSize = closeButton.Frame.Size;
			var closeX = horizontalPadding;
			var closeY = size.Height - (closeSize.Height + verticlePadding);

			var closePositon = new CGPoint(closeX, closeY);
			closeButton.Frame = new CGRect(closePositon, closeSize);
		}
	}
}

