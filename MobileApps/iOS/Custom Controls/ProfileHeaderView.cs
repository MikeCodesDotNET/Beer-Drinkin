using Foundation;
using System;
using UIKit;
using SDWebImage;

using BeerDrinkin.Models;
using ObjCRuntime;

namespace BeerDrinkin.iOS
{
    public partial class ProfileHeaderView : UIView
    {
        public ProfileHeaderView (IntPtr handle) : base (handle)
        {
        }

        User user;
        public void SetUser(User user)
        {
            this.user = user;
            nameLabel.Text = $"{user.FirstName} {user.LastName}";
        }

        public static ProfileHeaderView Create()
        {

            var arr = NSBundle.MainBundle.LoadNib("ProfileHeaderView", null, null);
            var v = Runtime.GetNSObject<ProfileHeaderView>(arr.ValueAt(0));
            return v;
        }


        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if (user == null)
                profileImage.Image = UIImage.FromFile("BeerDrinkin.png");
            else
            {
                profileImage.Layer.CornerRadius = profileImage.Frame.Height / 2;
                profileImage.Layer.MasksToBounds = true;
                profileImage.Layer.BorderWidth = 3;
                profileImage.Layer.BorderColor = UIColor.White.CGColor;
            }

            #if DEBUG
            profileImage.Layer.CornerRadius = profileImage.Frame.Height / 2;
            profileImage.Layer.MasksToBounds = true;
            profileImage.Layer.BorderWidth = 3;
            profileImage.Layer.BorderColor = UIColor.White.CGColor;
            profileImage.Image = UIImage.FromFile("mike_james_avatar.png");
            #endif
        }

        partial void BtnSettings_TouchUpInside(UIButton sender)
        {
            throw new NotImplementedException();
        }

        partial void BtnMore_TouchUpInside(UIButton sender)
        {
            throw new NotImplementedException();
        }
    }
}