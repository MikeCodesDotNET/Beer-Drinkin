using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using AVFoundation;
using CoreGraphics;
using Xamarin;
using System.Collections.Generic;

//TODO Make the camera view something to be proud of. This is by far the ugliest thing since the birth of my nephew
namespace BeerDrinkin.iOS
{
    partial class CameraViewController : UIViewController
    {
        AVCaptureSession captureSession;
        AVCaptureDeviceInput captureDeviceInput;
        AVCaptureStillImageOutput stillImageOutput;
        UIView liveCameraStream;
        bool flashOn;

        public CameraViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupUserInterface();

            AuthorizeCameraUse();
            SetupLiveCameraStream();

        }

        public async void AuthorizeCameraUse()
        {
            var authorizationStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);

            if (authorizationStatus != AVAuthorizationStatus.Authorized)
            {
                await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);
            }
        }

        public void SetupLiveCameraStream()
        {
            captureSession = new AVCaptureSession();

            var viewLayer = liveCameraStream.Layer;

            Console.WriteLine(viewLayer.Frame.Width);

            var videoPreviewLayer = new AVCaptureVideoPreviewLayer(captureSession)
            {
                Frame = liveCameraStream.Bounds
            };
            liveCameraStream.Layer.AddSublayer(videoPreviewLayer);

            Console.WriteLine(liveCameraStream.Layer.Frame.Width);

            var captureDevice = AVCaptureDevice.DefaultDeviceWithMediaType(AVMediaType.Video);
            ConfigureCameraForDevice(captureDevice);
            captureDeviceInput = AVCaptureDeviceInput.FromDevice(captureDevice);

            var dictionary = new NSMutableDictionary();
            dictionary[AVVideo.CodecKey] = new NSNumber((int)AVVideoCodec.JPEG);
            stillImageOutput = new AVCaptureStillImageOutput()
            {
                OutputSettings = new NSDictionary()
            };

            captureSession.AddOutput(stillImageOutput);
            captureSession.AddInput(captureDeviceInput);
            captureSession.StartRunning();

            ViewWillLayoutSubviews();
        }


        public async void CapturePhoto()
        {
            var videoConnection = stillImageOutput.ConnectionFromMediaType(AVMediaType.Video);
            var sampleBuffer = await stillImageOutput.CaptureStillImageTaskAsync(videoConnection);

            // var jpegImageAsBytes = AVCaptureStillImageOutput.JpegStillToNSData (sampleBuffer).ToArray ();
            var jpegImageAsNsData = AVCaptureStillImageOutput.JpegStillToNSData(sampleBuffer);

            // SendPhoto (data);
            PhotoTaken(jpegImageAsNsData.ToArray());

            var image = new UIImage (jpegImageAsNsData);
            var imageView = new UIImageView(liveCameraStream.Frame);
            imageView.Image = image;
            Add(imageView);
            View.SendSubviewToBack(imageView);
            View.SendSubviewToBack(liveCameraStream);

        }

        public void ToggleFrontBackCamera()
        {
            var devicePosition = captureDeviceInput.Device.Position;
            if (devicePosition == AVCaptureDevicePosition.Front)
            {
                devicePosition = AVCaptureDevicePosition.Back;
            }
            else
            {
                devicePosition = AVCaptureDevicePosition.Front;
            }

            var device = GetCameraForOrientation(devicePosition);
            ConfigureCameraForDevice(device);

            captureSession.BeginConfiguration();
            captureSession.RemoveInput(captureDeviceInput);
            captureDeviceInput = AVCaptureDeviceInput.FromDevice(device);
            captureSession.AddInput(captureDeviceInput);
            captureSession.CommitConfiguration();
        }

        public void ConfigureCameraForDevice(AVCaptureDevice device)
        {
            var error = new NSError();
            if (device.IsFocusModeSupported(AVCaptureFocusMode.ContinuousAutoFocus))
            {
                device.LockForConfiguration(out error);
                device.FocusMode = AVCaptureFocusMode.ContinuousAutoFocus;
                device.UnlockForConfiguration();
            }
            else if (device.IsExposureModeSupported(AVCaptureExposureMode.ContinuousAutoExposure))
            {
                device.LockForConfiguration(out error);
                device.ExposureMode = AVCaptureExposureMode.ContinuousAutoExposure;
                device.UnlockForConfiguration();
            }
            else if (device.IsWhiteBalanceModeSupported(AVCaptureWhiteBalanceMode.ContinuousAutoWhiteBalance))
            {
                device.LockForConfiguration(out error);
                device.WhiteBalanceMode = AVCaptureWhiteBalanceMode.ContinuousAutoWhiteBalance;
                device.UnlockForConfiguration();
            }
        }

        public void ToggleFlash()
        {
            var device = captureDeviceInput.Device;

            var error = new NSError();
            if (device.HasFlash)
            {
                if (device.FlashMode == AVCaptureFlashMode.On)
                {
                    device.LockForConfiguration(out error);
                    device.FlashMode = AVCaptureFlashMode.Off;
                    device.UnlockForConfiguration();

                    btnToggleFlash.SetBackgroundImage(UIImage.FromFile("flashOff.png"), UIControlState.Normal);
                    flashOn = false;
                }
                else
                {
                    device.LockForConfiguration(out error);
                    device.FlashMode = AVCaptureFlashMode.On;
                    device.UnlockForConfiguration();

                    btnToggleFlash.SetBackgroundImage(UIImage.FromFile("flashOn.png"), UIControlState.Normal);
                    flashOn = true;
                }
            }
        }

        public AVCaptureDevice GetCameraForOrientation(AVCaptureDevicePosition orientation)
        {
            var devices = AVCaptureDevice.DevicesWithMediaType(AVMediaType.Video);

            foreach (var device in devices)
            {
                if (device.Position == orientation)
                {
                    return device;
                }
            }

            return null;
        }

        private void SetupUserInterface()
        {
            liveCameraStream = new UIView();
            liveCameraStream.Frame = new CGRect(0f, 0f, View.Frame.Width, View.Frame.Height);
            liveCameraStream.BackgroundColor = UIColor.Red;
            View.Add(liveCameraStream);
            View.SendSubviewToBack(liveCameraStream);

            ViewWillLayoutSubviews();
        }

        public delegate void PhotoTakenHandler(byte[] image);

        public event PhotoTakenHandler PhotoTaken;

        partial void btnTakePhoto_TouchUpInside(UIButton sender)
        {
            CapturePhoto();
        }

        partial void btnToggleFlash_TouchUpInside(UIButton sender)
        {
            ToggleFlash();
        }

        partial void btnBack_TouchUpInside(UIButton sender)
        {
            this.DismissViewController(true, null);
        }

    }
}
