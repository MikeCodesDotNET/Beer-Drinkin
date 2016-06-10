using System;
using BeerDrinkin.Core.ViewModels;
using Foundation;
using UIKit;
using SDWebImage;
using MikeCodesDotNET.iOS;
using Plugin.Connectivity;
using System.Threading.Tasks;

namespace BeerDrinkin.iOS
{
    partial class AccountViewController : UIViewController
    {
        readonly UserProfileViewModel viewModel = new UserProfileViewModel();

        public AccountViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}