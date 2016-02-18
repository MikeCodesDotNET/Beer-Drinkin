using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace CameraViewController.Views
{
	public class PermissionsView : UIView
	{

		UIImageView iconView;
		UILabel titleLabel;
		UILabel descriptionLabel;
		UIButton settingsButton;

		float horizontalPadding = 50f;
		float verticalPadding = 20f;
		float verticalSpacing = 10f;

		public string FontName { get; set; }


		public PermissionsView(CGRect frame)
		{
			this.Frame = frame;
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			BackgroundColor = UIColor.White;

			if (FontName == "")
			{
				FontName = "AppleSDGothicNeo-Regular";
			}

			titleLabel.TextColor = UIColor.White;
			titleLabel.Lines = 0;
			titleLabel.TextAlignment = UITextAlignment.Center;
			titleLabel.Font = UIFont.FromName(FontName, 22);
			titleLabel.Text = Helpers.Strings.PermissionsTitle;

			descriptionLabel.TextColor = UIColor.LightGray;
			descriptionLabel.Lines = 0;
			descriptionLabel.TextAlignment = UITextAlignment.Center;
			descriptionLabel.Font = UIFont.FromName(FontName, 16);

			var icon = UIImage.FromFile("permissionIcon.png");
			iconView.Image = icon;

			settingsButton.ContentEdgeInsets = new UIEdgeInsets(6, 12, 6, 12);
			settingsButton.SetTitle("Settings", UIControlState.Normal);
			settingsButton.SetTitleColor(UIColor.White, UIControlState.Normal);
			settingsButton.Layer.CornerRadius = 4;
			settingsButton.TitleLabel.Font = UIFont.FromName(FontName, 14);
			settingsButton.BackgroundColor = UIColor.FromRGBA(52 / 255, 183 / 255, 250 / 255, 1);
			settingsButton.TouchUpInside += delegate {OpenSettings();};

			AddSubview(iconView);
			AddSubview(titleLabel);
			AddSubview(descriptionLabel);
			AddSubview(settingsButton);

		}

		void OpenSettings()
		{
			var appSettings = UIApplication.OpenSettingsUrlString;
			if(appSettings != null)
				UIApplication.SharedApplication.OpenUrl(new NSUrl(appSettings));
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			var size = Frame.Size;
			var maxLabelWidth = size.Width - horizontalPadding * 2;

			var iconSize = iconView.Image.Size;
			var titleSize = titleLabel.SizeThatFits(new CoreGraphics.CGSize(maxLabelWidth, float.MaxValue));
			var descriptionSize = descriptionLabel.SizeThatFits(new CoreGraphics.CGSize(maxLabelWidth, float.MaxValue));
			var settingsSize = settingsButton.SizeThatFits(new CoreGraphics.CGSize(maxLabelWidth, float.MaxValue));

			var iconX = size.Width / 2 - iconSize.Width / 2;
			var iconY = size.Height/2 - (iconSize.Height + verticalSpacing + verticalSpacing + titleSize.Height + verticalSpacing + descriptionSize.Height)/2;

			iconView.Frame = new CoreGraphics.CGRect(iconX, iconY, iconSize.Width, iconSize.Height);

			var titleX = size.Width / 2 - titleSize.Width / 2;
			var titleY = iconY + iconSize.Height + verticalSpacing + verticalSpacing;

			titleLabel.Frame = new CoreGraphics.CGRect(titleX, titleY, titleSize.Width, titleSize.Height);

			var descriptionX = size.Width / 2 - descriptionSize.Width / 2;
			var descriptionY = titleY + titleSize.Height + verticalSpacing;

			descriptionLabel.Frame = new CoreGraphics.CGRect(descriptionX, descriptionY, descriptionSize.Width, descriptionSize.Height);

			var settingsX = size.Width / 2 - settingsSize.Width / 2;
			var settingsY = descriptionY + descriptionSize.Height + verticalSpacing;

			settingsButton.Frame = new CoreGraphics.CGRect(settingsX, settingsY, settingsSize.Width, settingsSize.Height);
		}
	}
}

