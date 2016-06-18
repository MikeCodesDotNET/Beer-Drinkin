using System;
using BeerDrinkin.Core.Abstractions.ViewModels;
using BeerDrinkin.iOS.Helpers;
using BeerDrinkin.Utils;
using CoreGraphics;
using Foundation;
using UIKit;

namespace BeerDrinkin.iOS
{
    public class BaseViewController : UIViewController
    {
        public BaseViewController(IntPtr handle)
            : base(handle)
        {
        }

        #region ManageTheKeyboard

        private NSObject _keyboardShowObserver;
        private NSObject _keyboardHideObserver;

        public void Initialize()
        {
            var discover = ServiceLocator.Instance.Resolve<IDiscoverViewModel>();
            if (discover == null)
                Core.ViewModels.ViewModelBase.Init();
        }

        protected virtual void RegisterForKeyboardNotifications()
        {
            if (_keyboardShowObserver == null)
                _keyboardShowObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification,
                    OnKeyboardNotification);
            if (_keyboardHideObserver == null)
                _keyboardHideObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification,
                    OnKeyboardNotification);
        }

        protected virtual void UnregisterForKeyboardNotifications()
        {
            if (_keyboardShowObserver != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(_keyboardShowObserver);
                _keyboardShowObserver.Dispose();
                _keyboardShowObserver = null;
            }

            if (_keyboardHideObserver != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(_keyboardHideObserver);
                _keyboardHideObserver.Dispose();
                _keyboardHideObserver = null;
            }
        }

        private void OnKeyboardNotification(NSNotification notification)
        {
            if (!IsViewLoaded)
                return;

            //Check if the keyboard is becoming visible
            var visible = notification.Name == UIKeyboard.WillShowNotification;

            //Start an animation, using values from the keyboard
            UIView.BeginAnimations("AnimateForKeyboard");
            UIView.SetAnimationBeginsFromCurrentState(true);
            UIView.SetAnimationDuration(UIKeyboard.AnimationDurationFromNotification(notification));
            UIView.SetAnimationCurve((UIViewAnimationCurve) UIKeyboard.AnimationCurveFromNotification(notification));

            //Pass the notification, calculating keyboard height, etc.
            var keyboardFrame = visible
                ? UIKeyboard.FrameEndFromNotification(notification)
                : UIKeyboard.FrameBeginFromNotification(notification);

            OnKeyboardChanged(visible, keyboardFrame);

            //Commit the animation
            UIView.CommitAnimations();
        }


        public virtual void OnKeyboardChanged(bool visible, CGRect keyboardFrame)
        {
            //Implement
        }

        protected void DismissKeyboardOnBackgroundTap()
        {
            // Add gesture recognizer to hide keyboard
            var tap = new UITapGestureRecognizer {CancelsTouchesInView = false};
            tap.AddTarget(() => View.EndEditing(true));
            tap.ShouldReceiveTouch = (recognizer, touch) =>
                !(touch.View is UIControl || touch.View.FindSuperviewOfType(View, typeof (UITableViewCell)) != null);
            View.AddGestureRecognizer(tap);
        }

        #endregion
    }
}